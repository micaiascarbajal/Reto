using Reto.DTOs;
using Reto.Models;

namespace Reto.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetProductsAsync();
        Task<Product> CreateProductsAsync(ProductDTO productDTO);
    }
}