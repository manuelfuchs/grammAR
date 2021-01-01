using System.Collections.Concurrent;
using System.Collections.Generic;
using Assets.Scripts.Components.CurseWordFilter;
using Assets.Scripts.Components.OverlayPositionCalculator;
using Assets.Scripts.Components.SettingsComponent;
using Assets.Scripts.Components.SpellChecker;
using Assets.Scripts.Types;
using UnityEngine;

namespace Assets.Scripts.TextAnnotation
{
    public class TextAnnotationBehaviour : MonoBehaviour
    {
        public GameObject letterBoxPrefab;
        public GameObject parent;
        public GameObject textPrefab;

        private readonly IOverlayPositionCalculator overlayPositionCalculator;
        private readonly ISettingsComponent settingsComponent;

        private readonly ConcurrentStack<GameObject> renderedMistakeAnnotations = new ConcurrentStack<GameObject>();
        private readonly ConcurrentStack<GameObject> renderedCurseWordAnnotations = new ConcurrentStack<GameObject>();

        public TextAnnotationBehaviour()
        {
            this.overlayPositionCalculator = ComponentConfig.Instance.GetService<IOverlayPositionCalculator>();
            this.settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();

            var spellChecker = ComponentConfig.Instance.GetService<ISpellChecker>();
            var curseWordFilter = ComponentConfig.Instance.GetService<ICurseWordFilter>();

            spellChecker.OnMistakesFound += mistakes => UpdateMistakeAnnotations(mistakes);
            curseWordFilter.OnCurseWordsFound += curseWords => UpdateCurseWordAnnotations(curseWords);
        }

        private void UpdateMistakeAnnotations(IEnumerable<SpellingMistake> mistakes)
        {
            foreach (var annotation in this.renderedMistakeAnnotations)
            {
                UnityEngine.GameObject.Destroy(annotation);
            }
            this.renderedMistakeAnnotations.Clear();

            if (mistakes != null)
            {
                foreach (var mistake in mistakes)
                {
                    this.DisplaySpellingMistake(mistake);
                }
            }
        }

        private void UpdateCurseWordAnnotations(IEnumerable<CurseWord> curseWords)
        {
            foreach (var annotation in this.renderedCurseWordAnnotations)
            {
                UnityEngine.GameObject.Destroy(annotation);
            }
            this.renderedMistakeAnnotations.Clear();

            if (curseWords != null
                && this.settingsComponent.IsCurseWordBleepingEnabled)
            {
                foreach (var curseWord in curseWords)
                {
                    this.DisplayCurseWordFilter(curseWord);
                }
            }
        }

        private void DisplaySpellingMistake(SpellingMistake spellingMistake)
        {
            var annotationPosition = overlayPositionCalculator.CalculateOverlayPosition(spellingMistake);

            var annotationObject = Instantiate(
                letterBoxPrefab,
                parent.transform.TransformPoint(annotationPosition.LocalPosition),
                parent.transform.rotation,
                parent.transform);

            annotationObject.transform.localScale = annotationPosition.LocalScale;

            if (spellingMistake.Severity == SpellingSeverity.Minor)
            {
                annotationObject.GetComponent<Renderer>().material =
                    Resources.Load<Material>("Materials/WarningAnnotation");
            }
            else if (spellingMistake.Severity == SpellingSeverity.Fatal
                 && spellingMistake.SuggestedCorrection != null)
            {
                annotationObject.GetComponent<Renderer>().material =
                    Resources.Load<Material>("Materials/ErrorAnnotation");

                DisplayCorrection();
            }

            this.renderedMistakeAnnotations.Push(annotationObject);

            void DisplayCorrection()
            {
                var correctionTransform = overlayPositionCalculator.CalculateCorrectionOverlayPosition(spellingMistake);
                var worldPosition = parent.transform.TransformPoint(correctionTransform.LocalPosition);
                var correctionObject =
                    Instantiate(letterBoxPrefab, worldPosition, parent.transform.rotation, parent.transform);

                correctionObject.transform.localScale = correctionTransform.LocalScale;
                correctionObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Red");
                this.renderedMistakeAnnotations.Push(correctionObject);

                DisplayCorrectionText(correctionObject, spellingMistake.SuggestedCorrection);
            }

            void DisplayCorrectionText(GameObject correctionObject, string correction)
            {
                var correctionText = Instantiate(textPrefab, correctionObject.transform);

                correctionText.transform.position = correctionObject.transform.position;
                correctionText.transform.localScale = new Vector3(0.8f, 4, correction.Length);
                correctionText.GetComponent<TextMesh>().text = correction;
                this.renderedMistakeAnnotations.Push(correctionText);
            }
        }

        private void DisplayCurseWordFilter(CurseWord curseWord)
        {
            var curseWordTransform = overlayPositionCalculator.CalculateOverlayPosition(curseWord);
            var worldPosition = parent.transform.TransformPoint(curseWordTransform.LocalPosition);
            var curseWordObject =
                Instantiate(letterBoxPrefab, worldPosition, parent.transform.rotation, parent.transform);
            curseWordObject.transform.localScale = curseWordTransform.LocalScale;
            curseWordObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Red");
            this.renderedMistakeAnnotations.Push(curseWordObject);
        }
    }
}