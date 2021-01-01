using System;
using System.Collections.Generic;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.CurseWordFilter
{
    public interface ICurseWordFilter
    {
        event Action<IEnumerable<CurseWord>> OnCurseWordsFound;
    }
}