using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InventorySystem.Services
{
    public class BoxService : IBoxService
    {
        InventorySystemDb _db = new InventorySystemDb();

        public BoxCreateViewModel CreateBox()
        {
            var viewModel = new BoxCreateViewModel
            {
                Categories = _db.Categories.ToList()
            };
            return viewModel;
        }

        public Box CreateBox(BoxCreateViewModel viewModel)
        {
            var box = new Box
            {
                Label = viewModel.Label,
                Capacity = viewModel.Capacity,
                CategoryId = viewModel.CategoryId
            };

            _db.Boxes.Add(box);
            _db.SaveChanges();

            return box;
        }

        public BoxItemsViewModel DetailsBox(int id)
        {
            Box box = GetBox(id);
            var items = box.Items.ToList();
            return new BoxItemsViewModel(box, items);
        }

        public BoxEditViewModel EditBox(int id)
        {
            var box = GetBox(id);
            var viewModel = new BoxEditViewModel
            {
                Id = box.Id,
                Label = box.Label,
                Capacity = box.Capacity,
                CategoryId = box.CategoryId,
                Categories = _db.Categories.ToList()
            };
            return viewModel;
        }

        public void EditBox(BoxEditViewModel viewModel)
        {
            var box = GetBox(viewModel.Id);

            box.Label = viewModel.Label;
            box.CategoryId = viewModel.CategoryId;
            box.Capacity = viewModel.Capacity;

            _db.Entry(box).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public Box GetBox(int id)
        {
            return _db.Boxes.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Box> GetBoxes()
        {
            return _db.Boxes.ToList();
        }

        public void RemoveBox(int id)
        {
            var box = GetBox(id);
            _db.Boxes.Remove(box);
            _db.SaveChanges();
        }
    }
}