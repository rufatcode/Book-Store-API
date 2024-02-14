using System;
using Book_Libirary_Api.Interfaces;

namespace Book_Libirary_Api.Services
{
	public class FileService:IFileService
	{
		public FileService()
		{
		}

        public bool IsImage(IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public bool LengthIsSuitable(IFormFile file,int value)
        {
            return file.Length / 1024 < value ? true : false;
        }
    }
}

