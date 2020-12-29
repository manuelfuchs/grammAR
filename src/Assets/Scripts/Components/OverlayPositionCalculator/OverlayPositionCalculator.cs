using Assets.Scripts.Types;
using UnityEngine;

namespace Assets.Scripts.Components.OverlayPositionCalculator
{
    public class OverlayPositionCalculator : IOverlayPositionCalculator
    {
        private const float LetterHeight = 0.0164f;
        private const float LetterWidth = 0.01135f;
        private const float XStartingPoint = -2.837f;
        private const float ZStartingPoint = 3.887f;
        private const float DefaultYPos = 0.1f;
        private const float DefaultYScale = 1f;

        public OverlayTransform CalculateMistakeOverlayPosition(SpellingMistake spellingMistake)
        {
            var letters = spellingMistake.TextEnd - spellingMistake.TextStart;
            var xPos = XStartingPoint + LetterWidth * 10 * (spellingMistake.TextStart - 1 + letters / 2);
            var zPos = ZStartingPoint - LetterHeight * 10 * (spellingMistake.Line - 1);

            var localPos = new Vector3(xPos, DefaultYPos, zPos);
            var localScale = new Vector3(LetterWidth * letters, DefaultYScale, LetterHeight);

            return new OverlayTransform
            {
                LocalPosition = localPos,
                LocalScale = localScale
            };
        }

        public OverlayTransform CalculateCorrectionOverlayPosition(SpellingMistake spellingMistake)
        {
            var annotationPosition = CalculateMistakeOverlayPosition(spellingMistake).LocalPosition;
            var correctionPosition = new OverlayTransform
            {
                LocalPosition = new Vector3(
                    annotationPosition.x + LetterWidth * 10 * (spellingMistake.TextEnd - spellingMistake.TextStart),
                    annotationPosition.y,
                    annotationPosition.z + LetterHeight + 0.2f
                ),
                LocalScale = new Vector3(
                    spellingMistake.SuggestedCorrection.Length * LetterWidth, DefaultYScale, LetterHeight)
            };

            return correctionPosition;
        }
    }
}