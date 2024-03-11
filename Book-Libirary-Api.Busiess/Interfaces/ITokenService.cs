using System;
using Book_Libirary_Api.Entities;

namespace Book_Libirary_Api.Interfaces
{
	public interface ITokenService
	{
        string CreateToken(AppUser user, IList<string> roles);
    }
}

