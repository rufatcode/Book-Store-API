using System;
namespace Book_Libirary_Api.DTO.SettingDto
{
	public class UpdateSettingDto
	{
		public int Id { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }
		public bool IsDeleted { get; set; }
		public UpdateSettingDto()
		{
		}
	}
}

