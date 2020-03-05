using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatStore.Contracts.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreatStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashRegisterController : ControllerBase
    {
        private IStockService stockService;
        public CashRegisterController(IStockService stockService)
        {
            this.stockService = stockService;
        }


    }
}