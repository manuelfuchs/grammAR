using Assets.Scripts.Types;
using System.Collections.Generic;

namespace Assets.Scripts.Components
{
    public interface ISpellChecker
    {
        IEnumerable<SpellingMistake> GetMistakes(IEnumerable<string> text);
    }
}
