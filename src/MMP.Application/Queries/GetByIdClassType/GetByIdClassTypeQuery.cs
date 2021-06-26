using System;
using MediatR;
using MMP.Application.ViewModels;

namespace MMP.Application.Queries.GetByIdClass
{
    public record GetByIdClassTypeQuery(Guid id) : IRequest<ClassTypeViewModel>;  
}