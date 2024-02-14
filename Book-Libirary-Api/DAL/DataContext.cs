using System;
using Book_Libirary_Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book_Libirary_Api.DTO
{
	public class DataContext:IdentityDbContext<AppUser>
	{
        public DbSet<Slider> Sliders { get; set; }
		public DataContext(DbContextOptions options):base(options)
		{
		}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(builder);
        }

    }
}

