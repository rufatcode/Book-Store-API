using System;
using Book_Libirary_Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Libirary_Api.Configuration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder) //virtual methodun bodysi olur amma istesek override ede biliriy
        {
            builder.Property(e => e.AddedBy).HasDefaultValue("System");
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
        
        }
    }
}

