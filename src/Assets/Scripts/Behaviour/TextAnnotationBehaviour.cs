using System.Collections.Concurrent;
using System.Collections.Generic;
using Assets.Scripts.Components.CurseWordChecker;
using Assets.Scripts.Components.OverlayPositionCalculator;
using Assets.Scripts.Components.SettingsComponent;
using Assets.Scripts.Components.SpellChecker;
using Assets.Scripts.Components.TextExtractor;
using Assets.Scripts.Types;
using UnityEngine;

namespace Assets.Scripts.Behaviour
{
    public class TextAnnotationBehaviour : MonoBehaviour
    {
        public GameObject letterBoxPrefab;
        public GameObject parent;
        public GameObject textPrefab;

        private IOverlayPositionCalculator overlayPositionCalculator;
        private ISettingsComponent settingsComponent;
        private ITextExtractor textExtractor;
        private ISpellChecker spellChecker;
        private ICurseWordChecker curseWordChecker;

        private readonly ConcurrentStack<GameObject> renderedMistakeAnnotations = new ConcurrentStack<GameObject>();
        private readonly ConcurrentStack<GameObject> renderedCurseWordAnnotations = new ConcurrentStack<GameObject>();

        public void Start()
        {
            this.overlayPositionCalculator = ComponentConfig.Instance.GetService<IOverlayPositionCalculator>();
            this.settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            this.textExtractor = ComponentConfig.Instance.GetService<ITextExtractor>();
            this.spellChecker = ComponentConfig.Instance.GetService<ISpellChecker>();
            this.curseWordChecker = ComponentConfig.Instance.GetService<ICurseWordChecker>();

            this.spellChecker.OnMistakesFound += UpdateMistakeAnnotations;
            this.curseWordChecker.OnCurseWordsFound += UpdateCurseWordAnnotations;
            this.textExtractor.OnTextLost += () =>
            {
                ClearCurseWords();
                ClearMistakeAnnotations();
            };
        }

        private void ClearMistakeAnnotations()
        {
            foreach (var annotation in this.renderedMistakeAnnotations)
            {
                Destroy(annotation);
            }

            this.renderedMistakeAnnotations.Clear();
        }

        private void ClearCurseWords()
        {
            foreach (var annotation in this.renderedCurseWordAnnotations)
            {
                Destroy(annotation);
            }

            this.renderedMistakeAnnotations.Clear();
        }

        private void UpdateMistakeAnnotations(IEnumerable<SpellingMistake> mistakes)
        {
            ClearMistakeAnnotations();

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
            ClearCurseWords();

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
            else if (spellingMistake.Severity == SpellingSeverity.Fatal)
            {
                annotationObject.GetComponent<Renderer>().material =
                    Resources.Load<Material>("Materials/ErrorAnnotation");
            }

            if (spellingMistake.SuggestedCorrection != null)
            {
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
            var curseWordTransform = overlayPositionCalculator.CalculateCurseWordOverlay(curseWord);
            var worldPosition = parent.transform.TransformPoint(curseWordTransform.LocalPosition);
            var curseWordObject =
                Instantiate(letterBoxPrefab, worldPosition, parent.transform.rotation, parent.transform);
            curseWordObject.transform.localScale = curseWordTransform.LocalScale;
            curseWordObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Red");
            this.renderedCurseWordAnnotations.Push(curseWordObject);
        }
    }
}