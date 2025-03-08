using AutoMapper;
using Reto.Models;
namespace Reto.DTOs
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() { 
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
