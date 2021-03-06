﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using Assets.Scripts.Components.CurseWordChecker;
using Assets.Scripts.Components.OverlayPositionCalculator;
using Assets.Scripts.Components.SettingsComponent;
using Assets.Scripts.Components.SpellChecker;
using Assets.Scripts.Components.TextExtractor;
using Assets.Scripts.Extensions;
using Assets.Scripts.Types;
using UnityEngine;
using UnityEngine.UI;

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
            this.curseWordChecker.OnCurseWordsExtracted += UpdateCurseWordAnnotations;
            this.textExtractor.OnTextLost += () =>
            {
                ClearCurseWords();
                ClearMistakeAnnotations();
            };

            settingsComponent.OnIsCWBEnabledChanged += state =>
            {
                if (!state)
                {
                    ClearCurseWords();
                }
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

            this.renderedCurseWordAnnotations.Clear();
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
                switch (spellingMistake.Severity)
                {
                    case SpellingSeverity.Minor:
                        correctionObject.GetComponent<Renderer>().material =
                            Resources.Load<Material>("Materials/MinorCorrection");
                        break;
                    case SpellingSeverity.Fatal:
                        correctionObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Red");
                        break;
                }

                this.renderedMistakeAnnotations.Push(correctionObject);
                DisplayOverlayText(correctionObject, spellingMistake.SuggestedCorrection, Color.white);
            }
        }

        private void DisplayOverlayText(GameObject correctionObject, string text, Color color)
        {
            var correctionText = Instantiate(textPrefab, parent.transform);

            correctionText.transform.position = correctionObject.transform.position;
            correctionText.transform.localScale = new Vector3(0.07f, 0.05f, text.Length);
            correctionText.GetComponent<TextMesh>().text = text;
            correctionText.GetComponent<TextMesh>().color = color;
            this.renderedMistakeAnnotations.Push(correctionText);
        }

        private void DisplayCurseWordFilter(CurseWord curseWord)
        {
            var curseWordTransform = overlayPositionCalculator.CalculateCurseWordOverlay(curseWord);
            var worldPosition = parent.transform.TransformPoint(curseWordTransform.LocalPosition);
            var curseWordObject =
                Instantiate(letterBoxPrefab, worldPosition, parent.transform.rotation, parent.transform);
            curseWordObject.transform.localScale = curseWordTransform.LocalScale;
            curseWordObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/White");
            this.renderedCurseWordAnnotations.Push(curseWordObject);
            DisplayOverlayText(curseWordObject, "*".Repeat(curseWord.TextEnd - curseWord.TextStart - 1), Color.black);
        }
    }
}