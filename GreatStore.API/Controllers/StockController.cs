using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatStore.Contracts.ServiceContracts;
using GreatStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreatStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockService stockService;
        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpPost("AddItem")]
        public IActionResult SaveUser(ItemVM  item)
        {
            var result = stockService.AddItem(item);
            return Ok(result);
        }
    }
}