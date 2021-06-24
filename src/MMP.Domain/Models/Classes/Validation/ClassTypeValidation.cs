using FluentValidation;

namespace MMP.Domain.Models.Classes.Validation
{
    public class ClassTypeValidation : AbstractValidator<ClassType>
    {
        public ClassTypeValidation()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .Length(min: 2, max: 100).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");
        }
    }
}