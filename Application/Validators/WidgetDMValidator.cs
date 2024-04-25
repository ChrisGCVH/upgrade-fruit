using FluentValidation;
using HicomInterview.Application.DataModels;

namespace HicomInterview.Application.Validators
{
    public class WidgetDMValidator : AbstractValidator<WidgetDM>
    {
        public WidgetDMValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("You must enter an email address");

            RuleFor(x => x.OldAddress).SetValidator(new AddressDMValidator());
            RuleFor(x => x.NewAddress).SetValidator(new AddressDMValidator());
        }
    }
}
