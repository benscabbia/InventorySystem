using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace InventorySystem.Services
{
    public class ItemService : IItemService
    {
        InventorySystemDb _db = new InventorySystemDb();

        public ItemCreateViewModel CreateItem()
        {
            var model = new ItemCreateViewModel
            {
                Categories = _db.Categories.ToList(),
                Boxes = _db.Boxes.ToList()
            };

            return model;
        }

        public Item CreateItem(ItemCreateViewModel viewModel)
        {
            Item item;
            try
            {
                var ebayItem = EbayAPI.GetEbayItem(viewModel.ItemNumber);

                if (!ebayItem.HasError)
                {
                    item = new Item
                    {
                        ItemNumber = ebayItem.Item.ItemID,
                        Name = ebayItem.Item.Title,
                        BoxId = viewModel.BoxId,
                        Size = viewModel.Size,
                        //Location = null,
                        CategoryId = viewModel.CategoryId,
                        EbayUrl = ebayItem.Item.ListingDetails.ViewItemURL,
                        Description = ebayItem.Item.Description,
                        Price = Convert.ToDecimal(ebayItem.Item.ListingDetails.ConvertedStartPrice.Value),
                        ShippingServiceCost = ebayItem.Item.ShippingDetails.ShippingServiceOptions[0].ShippingServiceCost.Value,
                        HitCount = ebayItem.Item.HitCount,
                        GalleryURL = ebayItem.Item.PictureDetails.GalleryURL,
                        PictureURL = ebayItem.Item.PictureDetails.PictureURL.ToArray(),
                        WatchCount = ebayItem.Item.WatchCount,
                        StartTime = ebayItem.Item.ListingDetails.StartTime,
                        EndTime = ebayItem.Item.ListingDetails.EndTime,
                    };
                    _db.Items.Add(item);
                    _db.SaveChanges();
                    return item;
                }
                throw new NullReferenceException("EbayItem has an error.ItemNumber=[" + ebayItem.Item.ItemID + "], if empty, item could not be found");

            }
            catch (ArgumentException E)
            {
                throw E;
            }
            catch (NullReferenceException E)
            {
                throw E;
            }
            catch (Exception E)
            {
                throw E;
            }



        }

        public Item DeleteItem(int id)
        {
            return GetItem(id);
        }

        public void DeleteItemConfirmed(int id)
        {
            _db.Items.Remove(GetItem(id));
            //_db.Entry(item).State = EntityState.Delete;  
            _db.SaveChanges();
        }

        public void EditItem(ItemEditViewModel viewModel)
        {
            var item = GetItem(viewModel.Id);
            item.BoxId = viewModel.BoxId;
            item.CategoryId = viewModel.CategoryId;
            item.Size = viewModel.Size;

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

        }

        public ItemEditViewModel EditItem(int id)
        {
            var item = GetItem(id);
            var model = new ItemEditViewModel
            {
                Id = item.Id,
                Name = item.Name,
                BoxId = item.BoxId,
                Boxes = _db.Boxes.ToList(),
                CategoryId = item.CategoryId,
                Categories = _db.Categories.ToList(),
                ItemNumber = item.ItemNumber,
                Size = item.Size
            };
            return model;
        }

        public Item GetItem(int id)
        {
            return _db.Items.Where(i => i.Id == id).Single();
        }

        public IOrderedQueryable<Item> GetItemsOrderedByName()
        {
            return _db.Items.OrderBy(i => i.Name);
        }

        public IQueryable<Item> GetItemsSearch(string searchTerm, int numberOfResults = 20)
        {
            var model = _db.Items.OrderBy(i => i.Name)
                        .Where(
                            i => searchTerm == null ||
                            i.Name.Contains(searchTerm) ||
                            i.ItemNumber.Contains(searchTerm) ||
                            i.Description.Contains(searchTerm)
                        ).Take(numberOfResults);

            return model;
        }
    }
}