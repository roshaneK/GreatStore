using GreatStore.Contracts.DataContracts;
using GreatStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Data.StockDataLayer
{
    public class StockData : IStockData
    {
        private StoreDbContext StoreDbContext;

        public StockData(StoreDbContext storeDbContext)
        {
            StoreDbContext = storeDbContext;
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
    }
}
