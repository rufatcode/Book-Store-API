using System;
using Book_Libirary_Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Libirary_Api.Configuration
{
	public class SliderConfiguration: BaseEntityConfiguration<Slider>
	{
		public SliderConfiguration()
		{
		}

        public override void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(s => s.Title).HasMaxLength(300);
            base.Configure(builder);
        }
    }
}

