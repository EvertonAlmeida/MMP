using System;
using MediatR;
using MMP.Application.ViewModels;

namespace MMP.Application.Queries.GetClassTypeById
{
    public record GetClassTypeByIdQuery(Guid id) : IRequest<ClassTypeViewModel>;  
}