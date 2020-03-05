using System;

namespace GreatStore.Models
{
    public class ItemVM
    {
        public Guid Id { get; set; }
        public uint Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
