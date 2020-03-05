using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreatStore.Data.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public uint Code { get; set; }
        public string Name { get; set; }
        public long Units { get; set; }
        public bool PriceByUnit { get; set; }
        public double Price { get; set; }
    }
}
