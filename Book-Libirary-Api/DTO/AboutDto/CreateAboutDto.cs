using System;
namespace Book_Libirary_Api.DTO.AboutDto
{
	public class CreateAboutDto
	{
        public string Name { get; set; }
        public string Info { get; set; }
        public string Contoent { get; set; }
        public IFormFile MainImage { get; set; }
        public IFormFile SubImage { get; set; }
        public CreateAboutDto()
		{
		}
	}
}

