using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MMP.Domain.Interfaces;
using MMP.Domain.Models.Classes.Repository;

namespace MMP.Application.Commands.DeleteClassType
{
    public class DeleteClassTypeHandler : BaseHandler, IRequestHandler<DeleteClassTypeCommand, bool>
    {
        private readonly IClassTypeRepository _classTypeRepository;

        public DeleteClassTypeHandler(
            IClassTypeRepository classTypeRepository,
            INotifier notifier) : base(notifier)
        {
            _classTypeRepository = classTypeRepository;
        }

        public async Task<bool> Handle(DeleteClassTypeCommand command, CancellationToken cancellationToken)  
        {  
            var classType = await _classTypeRepository.GetById(command.Id);
            if(classType == null) return false;

            await _classTypeRepository.Remove(classType);

            return true;
        }
    }
}