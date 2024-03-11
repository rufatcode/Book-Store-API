using System;
namespace Book_Libirary_Api.DTO.SliderDto
{
	public class UpdateSliderDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Info { get; set; }
        public IFormFile? Img { get; set; }
        public bool IsDeleted { get; set; }
        public UpdateSliderDto()
		{
		}
	}
}

