using Assets.Scripts.Types;

namespace Assets.Scripts.Components.OverlayPositionCalculator
{
    public interface IOverlayPositionCalculator
    {
        OverlayTransform CalculateOverlayPosition(TextPosition textPosition);
        OverlayTransform CalculateCurseWordOverlay(CurseWord curseWord, bool showFirstLetter = true);
        OverlayTransform CalculateCorrectionOverlayPosition(SpellingMistake spellingMistake);
    }
}