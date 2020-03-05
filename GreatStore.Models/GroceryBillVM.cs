using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Models
{
    public class GroceryBillVM
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<ItemVM> ItemsBought { get; set; }
        public Coupon Coupon { get; set; }
        public decimal TotalBill { get; set; }
        public decimal YouSaved { get; set; }
        public decimal FinalTotal { get; set; }
    }
}
