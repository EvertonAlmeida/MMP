using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MMP.Domain.Interfaces;
using MMP.Domain.Models.Classes.Repository;

namespace MMP.Application.Commands.DeleteClass
{
    public class DeleteClassHandler : BaseHandler, IRequestHandler<DeleteClassCommand, bool>
    {
        private readonly IClassRepository _classRepository;

        public DeleteClassHandler(
            IClassRepository classRepository,
            INotifier notifier) : base(notifier)
        {
            _classRepository = classRepository;
        }

        public async Task<bool> Handle(DeleteClassCommand command, CancellationToken cancellationToken)  
        {  
            
            var classModel = await _classRepository.GetById(command.Id);
            if(classModel == null)
            {
                Notify($"The class was not found!");
                return false;
            }

            await _classRepository.Remove(classModel);

            return true;
        }
    }
}