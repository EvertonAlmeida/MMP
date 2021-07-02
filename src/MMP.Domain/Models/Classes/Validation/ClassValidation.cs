using System;
using FluentValidation;

namespace MMP.Domain.Models.Classes.Validation
{
    public class ClassValidation : AbstractValidator<Class>
    {
        public ClassValidation()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .Length(min: 2, max: 100).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .Length(min: 2, max: 1000).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.StartDate)
                .LessThan(c => c.EndDate)
                .WithMessage("The {PropertyName} field must be lower than EndDate");

            RuleFor(c => c.StartDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("The {PropertyName} field must be greater than current date");

            When(c => c.Free == false, () => {
                RuleFor(c => c.Value)
                    .GreaterThan(0).WithMessage("The Class {PropertyName} field must be greater than {ComparisonValue}");
            });

            When(c => c.Free == true, () => {
                RuleFor(c => c.Value)
                    .Equal(0).WithMessage("The Class {PropertyName} field must be {ComparisonValue}");
            });

            VenueValidation();
        }

        private void VenueValidation()
        {
            RuleFor(c => c.Venue.Name)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .Length(min: 2, max: 150).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");

            When(c => c.Venue.Online == false, () => {
                RuleFor(c => c.Venue.Address)
                    .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                    .Length(min: 2, max: 350).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");

                RuleFor(c => c.Venue.Url)
                    .Empty().WithMessage("The Offline Class must not have a {PropertyName}");
            });

            When(c => c.Venue.Online == true, () => {
                RuleFor(c => c.Venue.Url)
                    .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                    .Length(min: 2, max: 150).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");

                RuleFor(c => c.Venue.Address)
                    .Empty().WithMessage("The Online Class must not have a {PropertyName}");
            });

            RuleFor(c => c.Venue.ContactNumber)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .Length(min: 8, max: 15).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");
        }
    }
}