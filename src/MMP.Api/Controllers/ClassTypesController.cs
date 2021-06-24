using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMP.Application.Commands.CreateClassType;
using MMP.Application.Queries.GetClassType;
using MMP.Application.ViewModels;
using MMP.Domain.Interfaces;

namespace MMP.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClassTypesController : MainController
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;

        public ClassTypesController(
            INotifier notifier,
            IMediator mediatr, 
            IMapper mapper) : base(notifier)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassTypeViewModel>> GetAsync()
        {
            var classType = await _mediatr.Send(new GetClassTypeQuery());

            return classType;
        }

        [HttpPost]
        public async Task<ActionResult<ClassTypeViewModel>> CreateAsync(ClassTypeViewModel classTypeViewModel)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var classTypeCommand = _mapper.Map<CreateClassTypeCommand>(classTypeViewModel);

            await _mediatr.Send(classTypeCommand);
            
            return CustomResponse(classTypeViewModel);
        }
    }
}
