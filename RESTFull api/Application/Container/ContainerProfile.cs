using AutoMapper;
using Domain;

namespace Application
{
    public class ContainerProfile : Profile
    {
        public ContainerProfile()
        {
            CreateMap<Container, ContainerViewModel>();
        }
    }
}