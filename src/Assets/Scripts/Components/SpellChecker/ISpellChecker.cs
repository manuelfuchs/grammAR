using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.SpellChecker
{
    public interface ISpellChecker
    {
        event Action<IEnumerable<SpellingMistake>> OnMistakesFound;
    }
}
