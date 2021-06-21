using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMP.Application.Queries.GetClassType;
using MMP.Application.ViewModels;

namespace MMP.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClassTypesController : MainController
    {
        private readonly IMediator _mediatr;
        public ClassTypesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassTypeViewModel>> GetAsync()
        {
            return await _mediatr.Send(new GetClassTypeQuery());
        }
    }
}
