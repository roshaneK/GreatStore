using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Models
{
    public enum Message
    {
        //Success messages: 1000-1999
        ItemAdded = 1000,     
        ItemUpdated = 1001,
        ItemRemoved = 1002,
        StockQtyAdded = 1003, 
        StockQtyReduced = 1004,
        ItemAddedToCart = 1005, 
        ItemRemovedFromCart = 1006,

        //Error messages: 2000-2999
        ErrorAddingItem = 2000,
        ErrorUpdatingItem = 2001, 
        ErrorRemovingItem = 2002,
        ErrorGettingItem = 2003,
        ErrorAddingStockQty = 2004, 
        ErrorReducingStockQty = 2005,
        ErrorItemAddingToCart = 2006, 
        ErrorItemRemovingFromCart = 2007,

        //General Messages: 3000-3999
        ItemAlreadyExists = 3000,
        ItemNotExists = 3001,
        ItemFound = 3002,

    }
}
