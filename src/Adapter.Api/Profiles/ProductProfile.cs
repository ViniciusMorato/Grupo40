using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;

namespace Adapter.Api.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<AddProductDto, Produto>();
        CreateMap<Produto, AddProductDto>();
        CreateMap<ProductDto, Produto>();
        CreateMap<Produto, ProductDto>();
        CreateMap<Produto, UpdateProductDto>();
        CreateMap<UpdateProductDto, Produto>();
    }
}