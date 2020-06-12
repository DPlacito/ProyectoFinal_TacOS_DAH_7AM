
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppTacOSFinal.Services
{
    interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
