using GreatStore.Models;
using System;

namespace GreatStore.Contracts.ServiceContracts
{
    public interface IStockService
    {
        public ResultVM AddItem(ItemVM item);
    }
}
