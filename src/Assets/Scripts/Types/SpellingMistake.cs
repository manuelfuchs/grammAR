namespace Assets.Scripts.Types
{
    public class SpellingMistake : TextPosition
    {
        public SpellingMistake(int line, int textStart, int textEnd, SpellingSeverity severity,
            string suggestedCorrection) : base(line, textStart, textEnd)
        {
            this.Severity = severity;
            this.SuggestedCorrection = suggestedCorrection;
        }

        public SpellingSeverity Severity { get; }

        public string SuggestedCorrection { get; }
    }
}