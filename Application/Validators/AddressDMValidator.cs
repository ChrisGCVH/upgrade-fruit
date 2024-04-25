using HicomInterview.Application.DataModels;
using FluentValidation;

namespace HicomInterview.Application.Validators
{
    public class AddressDMValidator : AbstractValidator<AddressDM>
    {
        public AddressDMValidator()
        {
            RuleFor(x => x.AddressLine1)
                .NotEmpty()
                .WithMessage("You must enter an address line 1!");
        }
    }
}
