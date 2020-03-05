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

        [HttpGet("GetItemByCode")]
        public IActionResult GetItemByCode(uint code)
        {
            var result = stockService.GetItemByCode(code);
            return Ok(result);
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(ItemVM  item)
        {
            var result = stockService.AddItem(item);
            return Ok(result);
        }

        [HttpPost("UpdateItem")]
        public IActionResult UpdateItem(ItemVM item)
        {
            var result = stockService.UpdateItem(item);
            return Ok(result);
        }

        [HttpPost("DeleteItem")]
        public IActionResult DeleteItem(uint code)
        {
            var result = stockService.RemoveItem(code);
            return Ok(result);
        }

        [HttpPost("AddStockAsUints")]
        public IActionResult AddStockAsUints(uint code, long units)
        {
            var result = stockService.AddStockAsUints(code, units);
            return Ok(result);
        }
    }
}