using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MMP.Application.ViewModels;
using MMP.Domain.Models.Classes.Repository;

namespace MMP.Application.Queries.GetClassType
{
    public class GetByIdClassTypeHandler : IRequestHandler<GetByIdClassTypeQuery, ClassTypeViewModel>
    {  
        private readonly IClassTypeRepository _repository;  
        private readonly IMapper _mapper;
        public GetByIdClassTypeHandler(IClassTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClassTypeViewModel> Handle(GetByIdClassTypeQuery query, CancellationToken cancellationToken)  
        {  
            var result = await _repository.GetById(query.id);
            return _mapper.Map<ClassTypeViewModel>(result);
        }  
    }
}