using System;
using System.ComponentModel.DataAnnotations;

namespace Book_Libirary_Api.DTO.SliderDto
{
	public class CreateSliderDto
	{
        public string Title { get; set; }
        public string Content { get; set; }
        public string Info { get; set; }
        public IFormFile Img { get; set; }
        public CreateSliderDto()
		{
		}
	}
}

