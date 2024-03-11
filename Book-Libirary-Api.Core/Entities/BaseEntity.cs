using System;
namespace Book_Libirary_Api.Entities
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public Nullable<DateTime> DeletedAt { get; set; }
		public Nullable<DateTime> UpdatedAt { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool IsDeleted { get; set; }
		public string AddedBy { get; set; }
		public BaseEntity()
		{
		}
	}
}

