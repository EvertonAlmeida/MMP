using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMP.Application.Commands.CreateClass;
using MMP.Application.Commands.UpdateClass;
using MMP.Application.Queries.GetClassById;
using MMP.Application.Queries.GetClasses;
using MMP.Application.ViewModels;
using MMP.Domain.Interfaces;

namespace MMP.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClassesController : MainController
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;
        
        public ClassesController(
            IMediator mediatr, 
            IMapper mapper,
            INotifier notifier) : base(notifier)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassViewModel>> GetAsync()
        {
            var classesViewModel = await _mediatr.Send(new GetClassesQuery());

            return classesViewModel;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClassViewModel>> GetByIdAsync(Guid id)
        {
            var classViewModel = await _mediatr.Send(new GetClassByIdQuery(id));

            if(classViewModel == null) return NotFound();

            return classViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ClassViewModel>> CreateAsync(ClassViewModel classViewModel)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var classCommand = _mapper.Map<CreateClassCommand>(classViewModel);

            return CustomResponse(await _mediatr.Send(classCommand));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ClassViewModel>> UpdateAsync(Guid id,ClassViewModel classViewModel)
        {
            if (classViewModel == null || id != classViewModel.Id)
            {
                NotifyError("The ids informed are not the same!!");
                return CustomResponse();
            }

            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var classCommand = _mapper.Map<UpdateClassCommand>(classViewModel);
           
            var wasUpdated = await _mediatr.Send(classCommand);
            if(wasUpdated == false) return NotFound();

            return CustomResponse(wasUpdated);
        }
    }
}