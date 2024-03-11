using System;
namespace Book_Libirary_Api.DTO.SettingDto
{
	public class GetSettingDtoByAdmin
	{
        public string Key { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string AddedBy { get; set; }
        public GetSettingDtoByAdmin()
		{
		}
	}
}

