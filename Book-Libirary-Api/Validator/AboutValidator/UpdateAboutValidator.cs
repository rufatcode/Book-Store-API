using System;
using Book_Libirary_Api.DTO.AboutDto;
using FluentValidation;

namespace Book_Libirary_Api.Validator.AboutValidator
{
	public class UpdateAboutValidator: AbstractValidator<UpdateAboutDto>
    {
		public UpdateAboutValidator()
		{
            RuleFor(a => a.Name)
                .MaximumLength(300).WithMessage("name length must be smaller than 300")
                .MinimumLength(5).WithMessage("name length must be greater than 5");
        }
	}
}

