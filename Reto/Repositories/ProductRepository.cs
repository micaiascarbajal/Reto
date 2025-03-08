using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reto.Data;
using Reto.DTOs;
using Reto.Models;
using Reto.Repositories.Interfaces;

namespace Reto.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly RetoDbContext _retoDbContext;
        private readonly IMapper _mapper;

        public ProductRepository(RetoDbContext retoDbContext, IMapper mapper)
        {
            _retoDbContext = retoDbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            var products = await _retoDbContext.Products.ToListAsync();
            var productsDTO = _mapper.Map<List<ProductDTO>>(products);

            return productsDTO;
        }

        public async Task<Product> CreateProductsAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _retoDbContext.Products.Add(product);
            await _retoDbContext.SaveChangesAsync();
            return product;
        }


    }
}
