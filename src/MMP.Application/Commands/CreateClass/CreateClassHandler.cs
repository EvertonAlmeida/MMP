using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MMP.Domain.Interfaces;
using MMP.Domain.Models.Classes;
using MMP.Domain.Models.Classes.Repository;
using MMP.Domain.Models.Classes.Validation;

namespace MMP.Application.Commands.CreateClass
{
    public class CreateClassHandler : BaseHandler, IRequestHandler<CreateClassCommand, bool>
    {
        private readonly IClassRepository _classRepository;
        private readonly IClassTypeRepository _classTypeRepository;

        private readonly IMapper _mapper;

        public CreateClassHandler(
            IClassRepository classRepository,
            IClassTypeRepository classTypeRepository,
            IMapper mapper,
            INotifier notifier) : base(notifier)
        {
            _classRepository = classRepository;
            _classTypeRepository = classTypeRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateClassCommand command, CancellationToken cancellationToken)  
        {  
            var venue = new Venue(
                command.VenueCommand.VenueId, command.VenueCommand.Name, 
                command.VenueCommand.Address, command.VenueCommand.Online,
                command.VenueCommand.Url, command.VenueCommand.ContactNumber);

            var classModel = new Class(
                command.Title, command.Description, command.StartDate, 
                command.EndDate, command.Free, command.Value, 
                command.CompanyName, command.ClassTypeId, venue);

            if (!ExecuteValidation(new ClassValidation(), classModel)) return false;

            var classType =  await _classTypeRepository.GetById(command.ClassTypeId);

            if (classType is null)
            {
                Notify("The Class Type Id was not found");
                return false;
            }

            await _classRepository.Add(classModel);

            return true;
        }
    }
}