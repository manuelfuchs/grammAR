using System.Collections.Generic;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.CurseWordFilter
{
    public interface ICurseWordFilter
    {
        IEnumerable<CurseWord> FindCurseWords(IEnumerable<string> text, Language language);
    }
}