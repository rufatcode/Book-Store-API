using System;
using Book_Libirary_Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Libirary_Api.Configuration
{
	public class AboutConfiguration:BaseEntityConfiguration<About>
	{
		public AboutConfiguration()
		{
		}
        public override void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(300);
            base.Configure(builder);
        }
    }
}

