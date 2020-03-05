using GreatStore.Contracts.DataContracts;
using GreatStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreatStore.Data.StockDataLayer
{
    public class StockData : IStockData
    {
        private StoreDbContext StoreDbContext;

        public StockData(StoreDbContext storeDbContext)
        {
            StoreDbContext = storeDbContext;
        }

        public Item GetItemByCode(uint code)
        {
            try
            {
                return StoreDbContext.Items.Where(i => i.Code == code).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsItemExists(Item item)
        {
            try
            {
                var exsistingItem = StoreDbContext.Items.Where(i => i.Code == item.Code || i.Name == item.Name).FirstOrDefault();
                if (exsistingItem != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddItem(Item item)
        {
            try
            {   
                StoreDbContext.Items.Add(item);
                StoreDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

        //Batch processing test 
        public void AddItems(List<Item> items)
        {
            try
            {
                StoreDbContext.Items.AddRange(items);
                StoreDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateItem(Item item)
        {
            try
            {
                StoreDbContext.Items.Update(item);
                StoreDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RemoveItem(Item item)
        {
            try
            {
                StoreDbContext.Items.Remove(item);
                StoreDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
