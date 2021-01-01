using System;
using System.Collections.Generic;

namespace Assets.Scripts.Components.TextExtractor
{
    public interface ITextExtractor
    {
        event Action<IEnumerable<string>> OnTextFound;
        event Action OnTextLost;
    }
}