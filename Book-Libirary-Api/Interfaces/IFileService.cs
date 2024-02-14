using System;
namespace Book_Libirary_Api.Interfaces
{
	public interface IFileService
	{
		bool LengthIsSuitable(IFormFile file,int value);
		bool IsImage(IFormFile file);
	}
}

