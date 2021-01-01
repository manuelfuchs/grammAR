namespace Assets.Scripts.Types
{
    [System.Serializable]
    public class TextPosition
    {
        public TextPosition(int line, int textStart, int textEnd)
        {
            Line = line;
            TextStart = textStart;
            TextEnd = textEnd;
        }

        public int Line { get; }
        public int TextStart { get; }
        public int TextEnd { get; }
    }
}