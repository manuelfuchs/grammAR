using Assets.Scripts.Types;

namespace Assets.Scripts.Components.OverlayPositionCalculator
{
    public interface IOverlayPositionCalculator
    {
        OverlayTransform CalculateOverlayPosition(TextPosition textPosition);
        OverlayTransform CalculateCorrectionOverlayPosition(SpellingMistake spellingMistake);
    }
}