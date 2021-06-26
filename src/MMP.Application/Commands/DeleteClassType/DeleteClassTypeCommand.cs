using System;
using MediatR;

namespace MMP.Application.Commands.DeleteClassType
{
    public record DeleteClassTypeCommand(Guid Id) : IRequest<bool>;  
}