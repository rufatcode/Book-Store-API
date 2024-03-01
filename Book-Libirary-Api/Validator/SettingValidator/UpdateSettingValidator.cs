using System;
using Book_Libirary_Api.DTO.SettingDto;
using FluentValidation;

namespace Book_Libirary_Api.Validator.SettingValidator
{
	public class UpdateSettingValidator:AbstractValidator<UpdateSettingDto>
	{
		public UpdateSettingValidator()
		{
            RuleFor(s => s.Key)
                .MinimumLength(5).WithMessage("key length must be smaller than 5")
                .MaximumLength(300).WithMessage("key length must be greater than 300");
            RuleFor(s => s.Value)
                .MinimumLength(5).WithMessage("value length must be smaller than 5")
                .MaximumLength(300).WithMessage("value length must be greater than 300");
        }
	}
}

