using AutoMapper;
using GreatStore.Data.Models;
using GreatStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Service.MapperProfiles
{
    public class StockMapperProfile : Profile
    {
        public StockMapperProfile()
        {
            CreateMap<ItemVM, Item>();
            CreateMap<Item, ItemVM>();
        }
    }
}
