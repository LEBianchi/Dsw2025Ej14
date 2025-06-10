using Dsw2025Ej14.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IPersistenciaEnMemoria _persistencia;

        public ProductsController(IPersistenciaEnMemoria persistencia)
        {
            _persistencia = persistencia;
        }
        [HttpGet()]

        public IActionResult GetProducts()
        {

            return Ok(_persistencia.GetProducts());
        }
        [HttpGet("{sku}")]
        public IActionResult GetProduct(string sku)
        {
            var products = _persistencia.GetProducts();
            if (products == null) return NotFound();
            return Ok(_persistencia?.GetProduct(sku));
        }
    }
}