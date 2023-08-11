using AutoMapper;
using BoilerPlate.Authorization.Product;
using BoilerPlate.Product.Dto;

namespace BoilerPlate.Product
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<ProductDto, MyProduct>();
            CreateMap<CreateProductDto, MyProduct>();

        }


    }
}
