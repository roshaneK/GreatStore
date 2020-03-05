﻿using GreatStore.Models;
using System;

namespace GreatStore.Contracts.ServiceContracts
{
    public interface IStockService
    {
        ResultVM GetItemByCode(uint code);
        ResultVM AddItem(ItemVM itemVM);
        ResultVM UpdateItem(ItemVM itemVM);
        ResultVM RemoveItem(uint code);
        ResultVM AddStockAsUints(uint code, long units);
        ResultVM ReduceStockAsUnits(uint code, long units);
        
    }
}
