using System;
using System.ComponentModel.DataAnnotations;

namespace Book_Libirary_Api.DTO.SliderDto
{
	public class GetSliderDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Info { get; set; }
        public string ImgUrl { get; set; }
        public string PublicId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public GetSliderDto()
		{
		}
	}
}

