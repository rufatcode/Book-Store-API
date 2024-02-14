using System;
using Book_Libirary_Api.DTO.SliderDto;
using FluentValidation;

namespace Book_Libirary_Api.Validator.SliderValidator
{
	public class UpdateSliderValidator:AbstractValidator<UpdateSliderDto>
	{
		public UpdateSliderValidator()
		{
            RuleFor(s => s.Title)
                .MinimumLength(5).WithMessage("title length must be greate than 5")
                .MaximumLength(300).WithMessage("title length must be smaller than 300");
            RuleFor(s => s.Content)
                .MinimumLength(5).WithMessage("title length must be greate than 5");
            RuleFor(s => s.Info)
                .MinimumLength(5).WithMessage("title length must be greate than 5");

        }
	}
}

