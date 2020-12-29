namespace Assets.Scripts.Types
{
    public class SpellingMistake
    {
        public SpellingMistake(int line, int errorStart, int errorEnd, SpellingSeverity severity, string suggestedCorrection)
        {
            this.Line = line;
            this.ErrorStart = errorStart;
            this.ErrorEnd = errorEnd;
            this.Severity = severity;
            this.SuggestedCorrection = suggestedCorrection;
        }

        public int Line
        {
            get;
        }

        public int ErrorStart
        {
            get;
        }

        public int ErrorEnd
        {
            get;
        }

        public SpellingSeverity Severity
        {
            get;
        }

        public string SuggestedCorrection
        {
            get;
        }
    }
}
