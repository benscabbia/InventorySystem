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
                        CategoryId = viewModel.CategoryId,
                        EbayUrl = ebayItem.Item.ListingDetails.ViewItemURL,
                        Description = ebayItem.Item.Description,
                        Price = Convert.ToDecimal(ebayItem.Item.ListingDetails.ConvertedStartPrice.Value) //item.startprice.value

                        /*
                         
                            //condition describe ebayItem.Item.ConditionDescription

                            //startime, endtime to be, ebayItem.Item.ListingDetail
                            // location mums vs camb
                            // number of views
                            //item.TimeLeft; Time left before the listing ends. The duration is represented in the ISO 8601 duration format (PnYnMnDTnHnMnS). See Data Types in the Trading API Guide for information about this format. For ended listings, the time left is PT0S (zero seconds).

                            //picture details url i.e. item.PictureDetails.GalleryURL
                            // or PictureDetails.PictureURL.InnerList [array of image URL's]

                            //ListingType i.e. FixedPriceItem -> maybe dynamic and get relevant values?

                            //shipping cost item.shippingdetails.shippingserviceoptions
                            //if shippingserveroptions.count > 0, shippingserveroptions.list[0].shippingservicecost.value

                            //watch count
                         
                         */

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