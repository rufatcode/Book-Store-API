using System;
namespace Book_Libirary_Api.Entities
{
	public class Slider:BaseEntity
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public string Info { get; set; }
		public string ImgUrl { get; set; }
		public string PublicId { get; set; }
		public Slider()
		{
		}
	}
}

