using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MMP.Application.ViewModels;
using MMP.Domain.Models.Classes.Repository;

namespace MMP.Application.Queries.GetClassTypes
{
    public class GetClassTypesHandler : IRequestHandler<GetClassTypesQuery, IEnumerable<ClassTypeViewModel>>  
    {  
        private readonly IClassTypeRepository _repository;  
        private readonly IMapper _mapper;
        public GetClassTypesHandler(IClassTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassTypeViewModel>> Handle(GetClassTypesQuery query, CancellationToken cancellationToken)  
        {  
            var result = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ClassTypeViewModel>>(result);
        }  
    }
}