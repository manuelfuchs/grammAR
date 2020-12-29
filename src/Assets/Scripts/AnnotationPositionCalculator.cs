using System;
using Assets.Scripts.Types;
using UnityEngine;

namespace Assets.Scripts
{
    public static class AnnotationPositionCalculator
    {
        private const int CharsPerLine = 70;
        private const float LetterHeight = 0.017f;
        private const float LetterWidth = 0.012f;
        private const float XStartingPoint = -2.837f;
        private const float ZStartingPoint = 3.887f;
        private const float DefaultYPos = 0.1f;
        private const float DefaultYScale = 1f;


        public static AnnotationPosition CalcOverlayPosition(GameObject parent, SpellingMistake spellingMistake)
        {
            var letters = spellingMistake.ErrorEnd - spellingMistake.ErrorStart;
            Debug.Log($"letters {letters}");
            var xPos = XStartingPoint + LetterWidth * 10 * (spellingMistake.ErrorStart - 1 + letters / 2);
            Debug.Log($"xPos: {xPos}");
            var zPos = ZStartingPoint - LetterHeight * 10 * (spellingMistake.Line - 1);

            var localPos = new Vector3(xPos, DefaultYPos, zPos);
            var localScale = new Vector3(LetterWidth * letters, DefaultYScale, LetterHeight);

            return new AnnotationPosition
            {
                LocalPosition = localPos,
                LocalScale = localScale
            };
        }

        public static AnnotationPosition CalcUnderlinePosition(GameObject parent, SpellingMistake spellingMistake)
        {
            throw new NotImplementedException();
        }
    }
}