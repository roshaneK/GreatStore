using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Models
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ushort CouponBonus { get; set; }
    }
}
