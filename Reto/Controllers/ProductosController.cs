using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reto.Data;
using Reto.DTOs;
using Reto.Models;
using Reto.Repositories.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reto.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly RetoDbContext _retoDbContext;
        private static HttpClient _httpClient = new HttpClient();

        public ProductosController(IProductRepository productRepository, RetoDbContext _retoDbContext)
        {
            _productRepository = productRepository;
            _retoDbContext = _retoDbContext;
        }

        [HttpGet]
        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var car = await _retoDbContext.Products.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProductsAsync(ProductDTO productDTO)
        {
            var product = await _productRepository.CreateProductsAsync(productDTO);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }


        [HttpGet("get-data-from-api")]
        public async Task<ActionResult<List<TitleData>>> GetDataFromAPI()
        {
            var result = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
            var jsonResult = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<TitleData>>(jsonResult);
        }


    }
}
