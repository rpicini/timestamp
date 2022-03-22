using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timestamp.App.Stock.Entity;
using Timestamp.App.Stock.Interface;

namespace Timestamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ApiController
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (ValidModelState())
            {
                await _stockService.InsertAsync(product);
                return Created("[Controller]/Id", product);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("GetProduct/{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            return Ok(await _stockService.GetByIdAsync(Id));
        }

        [HttpDelete]
        [Route("Delete/{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            await _stockService.DeleteAsync(Id);
            return Ok();

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Product product)
        {
            if (ValidModelState())
            {
                await _stockService.UpdateAsync(id, product);
                return Accepted();
            }
            return BadRequest();
        }
    }
}
