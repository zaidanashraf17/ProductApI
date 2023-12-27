using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Repos;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo productRepository;

        public ProductsController(IProductRepo productRepoy)
        {
            productRepository = productRepoy;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                var product = productRepository.GetProductById(productId);

                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("byname/{productName}")]
        public IActionResult GetProductsByName(string productName)
        {
            try
            {
                var products = productRepository.GetProductsByName(productName);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Products product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Invalid product data.");
                }

                productRepository.AddProduct(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] Products updatedProduct)
        {
            try
            {
                var existingProduct = productRepository.GetProductById(productId);

                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                productRepository.UpdateProduct(productId, updatedProduct);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var existingProduct = productRepository.GetProductById(productId);

                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                productRepository.DeleteProduct(productId);
                return Ok(productId + "deleted succesfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
