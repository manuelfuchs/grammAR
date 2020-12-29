using Assets.Scripts.Types;

namespace Assets.Scripts.Components.OverlayPositionCalculator
{
    public interface IOverlayPositionCalculator
    {
        OverlayTransform CalculateMistakeOverlayPosition(SpellingMistake spellingMistake);
        OverlayTransform CalculateCorrectionOverlayPosition(SpellingMistake spellingMistake);
    }
}