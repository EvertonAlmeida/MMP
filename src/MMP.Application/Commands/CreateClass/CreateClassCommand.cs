using System;
using MediatR;
using MMP.Application.ViewModels;

namespace MMP.Application.Commands.CreateClass
{
    public record CreateClassCommand(
        string Title,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        bool Free,
        decimal Value,
        string CompanyName,
        Guid ClassTypeId,
        CreateVenueCommand VenueCommand
        ) : IRequest<bool>;

    public record CreateVenueCommand(
        Guid VenueId,
        string Name,
        string Address,
        bool Online,
        string Url,
        string ContactNumber
    );
}