using SuperStore.Core.Entities;
using SuperStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Core.Services
{
    public class StoreService : IStoreService
    {
        private readonly IAsyncRepository<Store> _storeRepository;
        public StoreService(IAsyncRepository<Store> storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task<Store> CreateStoreAsync(Store store)
        {
            return await _storeRepository.AddAsync(store);
        }

        public async Task DeleteStoreAsync(int storeId)
        {
            var store = await _storeRepository.GetByIdAsync(storeId);
            await _storeRepository.DeleteAsync(store);
        }

        public async Task<Store> GetStoreByIdAsync(int storeId)
        {
            return await _storeRepository.GetByIdAsync(storeId);
           
        }

        public async Task<IReadOnlyList<Store>> GetStoresAsync()
        {
            var result = await _storeRepository.ListAllAsync();
            return result;
        }

        public async Task UpdateStoreAsync(Store store,int storeId)
        {
            var storeEntity = await _storeRepository.GetByIdAsync(storeId);
            storeEntity.Name = store.Name;
            storeEntity.Description = store.Description;

            await _storeRepository.UpdateAsync(storeEntity);
        }
    }
}
