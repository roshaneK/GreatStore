using GreatStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Contracts.DataContracts
{
    public interface IStockData
    {
        public void AddItem(Item item);
    }
}
