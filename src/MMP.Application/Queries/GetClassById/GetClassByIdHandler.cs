using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MMP.Application.ViewModels;
using MMP.Domain.Models.Classes.Repository;

namespace MMP.Application.Queries.GetClassById
{
    public class GetClassByIdHandler : IRequestHandler<GetClassByIdQuery, ClassViewModel>
    {  
        private readonly IClassRepository _repository;  
        private readonly IMapper _mapper;
        public GetClassByIdHandler(IClassRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClassViewModel> Handle(GetClassByIdQuery query, CancellationToken cancellationToken)  
        {  
            var result = await _repository.GetById(query.id);
            return _mapper.Map<ClassViewModel>(result);
        }  
    }
}