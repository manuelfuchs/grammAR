using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Components.TextExtractor
{
    public interface ITextExtractor
    {
        Task<IEnumerable<string>> ExtractAsync();
    }
}
