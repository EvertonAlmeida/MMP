using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MMP.Domain.Interfaces;
using MMP.Domain.Models.Classes;
using MMP.Domain.Models.Classes.Repository;
using MMP.Domain.Models.Classes.Validation;

namespace MMP.Application.Commands.UpdateClass
{
    public class UpdateClassHandler : BaseHandler, IRequestHandler<UpdateClassCommand, bool>
    {
        private readonly IClassRepository _classRepository;

        public UpdateClassHandler(
            IClassRepository classRepository,
            INotifier notifier) : base(notifier)
        {
            _classRepository = classRepository;
        }

        public async Task<bool> Handle(UpdateClassCommand command, CancellationToken cancellationToken)  
        {  
            var venue = new Venue(
                command.VenueCommand.VenueId, command.VenueCommand.Name, 
                command.VenueCommand.Address, command.VenueCommand.Online,
                command.VenueCommand.Url, command.VenueCommand.ContactNumber);

            var classToUpdate = new Class( 
                command.Id,command.Title, command.Description, command.StartDate,
                command.EndDate, command.Free, command.Value, command.CompanyName,
                command.ClassTypeId, venue);

            if (!ExecuteValidation(new ClassValidation(), classToUpdate)) return false;

            var classModel = await _classRepository.GetById(command.Id);
            if(classModel == null) return false;

            await _classRepository.Update(classToUpdate);

            return true;
        }
    }
}