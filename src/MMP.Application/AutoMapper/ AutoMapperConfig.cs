using AutoMapper;
using MMP.Application.Commands.CreateClass;
using MMP.Application.Commands.CreateClassType;
using MMP.Application.Commands.UpdateClassType;
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

            CreateMap<ClassTypeViewModel, CreateClassTypeCommand>();
            CreateMap<ClassTypeViewModel, UpdateClassTypeCommand>();

            CreateMap<ClassViewModel, CreateClassCommand>()
                .ConstructUsing(c => new CreateClassCommand(
                    c.Title, c.Description, c.StartDate, c.EndDate,
                    c.Free, c.Value, c.CompanyName, c.ClassTypeId,
                    new CreateVenueCommand(
                        c.Venue.Id, c.Venue.Name, c.Venue.Address, 
                        c.Venue.Online, c.Venue.Url, c.Venue.ContactNumber)
                )
            );
        }
    }
}