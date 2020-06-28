using SuperStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Core.Interfaces
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item, int itemId);
        Task DeleteItemAsync(int itemId);
        Task<Item> GetItemByIdAsync(int itemId);
        Task GetItemsAsync();
    }
}
