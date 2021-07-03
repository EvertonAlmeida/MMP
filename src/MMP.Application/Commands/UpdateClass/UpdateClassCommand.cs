using System;
using MediatR;

namespace MMP.Application.Commands.UpdateClass
{
    public record UpdateClassCommand(
        Guid Id,
        string Title,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        bool Free,
        decimal Value,
        string CompanyName,
        Guid ClassTypeId,
        UpdateVenueCommand VenueCommand
        ) : IRequest<bool>;

    public record UpdateVenueCommand(
        Guid VenueId,
        string Name,
        string Address,
        bool Online,
        string Url,
        string ContactNumber
    );
}