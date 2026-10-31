using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF02.Models.Configration
{
    public class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> b)
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.Biography).HasMaxLength(1000);
            b.Property(p => p.WebsiteUrl).HasMaxLength(300);
            b.Property(p => p.LogoUrl).HasMaxLength(300);

            b.HasOne(p => p.Organizer)
             .WithOne(o => o.Profile)
             .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
