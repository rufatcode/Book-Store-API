using System;
namespace Book_Libirary_Api.DTO.AboutDto
{
	public class GetAboutDto
	{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Contoent { get; set; }
        public string MainImageUrl { get; set; }
        public string MainPublicId { get; set; }
        public string SubImageUrl { get; set; }
        public string SubPublicId { get; set; }
        public GetAboutDto()
		{
		}
	}
}

