using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Entities.Dtos.Sales;
using Sales.Entities.Sales;
using Sales.Services.Sales;

namespace Sales.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService) {
            _salesService = salesService;
        }

        /// <summary>
        /// Get all sales.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                var res = _salesService.GetAllSales();
                if(res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        /// <summary>
        /// Add a new sale.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Sale))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] CreateSaleDto saleDto)
        {
            if(!ModelState.IsValid || saleDto == null)
            {
                return BadRequest(ModelState);
            }   
            try
            {
                if (!_salesService.PostSale(saleDto))
                    return StatusCode(503, "Internal server error, please contact support");
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        /// <summary>
        /// Get an specific sale.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetSale")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSale(int id)
        {
            try
            {
                var res = _salesService.GetSale(id);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }
    }
}
