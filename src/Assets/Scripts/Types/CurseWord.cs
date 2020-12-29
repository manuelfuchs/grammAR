namespace Assets.Scripts.Types
{
    public class CurseWord : TextPosition
    {
        public CurseWord(int line, int textStart, int textEnd, CurseWordSeverity curseWordSeverity) :
            base(line, textStart, textEnd)
        {
            CurseWordSeverity = curseWordSeverity;
        }

        public CurseWordSeverity CurseWordSeverity { get; }
    }
}