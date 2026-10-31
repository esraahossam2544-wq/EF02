using EF02;
using EF02.Models;
using AppDbContext context = new();


using var db = new AppDbContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

var org = new Organizer
{
    Name = "Esraa",
    CompanyName = "MedEvents",
    IsVerified = true,
    Profile = new OrganizerProfile { Biography = "Hello" }
};
org.Events.Add(new Event
{
    Title = "Conf",
    Description = "Desc",
    StartDate = DateTime.Today,
    MaxAttendees = 100
});

var att = new Attendee
{
    FullName = "Ali",
    Email = "a@a.com",
    Street = "St 1",
    City = "Cairo",
    Country = "Egypt",
    PostalCode = "11511",
    Badge = new Badge { BadgeNumber = 1, IssuedDate = DateTime.Today, Tier = BadgeTier.VIP }
};

db.AddRange(org, att);
db.SaveChanges();
Console.WriteLine(att.FullAddress);
