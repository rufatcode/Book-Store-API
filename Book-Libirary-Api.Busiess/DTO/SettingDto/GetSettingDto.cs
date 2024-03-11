using System;
namespace Book_Libirary_Api.DTO.SettingDto
{
	public class GetSettingDto
	{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public GetSettingDto()
		{
		}
	}
}

