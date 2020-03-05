using AutoMapper;
using GreatStore.Contracts.DataContracts;
using GreatStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Service
{
    public class CashRegisterService
    {
        private readonly IMapper mapper;
        private IStockData stockData;
        private ResultVM result = null;

        public CashRegisterService(IMapper mapper, IStockData stockData)
        {
            this.mapper = mapper;
            this.stockData = stockData;
            result = new ResultVM();
        }

        /// <summary>
        /// Add an item to the cart
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="buyerQuantity"></param>
        /// <param name="pounds"></param>
        public ResultVM AddItemToCart(ushort itemId, ushort buyerQuantity, double pounds = 0)
        {
            var ResultVM = new ResultVM();
            try
            {
                var stock = groceryManager.GetGroceryStock();
                var stockItem = stock.Items.Find(i => i.Id == itemId);
                if (stockItem != null && stockItem.StockQuantity >= buyerQuantity)
                {
                    var buyerItem = new BuyerItem
                    {
                        Id = stockItem.Id,
                        Name = stockItem.Name,
                        PriceBy = stockItem.PriceBy,
                        SaleType = stockItem.SaleType,
                        Price = stockItem.Price,
                        Units = buyerQuantity,
                        Weight = pounds
                    };
                    buyerItem.FreeUnits = GetFreeItemCount(buyerItem);
                    buyerItem.Price = GetFinalItemPrice(buyerItem);
                    groceryManager.ReduceStockCount(buyerItem);
                    shoppingCart.Items.Add(buyerItem);
                    ResultVM.Message = Message.ItemAddedToCart;
                }
                else
                {
                    ResultVM.Message = Message.InsufficientItemQuantity;
                }
            }
            catch (Exception ex)
            {
                ResultVM.Message = Message.ItemNotAddedToCart;
                throw;
            }
            return ResultVM;
        }

        /// <summary>
        /// Remove an item which is in the cart
        /// </summary>
        /// <param name="itemId"></param>
        public ResultVM RemoveItemFromCart(ushort itemId)
        {
            var ResultVM = new ResultVM();
            try
            {
                var itemToBeRemoved = shoppingCart.Items.Find(i => i.Id == itemId);
                if (itemToBeRemoved != null)
                {
                    shoppingCart.Items.Remove(itemToBeRemoved);
                    ResultVM.Message = Message.ItemRemovedFromCart;
                }
                else
                {
                    ResultVM.Message = Message.ItemNotRemovedFromCart;
                }
            }
            catch (Exception ex)
            {
                ResultVM.Message = Message.ItemNotRemovedFromCart;
                throw;
            }
            return ResultVM;
        }

        /// <summary>
        /// Finish shopping and get the total bill
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        public GroceryBill FinishShopping(ShoppingCart shoppingCart)
        {
            try
            {
                var bill = new GroceryBill
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    ItemsBought = shoppingCart.Items
                };
                foreach (var item in shoppingCart.Items)
                {
                    bill.TotalBill = bill.TotalBill + item.Price;
                }
                var coupon = CheckCouponEligibility(bill.TotalBill);
                if (coupon != null)
                {
                    bill.Coupon = coupon;
                    bill.FinalTotal = bill.TotalBill - coupon.CouponBonus;
                    bill.YouSaved = coupon.CouponBonus;
                }
                return bill;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Check if the total bill is equal or higher than the coupon requirements
        /// </summary>
        /// <param name="totalBillAmmount"></param>
        /// <returns>Coupon</returns>
        private Coupon CheckCouponEligibility(decimal totalBillAmmount)
        {
            /*Coupon types:
             * 1. $5 off when you spend $100 or more
             * 2. $10 off when you spend $150 or more
             * 3. $15 off when you spend $200 or more
             */
            Coupon coupon = null;
            if (totalBillAmmount >= 100)
            {
                coupon = new Coupon
                {
                    Id = Guid.NewGuid(),
                    ExpiryDate = DateTime.Now.AddDays(30),
                    CouponBonus = 5
                };

                if (totalBillAmmount >= 200)
                {
                    coupon.CouponBonus = 15;
                }
                else if (totalBillAmmount >= 150)
                {
                    coupon.CouponBonus = 10;
                }
            }
            return coupon;
        }

        /// <summary>
        /// Get the final price of the item or item bulk by reducing the free item count
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private decimal GetFinalItemPrice(BuyerItem item)
        {
            try
            {
                decimal finalPrice = 0;
                if (item.PriceBy == PriceBy.Unit)
                {
                    finalPrice = (item.Units - item.FreeUnits) * item.Price;
                }
                else
                {
                    finalPrice = (decimal)item.Weight * item.Price;
                }
                return finalPrice;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Check if the item is on sale
        /// </summary>
        /// <param name="item"></param>
        /// <param name="buyerQuantity"></param>
        /// <returns>No of items that the buyer can get free</returns>
        private ushort GetFreeItemCount(BuyerItem item)
        {
            ushort freeItemCount = 0;
            try
            {
                if (item.SaleType != SaleType.None)
                {
                    var sale = item.SaleType.ToString().Split("_");
                    var haveToBuy = ushort.Parse(sale[1]);
                    var willGetFree = ushort.Parse(sale[3]);
                    if (item.Units >= haveToBuy)
                    {
                        freeItemCount = willGetFree;
                    }
                }
                return freeItemCount;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
