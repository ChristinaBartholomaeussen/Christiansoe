using christiansoe.Data.models;
using Microsoft.EntityFrameworkCore;

namespace christiansoe
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Attraction> Attractions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attraction>().HasData(
                new Attraction
                {
                    Id = 1,
                    Name = "Færgeteminal",
                    Latitude = 55.32073, 
                    Longitude = 15.18603,
                    IsChecked = false
                    
                }, new Attraction
                {
                    Id = 2,
                    Name = "Østerkær - Danmarks østligeste punkt",
                    Latitude = 55.320205,
                    Longitude = 15.192849,
                    IsChecked = false
                },
                new Attraction
                {
                    Id = 3,
                    Name = "Hestehytten",
                    Latitude = 55.32226487709977,
                    Longitude = 15.187511167143466,
                    IsChecked = false
                },
                new Attraction
                {
                    Id = 4,
                    Name = "Christiansø Kirke",
                    Latitude = 55.321274614803706,
                    Longitude = 15.187012128055752,
                    IsChecked = false
                },
                new Attraction
                {
                    Id = 5,
                    Name = "Broen mellem Christiansø og Frederiksø",
                    Latitude = 55.320439,
                    Longitude = 15.186107,
                    IsChecked = false
                },
                new Attraction
                {
                    
                    Id = 6,
                    Name = "Store Tårn",
                    Latitude = 55.32056080268012,
                    Longitude = 15.186943327270084,
                    IsChecked = false
                },
                new Attraction
                {
                   Id = 7,
                   Name = "Hertugindens Bastion",
                   Latitude = 55.32202550128021,
                   Longitude = 15.190051203380062,
                   IsChecked = false,
                   
                },
                new Attraction
                {
                    Id = 8,
                    Name = "Rantzaus Bastion",
                    Latitude = 55.32316277540636,
                    Longitude = 15.188298239819762,
                    IsChecked = false,
                },
                new Attraction
                {
                    Id = 9,
                    Name = "Mindet",
                    Latitude = 55.32044,
                    Longitude = 15.18939,
                    IsChecked = false
                    
                },
                new Attraction
                {
                    Id = 10,
                    Name = "Christiansø Teltplads",
                    Latitude = 55.32199,
                    Longitude = 15.19008,
                    IsChecked = false
                    
                },
                new Attraction
                {
                    Id = 11,
                    Name = "101 Trappen",
                    Latitude = 55.32024,
                    Longitude = 15.18649,
                    IsChecked = false
                });
        }
    }
}
