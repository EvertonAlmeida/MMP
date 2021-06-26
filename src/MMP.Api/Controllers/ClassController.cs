using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMP.Application.Queries.GetClasses;
using MMP.Application.ViewModels;
using MMP.Domain.Interfaces;

namespace MMP.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : MainController
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;
        
        public ClassController(
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
            var classType = await _mediatr.Send(new GetClassesQuery());

            return classType;
        }
    }
}