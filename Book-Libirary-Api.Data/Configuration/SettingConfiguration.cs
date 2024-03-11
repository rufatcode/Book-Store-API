using System;
using Book_Libirary_Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Libirary_Api.Configuration
{
	public class SettingConfiguration: BaseEntityConfiguration<Setting>
    {
		public SettingConfiguration()
		{
		}
        public override void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasData(new Setting { Id=1,Key = "Fre", Value = "The New variantiodsds" },new Setting{Id=2,Key="20 day returns",Value="The New vdsdsds" });
            builder.Property(s => s.Key).HasMaxLength(300);
            builder.Property(s => s.Value).HasMaxLength(300);

            base.Configure(builder);
        }
    }
}

