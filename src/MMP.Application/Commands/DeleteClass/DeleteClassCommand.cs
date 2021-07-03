using System;
using MediatR;

namespace MMP.Application.Commands.DeleteClass
{
    public record DeleteClassCommand(Guid Id) : IRequest<bool>;  
}