using System;
using Microsoft.AspNetCore.Identity;

namespace Book_Libirary_Api.Entities
{
	public class AppUser:IdentityUser
	{
		public string FullName { get; set; }
		public AppUser()
		{
		}
	}
}

