using AutoMapper;
using MMP.Application.ViewModels;
using MMP.Domain.Models.Classes;

namespace MMP.Application.AutoMapper
{
    public class  AutoMapperConfig : Profile
    {
        public  AutoMapperConfig()
        {
            CreateMap<ClassType, ClassTypeViewModel>().ReverseMap();
            CreateMap<Class, ClassViewModel>().ReverseMap();
            CreateMap<Venue, VenueViewModel>().ReverseMap();
        }
    }
}