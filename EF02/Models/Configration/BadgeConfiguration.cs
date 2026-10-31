using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF02.Models.Configration
{
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.BadgeNumber).IsRequired();
            b.HasIndex(x => x.BadgeNumber).IsUnique();
            b.Property(x => x.IssuedDate).IsRequired();
            b.Property(x => x.Tier).HasConversion<string>().HasMaxLength(20);

            b.HasOne(x => x.Attendee)
             .WithOne(a => a.Badge)
             .HasForeignKey<Badge>(x => x.AttendeeId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    
    }
}
