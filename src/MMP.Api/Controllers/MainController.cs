using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MMP.Domain.Interfaces;
using MMP.Domain.Notifications;

namespace MMP.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok( new 
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new 
            {
                sucess = false,
                erros = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if(!modelState.IsValid) NotifyErrorInvalidModel(modelState);
            return CustomResponse();
        }

        protected void NotifyErrorInvalidModel(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string errorMsg)
        {
            _notifier.Handle(new Notification(errorMsg));
        }

        protected bool IsValidOperation()
        {
            return !_notifier.IsThereAnyNotification();
        }
    }
}
