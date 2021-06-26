using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MMP.Application.ViewModels;
using MMP.Domain.Models.Classes.Repository;

namespace MMP.Application.Queries.GetClasses
{
    public class GetClassesHandler : IRequestHandler<GetClassesQuery, IEnumerable<ClassViewModel>>  
    {  
        private readonly IClassRepository _repository;  
        private readonly IMapper _mapper;
        public GetClassesHandler(IClassRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassViewModel>> Handle(GetClassesQuery query, CancellationToken cancellationToken)  
        {  
            var classes = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ClassViewModel>>(classes);
        }  
    }
}