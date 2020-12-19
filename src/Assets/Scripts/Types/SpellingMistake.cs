namespace Assets.Scripts.Types
{
    public class SpellingMistake
    {
        public SpellingMistake(int line, int errorStart, int errorEnd, SpellingSeverity severity, string suggestedCorrection)
            => (this.Line, this.ErrorStart, this.ErrorEnd, this.Severity, this.SuggestedCorrection) = (line, errorStart, errorEnd, severity, suggestedCorrection);

        public int Line { get; }

        public int ErrorStart { get; }

        public int ErrorEnd { get; }

        public SpellingSeverity Severity { get; }

        public string SuggestedCorrection { get; }
    }
}
