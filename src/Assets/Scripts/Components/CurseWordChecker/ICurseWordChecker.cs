using System;
using System.Collections.Generic;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.CurseWordChecker
{
    public interface ICurseWordChecker
    {
        event Action<IEnumerable<CurseWord>> OnCurseWordsExtracted;
    }
}