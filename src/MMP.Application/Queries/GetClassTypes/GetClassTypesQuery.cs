using System.Collections.Generic;
using MediatR;
using MMP.Application.ViewModels;

namespace MMP.Application.Queries.GetClassTypes
{
    public record GetClassTypesQuery() : IRequest<IEnumerable<ClassTypeViewModel>>;  
}