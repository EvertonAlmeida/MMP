using System.Collections.Generic;
using MediatR;
using MMP.Application.ViewModels;

namespace MMP.Application.Queries.GetClasses
{
    public record GetClassesQuery() : IRequest<IEnumerable<ClassViewModel>>;  
}