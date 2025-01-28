using AutomapperDemo.DTOs;
using AutomapperDemo.Models;
using AutoMapper;

namespace AutomapperDemo.AutomapperMappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // Map Product to ProductDTO (for customers)
            // Source: Product and Destination: ProductDTO
            CreateMap<Product, ProductDTO>()
                //Provide Mapping Configuration between ProductName and Name Property
                .ForMember(dest => dest.ProductName, act => act.MapFrom(src => src.Name))

                //Provide Mapping Configuration between ShortDescription and Description Property
                .ForMember(dest => dest.ShortDescription, act => act.MapFrom(src => src.Description));

            // Map ProductCreateDTO to Product (for adding new product)
            // Source: ProductCreateDTO and Destination: Product
            CreateMap<ProductCreateDTO, Product>();
        }
    }
}