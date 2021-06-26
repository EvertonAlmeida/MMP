using System;
using MediatR;

namespace MMP.Application.Commands.UpdateClassType
{
    public record UpdateClassTypeCommand(Guid Id, string Title) : IRequest<bool>;  
}