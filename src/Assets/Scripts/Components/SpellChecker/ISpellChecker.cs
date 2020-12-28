using Assets.Scripts.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Components
{
    public interface ISpellChecker
    {
        Task<IEnumerable<SpellingMistake>> GetMistakes(IEnumerable<string> text);
    }
}
