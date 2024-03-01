using System;
namespace Book_Libirary_Api.Entities
{
	public class Setting:BaseEntity
	{
		public string Key { get; set; }
		public string Value { get; set; }
       
        public Setting()
		{
		}
	}
}

