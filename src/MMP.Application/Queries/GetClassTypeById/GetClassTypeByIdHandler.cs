using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MMP.Application.ViewModels;
using MMP.Domain.Models.Classes.Repository;

namespace MMP.Application.Queries.GetClassTypeById
{
    public class GetClassTypeByIdHandler : IRequestHandler<GetClassTypeByIdQuery, ClassTypeViewModel>
    {  
        private readonly IClassTypeRepository _repository;  
        private readonly IMapper _mapper;
        public GetClassTypeByIdHandler(IClassTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClassTypeViewModel> Handle(GetClassTypeByIdQuery query, CancellationToken cancellationToken)  
        {  
            var result = await _repository.GetById(query.id);
            return _mapper.Map<ClassTypeViewModel>(result);
        }  
    }
}