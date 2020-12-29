using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public GameObject prefab;
        public GameObject parent;
        private ConcurrentBag<GameObject> storedAnnotations;

        // Start is called before the first frame update
        void Start()
        {
            textExtractor = ComponentConfig.Instance.GetService<ITextExtractor>();
            spellChecker = ComponentConfig.Instance.GetService<ISpellChecker>();
            Debug.Log($"Spellchecker null {spellChecker == null}");
            textExtractor.OnTextFound += async text => await HandleTextFound(text);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private async Task HandleTextFound(IEnumerable<string> text)
        {
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
                var annotationPosition = AnnotationPositionCalculator.CalcOverlayPosition(parent, spellingMistake);
                DisplayAnnotation(annotationPosition);
            }
        }

        private void DisplayAnnotation(AnnotationPosition annotationPosition)
        {
            var annotationObject = Instantiate(prefab,
                parent.transform.TransformPoint(annotationPosition.LocalPosition),
                Quaternion.identity,
                parent.transform);
            annotationObject.transform.localScale = annotationPosition.LocalScale;
            annotationObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/ErrorAnnotation");
        }
    }
}