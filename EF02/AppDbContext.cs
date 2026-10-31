using EF02.Models;
using EF02.Models.Configration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF02
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Organizer> Organizers => Set<Organizer>();
        public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Attendee> Attendees => Set<Attendee>();
        public DbSet<Badge> Badges => Set<Badge>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database= EFcore;Trusted_Connection=true; Trusted_Connection=true;TrustServerCertificate=true");

        }
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.ApplyConfiguration(new OrganizerProfileConfiguration());
            mb.ApplyConfiguration(new BadgeConfiguration());

            // الطريقة 2: مباشرة هنا
            mb.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).IsRequired().HasMaxLength(200);
                e.Property(x => x.Description).IsRequired();
                e.Property(x => x.StartDate).IsRequired();
                e.Property(x => x.MaxAttendees).IsRequired();

                e.HasOne(x => x.Organizer)
                 .WithMany(o => o.Events)
                 .HasForeignKey(x => x.OrganizerId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
};
