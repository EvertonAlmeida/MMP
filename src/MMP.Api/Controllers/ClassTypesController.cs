using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMP.Application.Commands.CreateClassType;
using MMP.Application.Commands.DeleteClassType;
using MMP.Application.Commands.UpdateClassType;
using MMP.Application.Queries.GetByIdClass;
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClassTypeViewModel>> GetByIdAsync(Guid id)
        {
            var classType = await _mediatr.Send(new GetByIdClassTypeQuery(id));

            if(classType == null) return NotFound();

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

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ClassTypeViewModel>> UpdateAsync(Guid id,ClassTypeViewModel classTypeViewModel)
        {
            if (id != classTypeViewModel.Id)
            {
                NotifyError("The ids informed are not the same!!");
                return CustomResponse();
            }

            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var classTypeCommand = _mapper.Map<UpdateClassTypeCommand>(classTypeViewModel);

            await _mediatr.Send(classTypeCommand);
            
            return CustomResponse(classTypeViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var wasDeleted = await _mediatr.Send(new DeleteClassTypeCommand(id));
            if(wasDeleted == false) return NotFound();
            
            return CustomResponse(wasDeleted);
        }
    }
}
