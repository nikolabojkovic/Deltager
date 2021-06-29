using AutoMapper;
using Domain;

namespace Application
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductPackage, ProductPackageViewModel>()
                .ForMember(src => src.Id, opt => opt.MapFrom(x => x.Product.Id))
                .ForMember(src => src.Name, opt => opt.MapFrom(x => x.Product.Name))
                .ForMember(src => src.Type, opt => opt.MapFrom(x => x.Product.Type))
                .ForMember(src => src.ProductPackageId, opt => opt.MapFrom(x => x.Id));
            CreateMap<Product, ProductViewModel>();
        }
    }
}