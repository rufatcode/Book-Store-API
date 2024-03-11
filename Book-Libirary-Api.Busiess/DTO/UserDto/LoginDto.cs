using System;
namespace Book_Libirary_Api.DTO.UserDto
{
	public class LoginDto
	{
		public string UserNameOrEmail { get; set; }
		public string Password { get; set; }
		public LoginDto()
		{
		}
	}
}

