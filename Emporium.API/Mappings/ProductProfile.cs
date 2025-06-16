using AutoMapper;
using Emporium.Application.DTO;
using Emporium.Domain.Entities;

namespace Emporium.API.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));
    }
}
