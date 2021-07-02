using System;
using MediatR;
using MMP.Application.ViewModels;

namespace MMP.Application.Queries.GetClassById
{
    public record GetClassByIdQuery(Guid id) : IRequest<ClassViewModel>;  
}