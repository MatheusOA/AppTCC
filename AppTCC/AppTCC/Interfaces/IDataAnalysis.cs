using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTCC.Interfaces
{
    public interface IDataAnalysis<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
