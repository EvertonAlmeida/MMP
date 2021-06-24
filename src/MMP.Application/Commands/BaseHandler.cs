using FluentValidation;
using FluentValidation.Results;
using MMP.Domain.Interfaces;
using MMP.Domain.Models;
using MMP.Domain.Notifications;

namespace MMP.Application.Commands
{
    public abstract class BaseHandler
    {
        private readonly INotifier _notifier;

        protected BaseHandler(INotifier notifier)
        {
            _notifier = notifier;
        }

         protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if(validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}