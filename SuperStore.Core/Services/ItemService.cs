using SuperStore.Core.Entities;
using SuperStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Core.Services
{
    public class ItemService : IItemService
    {
        private readonly IAsyncRepository<Item> _itemRepository;
        public ItemService(IAsyncRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<Item> CreateItemAsync(Item item)
        {
            return await _itemRepository.AddAsync(item);
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var store = await _itemRepository.GetByIdAsync(itemId);
            await _itemRepository.DeleteAsync(store);
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);
            return item;
        }

        public async Task GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateItemAsync(Item item, int itemId)
        {
            var itemEntity = await _itemRepository.GetByIdAsync(itemId);
            itemEntity.Name = item.Name;
            itemEntity.Description = item.Description;
            itemEntity.Price = item.Price;

            await _itemRepository.UpdateAsync(itemEntity);
        }
    }
}
