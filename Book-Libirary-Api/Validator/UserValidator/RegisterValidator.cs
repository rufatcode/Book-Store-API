using System;
using Book_Libirary_Api.DTO.UserDto;
using FluentValidation;

namespace Book_Libirary_Api.Validator.UserValidator
{
	public class RegisterValidator:AbstractValidator<RegisterDto>
	{
		public RegisterValidator()
		{
			RuleFor(u => u.FullName)
				.MinimumLength(5).WithMessage("Minimun Lenght of FullName is 5")
				.MaximumLength(100).WithMessage("Maximun Length of FullName is 100");
			RuleFor(u => u.UserName)
				.MinimumLength(5).WithMessage("Minimun Length of UserName is 5")
				.MaximumLength(100).WithMessage("Maximun Length of UserName is 100");
			RuleFor(u => u.Email)
				.MinimumLength(5).WithMessage("email length must be greater than 5")
				.MaximumLength(100).WithMessage("email length must be smaller than 100")
				.EmailAddress().WithMessage("email is not valid")
				.Matches(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$").WithMessage("email is not valid");
			RuleFor(u => u.Password)
				.MinimumLength(8).WithMessage("Password length must be greater than 8")
				.MaximumLength(100).WithMessage("Password length must be smaller than 100")
				.Equal(u=>u.RepeatPassword).WithMessage("password and repeat password must be equal");
			RuleFor(u => u.RepeatPassword)
				.MinimumLength(8).WithMessage("Repeat Password length must be greater than 8")
				.MaximumLength(100).WithMessage("Repeat Password length must be smaller than 100");

			
		}
	}
}

