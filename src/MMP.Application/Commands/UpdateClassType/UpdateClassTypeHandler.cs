using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MMP.Domain.Interfaces;
using MMP.Domain.Models.Classes;
using MMP.Domain.Models.Classes.Repository;
using MMP.Domain.Models.Classes.Validation;

namespace MMP.Application.Commands.UpdateClassType
{
    public class UpdateClassTypeHandler : BaseHandler, IRequestHandler<UpdateClassTypeCommand, bool>
    {
        private readonly IClassTypeRepository _classTypeRepository;

        public UpdateClassTypeHandler(
            IClassTypeRepository classTypeRepository,
            INotifier notifier) : base(notifier)
        {
            _classTypeRepository = classTypeRepository;
        }

        public async Task<bool> Handle(UpdateClassTypeCommand command, CancellationToken cancellationToken)  
        {  
            var classtype = new ClassType(command.Id ,command.Title);

            if (!ExecuteValidation(new ClassTypeValidation(), classtype)) return false;

            var classType = await _classTypeRepository.GetById(command.Id);
            if(classType == null) return false;

            await _classTypeRepository.Update(classtype);

            return true;
        }
    }
}