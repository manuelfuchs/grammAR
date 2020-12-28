using System;
using System.Collections.Generic;

namespace Assets.Scripts.Components
{
    public interface ITextExtractor
    {
        event Action<IEnumerable<string>> OnTextFound;
    }
}