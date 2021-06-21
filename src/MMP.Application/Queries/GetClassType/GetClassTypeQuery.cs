using System.Collections.Generic;
using MediatR;
using MMP.Application.ViewModels;

namespace MMP.Application.Queries.GetClassType
{
    public record GetClassTypeQuery() : IRequest<IEnumerable<ClassTypeViewModel>>;  
}