using Assets.Scripts.Types;
using UnityEngine;

namespace Assets.Scripts.Components.OverlayPositionCalculator
{
    public class OverlayPositionCalculator : IOverlayPositionCalculator
    {
        private const float LetterHeight = 0.0167f;
        private const float LetterWidth = 0.01157254901960784313725490196078f;
        private const float XStartingPoint = -2.85f;
        private const float ZStartingPoint = 3.887f;
        private const float DefaultYPos = 0;
        private const float DefaultYScale = 1f;

        public OverlayTransform CalculateOverlayPosition(TextPosition textPosition)
        {
            var letters = textPosition.TextEnd - textPosition.TextStart;
            var xPos = XStartingPoint + LetterWidth * 10 * (textPosition.TextStart - 1 + (letters - 1) / (float) 2);
            var zPos = ZStartingPoint - LetterHeight * 10 * (textPosition.Line - 1);

            var localPos = new Vector3(xPos, DefaultYPos, zPos);
            var localScale = new Vector3(LetterWidth * letters, DefaultYScale, LetterHeight);

            return new OverlayTransform
            {
                LocalPosition = localPos,
                LocalScale = localScale
            };
        }

        public OverlayTransform CalculateCurseWordOverlay(CurseWord curseWord, bool showFirstLetter = true)
        {
            if (showFirstLetter)
            {
                return CalculateOverlayPosition(new TextPosition(curseWord.Line, curseWord.TextStart + 1,
                    curseWord.TextEnd));
            }
            else
            {
                return CalculateOverlayPosition(curseWord);
            }
        }

        public OverlayTransform CalculateCorrectionOverlayPosition(SpellingMistake spellingMistake)
        {
            if (spellingMistake.SuggestedCorrection == null) return null;
            var annotationPosition = CalculateOverlayPosition(spellingMistake).LocalPosition;
            var correctionPosition = new OverlayTransform
            {
                LocalPosition = new Vector3(
                    annotationPosition.x +
                    LetterWidth * 10 * ((float) (spellingMistake.TextEnd - spellingMistake.TextStart) / 2),
                    annotationPosition.y,
                    annotationPosition.z + LetterHeight + 0.15f
                ),
                LocalScale = new Vector3(
                    (spellingMistake.SuggestedCorrection.Length) * LetterWidth, DefaultYScale, LetterHeight)
            };

            return correctionPosition;
        }
    }
}