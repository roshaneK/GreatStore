using AutoMapper;
using GreatStore.Contracts.DataContracts;
using GreatStore.Contracts.ServiceContracts;
using GreatStore.Data.Models;
using GreatStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Service
{
    public class StockService : IStockService
    {
        private readonly IMapper mapper;
        private IStockData stockData;
        private ResultVM result = null;

        public StockService(IMapper mapper, IStockData stockData)
        {
            this.mapper = mapper;
            this.stockData = stockData;
            result = new ResultVM();
        }

        public ResultVM GetItemByCode(uint code)
        {
            try
            {
                var item = stockData.GetItemByCode(code);                
                if (item != null)
                {
                    result.Message = Message.ItemFound;
                    result.Result = item;
                }
                else
                {
                    result.Message = Message.ItemNotExists;
                }
            }
            catch (Exception ex)
            {
                result.Message = Message.ErrorGettingItem;
            }
            return result;
        }

        public ResultVM AddItem(ItemVM itemVM)
        {
            try
            {
                var item = mapper.Map<Item>(itemVM);
                var itemExists = stockData.IsItemExists(item);
                if (!itemExists)
                {
                    stockData.AddItem(item);
                    result.Message = Message.ItemAdded;
                }
                else
                {
                    result.Message = Message.ItemAlreadyExists;
                }
            }
            catch (Exception ex)
            {
                result.Message = Message.ErrorAddingItem;
            }
            return result;
        }

        public ResultVM UpdateItem(ItemVM itemVM)
        {
            try
            {
                var item = mapper.Map<Item>(itemVM);
                var itemExists = stockData.IsItemExists(item);
                if (itemExists)
                {
                    stockData.UpdateItem(item);
                    result.Message = Message.ItemUpdated;
                }
                else
                {
                    result.Message = Message.ItemNotExists;
                }
            }
            catch (Exception ex)
            {
                result.Message = Message.ErrorUpdatingItem;
            }
            return result;
        }

        public ResultVM RemoveItem(uint code)
        {
            try
            {
                var result = GetItemByCode(code);
                if (result.Result != null)
                {
                    var item = mapper.Map<Item>(result.Result);
                    stockData.RemoveItem(item);
                    result.Message = Message.ItemRemoved;
                }
                else
                {
                    result.Message = Message.ItemNotExists;
                }
            }
            catch (Exception ex)
            {
                result.Message = Message.ErrorRemovingItem;
            }
            return result;
        }

        public ResultVM AddStockAsUints(uint code, long units)
        {
            try
            {
                var result = GetItemByCode(code);
                if (result.Result != null)
                {
                    var item = mapper.Map<Item>(result.Result);
                    item.Units = item.Units + units;
                    stockData.UpdateItem(item);
                    result.Message = Message.StockQtyAdded;
                }
                else
                {
                    result.Message = Message.ItemNotExists;
                }
            }
            catch (Exception ex)
            {
                result.Message = Message.ErrorAddingStockQty;
            }
            return result;
        }

        public ResultVM ReduceStockAsUnits(uint code, long units)
        {
            try
            {
                var result = GetItemByCode(code);
                if (result.Result != null)
                {
                    var item = mapper.Map<Item>(result.Result);
                    item.Units = item.Units - units;
                    stockData.UpdateItem(item);
                    result.Message = Message.StockQtyReduced;
                }
                else
                {
                    result.Message = Message.ItemNotExists;
                }
            }
            catch (Exception ex)
            {
                result.Message = Message.ErrorReducingStockQty;
            }
            return result;
        }
    }
}
