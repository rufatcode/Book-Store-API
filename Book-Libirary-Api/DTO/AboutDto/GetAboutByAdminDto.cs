using System;
namespace Book_Libirary_Api.DTO.AboutDto
{
	public class GetAboutByAdminDto
	{

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Contoent { get; set; }
        public string MainImageUrl { get; set; }
        public string MainPublicId { get; set; }
        public string SubImageUrl { get; set; }
        public string SubPublicId { get; set; }
        public bool IsDeleted { get; set; }
        public string AddedBy { get; set; }
        public GetAboutByAdminDto()
		{
		}
	}
}

