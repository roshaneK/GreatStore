using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Models
{
    public class ShoppingCartVM
    {
        public Guid Id { get; set; }
        public List<ItemVM> Items { get; set; }
        public decimal TotalBill { get; set; }
        public Guid CouponId { get; set; }
    }
}
