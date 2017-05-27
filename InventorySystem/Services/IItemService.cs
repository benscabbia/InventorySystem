using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.Services
{
    public interface IItemService
    {
        IOrderedQueryable<Item> GetItemsOrderedByName();
        IQueryable<Item> GetItemsSearch(string searchTerm, string searchStatus, int numberOfResults = 20);
        IList<ItemAndBoxViewModel> GetItemsAndBoxSearch(string searchTerm, string searchStatus, int numberOfResults = 20);
        Item GetItem(int id);
        ItemCreateViewModel CreateItem(int boxId = 0);
        Item CreateItem(ItemCreateViewModel viewModel);
        ItemEditViewModel EditItem(int id);
        void EditItem(ItemEditViewModel viewModel);
        Item DeleteItem(int id);
        void DeleteItemConfirmed(int id);

    }
}