using System;
namespace Book_Libirary_Api.DTO.AboutDto
{
	public class UpdateAboutDto
	{
        public string Name { get; set; }
        public string Info { get; set; }
        public string Contoent { get; set; }
        public IFormFile? MainImage { get; set; }
        public IFormFile? SubImage { get; set; }
        public bool IsDeleted { get; set; }
        public UpdateAboutDto()
		{
		}
	}
}

