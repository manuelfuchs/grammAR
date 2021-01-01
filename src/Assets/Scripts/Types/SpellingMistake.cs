using JetBrains.Annotations;

namespace Assets.Scripts.Types
{
    [System.Serializable]
    public class SpellingMistake : TextPosition
    {
        public SpellingMistake(int line, int textStart, int textEnd, SpellingSeverity severity) : base(line, textStart,
            textEnd)
        {
            Severity = severity;
        }

        public SpellingMistake(int line, int textStart, int textEnd, SpellingSeverity severity,
            string suggestedCorrection) : base(line, textStart, textEnd)
        {
            this.Severity = severity;
            this.SuggestedCorrection = suggestedCorrection;
        }

        public SpellingSeverity Severity { get; }

        [CanBeNull] public string SuggestedCorrection { get; }
    }
}