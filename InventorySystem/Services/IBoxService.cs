using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using System.Collections.Generic;

namespace InventorySystem.Services
{
    public interface IBoxService
    {
        IEnumerable<Box> GetBoxes();
        Box GetBox(int id);
        BoxEditViewModel EditBox(int id);
        void EditBox(BoxEditViewModel viewModel);
        Box CreateBox(BoxCreateViewModel viewModel);
        BoxCreateViewModel CreateBox();
        void RemoveBox(int id);

        BoxItemsViewModel DetailsBox(int id);
    }
}