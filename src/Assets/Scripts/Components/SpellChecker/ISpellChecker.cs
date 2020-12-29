using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.SpellChecker
{
    public interface ISpellChecker
    {
        Task<IEnumerable<SpellingMistake>> GetMistakes(IEnumerable<string> text);
    }
}
