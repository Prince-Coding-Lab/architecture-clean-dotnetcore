using SuperStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Core.Interfaces
{
    public interface IStoreService
    {
        Task<Store> CreateStoreAsync(Store store);
        Task UpdateStoreAsync(Store store, int storeId);
        Task DeleteStoreAsync(int storeId);
        Task<Store> GetStoreByIdAsync(int storeId);
        Task GetStoresAsync();
    }
}
