using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Components.CurseWordFilter;
using Assets.Scripts.Components.OverlayPositionCalculator;
using Assets.Scripts.Components.SettingsComponent;
using Assets.Scripts.Components.SpellChecker;
using Assets.Scripts.Components.TextExtractor;
using Assets.Scripts.Types;
using UnityEngine;

namespace Assets.Scripts.TextAnnotation
{
    public class TextAnnotatorScript : MonoBehaviour
    {
        private ITextExtractor textExtractor;
        private ISpellChecker spellChecker;
        private IOverlayPositionCalculator overlayPositionCalculator;
        private ICurseWordFilter curseWordFilter;
        private ISettingsComponent settingsComponent;
        public GameObject letterBoxPrefab;
        public GameObject parent;
        public GameObject textPrefab;
        private readonly ConcurrentStack<GameObject> storedAnnotations = new ConcurrentStack<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            textExtractor = ComponentConfig.Instance.GetService<ITextExtractor>();
            spellChecker = ComponentConfig.Instance.GetService<ISpellChecker>();
            overlayPositionCalculator = ComponentConfig.Instance.GetService<IOverlayPositionCalculator>();
            curseWordFilter = ComponentConfig.Instance.GetService<ICurseWordFilter>();
            settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            textExtractor.OnTextFound += async text => await HandleTextFound(text);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private async Task HandleTextFound(IEnumerable<string> text)
        {
            foreach (var annotation in this.storedAnnotations)
            {
                Destroy(annotation);
            }

            this.storedAnnotations.Clear();

            if (text == null)
            {
                return;
            }

            var textList = text.ToList();
            if (!textList.Any())
            {
                return;
            }


            var spellingMistakes = await spellChecker.GetMistakes(textList);

            foreach (var spellingMistake in spellingMistakes)
            {
                DisplaySpellingMistake(spellingMistake);
            }

            //TODO check with settings
            var curseWords = curseWordFilter.FindCurseWords(textList, settingsComponent.Language);
            foreach (var curseWord in curseWords)
            {
                DisplayCurseWordFilter(curseWord);
            }
        }

        private void DisplaySpellingMistake(SpellingMistake spellingMistake)
        {
            var annotationPosition = overlayPositionCalculator.CalculateOverlayPosition(spellingMistake);

            var annotationObject = Instantiate(letterBoxPrefab,
                parent.transform.TransformPoint(annotationPosition.LocalPosition),
                parent.transform.rotation,
                parent.transform);
            annotationObject.transform.localScale = annotationPosition.LocalScale;

            if (spellingMistake.Severity == SpellingSeverity.Minor)
            {
                annotationObject.GetComponent<Renderer>().material =
                    Resources.Load<Material>("Materials/WarningAnnotation");
            }
            else if (spellingMistake.Severity == SpellingSeverity.Fatal && spellingMistake.SuggestedCorrection != null)
            {
                annotationObject.GetComponent<Renderer>().material =
                    Resources.Load<Material>("Materials/ErrorAnnotation");
                DisplayCorrection(spellingMistake);
            }

            this.storedAnnotations.Push(annotationObject);
        }

        private void DisplayCorrection(SpellingMistake spellingMistake)
        {
            var correctionTransform = overlayPositionCalculator.CalculateCorrectionOverlayPosition(spellingMistake);
            var worldPosition = parent.transform.TransformPoint(correctionTransform.LocalPosition);
            var correctionObject =
                Instantiate(letterBoxPrefab, worldPosition, parent.transform.rotation, parent.transform);

            correctionObject.transform.localScale = correctionTransform.LocalScale;
            correctionObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Red");
            this.storedAnnotations.Push(correctionObject);

            DisplayCorrectionText(correctionObject, spellingMistake.SuggestedCorrection);
        }

        private void DisplayCorrectionText(GameObject correctionObject, string correction)
        {
            var correctionText = Instantiate(textPrefab, correctionObject.transform);

            correctionText.transform.position = correctionObject.transform.position;
            correctionText.transform.localScale = new Vector3(0.8f, 4, correction.Length);
            correctionText.GetComponent<TextMesh>().text = correction;
            this.storedAnnotations.Push(correctionText);
        }

        private void DisplayCurseWordFilter(CurseWord curseWord)
        {
            var curseWordTransform = overlayPositionCalculator.CalculateCurseWordOverlay(curseWord);
            var worldPosition = parent.transform.TransformPoint(curseWordTransform.LocalPosition);
            var curseWordObject =
                Instantiate(letterBoxPrefab, worldPosition, parent.transform.rotation, parent.transform);
            curseWordObject.transform.localScale = curseWordTransform.LocalScale;
            curseWordObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Red");
            this.storedAnnotations.Push(curseWordObject);
        }
    }
}