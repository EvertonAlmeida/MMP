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
        private readonly IClassRepository _classRepository;

        public DeleteClassTypeHandler(
            IClassTypeRepository classTypeRepository,
            IClassRepository classRepository,
            INotifier notifier) : base(notifier)
        {
            _classTypeRepository = classTypeRepository;
            _classRepository = classRepository;
        }

        public async Task<bool> Handle(DeleteClassTypeCommand command, CancellationToken cancellationToken)  
        {  
            var classModel = await _classRepository.GetClassByClassTypeId(command.Id); 

            if (classModel != null)
            {
                Notify($"This class type is being used at least for one Class!");
                return false;
            }

            var classType = await _classTypeRepository.GetById(command.Id);
            if(classType == null)
            {
                Notify($"The class type was not found!");
                return false;
            }

            await _classTypeRepository.Remove(classType);

            return true;
        }
    }
}