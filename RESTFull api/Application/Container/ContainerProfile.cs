using System.Linq;
using AutoMapper;
using Domain;

namespace Application
{
    public class ContainerProfile : Profile
    {
        public ContainerProfile()
        {
            CreateMap<Container, ContainerViewModel>()
                .ForMember(src => src.Products, opt => opt.MapFrom(x => x.Products));
        }
    }
}