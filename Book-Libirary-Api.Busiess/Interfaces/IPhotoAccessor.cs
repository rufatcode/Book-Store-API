using System;
using CloudinaryDotNet.Actions;

namespace Book_Libirary_Api.Interfaces
{
	public interface IPhotoAccessor
	{
        Task<ImageUploadResult> AddPhoto(IFormFile file);
        Task<DeletionResult> DeletePhoto(string publicId);
    }
}

