using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Components
{
    public interface ITextExtractor
    {
        Task<IEnumerable<string>> ExtractAsync();
    }
}
