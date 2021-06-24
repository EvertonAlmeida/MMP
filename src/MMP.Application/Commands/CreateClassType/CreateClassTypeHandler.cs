using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MMP.Domain.Interfaces;
using MMP.Domain.Models.Classes;
using MMP.Domain.Models.Classes.Repository;
using MMP.Domain.Models.Classes.Validation;

namespace MMP.Application.Commands.CreateClassType
{
    public class CreateClassTypeHandler : BaseHandler, IRequestHandler<CreateClassTypeCommand, bool>
    {
        private readonly IClassTypeRepository _classTypeRepository;

        public CreateClassTypeHandler(
            IClassTypeRepository classTypeRepository,
            INotifier notifier) : base(notifier)
        {
            _classTypeRepository = classTypeRepository;
        }

        public async Task<bool> Handle(CreateClassTypeCommand command, CancellationToken cancellationToken)  
        {  
            var classtype = new ClassType(command.Title);

            if (!ExecuteValidation(new ClassTypeValidation(), classtype)) return false;

            await _classTypeRepository.Add(classtype);
            return true;
        }
    }
}