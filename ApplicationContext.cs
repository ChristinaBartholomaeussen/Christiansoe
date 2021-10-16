using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using christiansoe.Data.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace christiansoe
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Attraction> Attractions { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attraction>().HasData(
                new Attraction
                {
                    Id = 1,
                    Name = "Store Tårn",
                    Latitude = 55.32056080268012,
                    Longitude = 15.186943327270084
                }, new Attraction
                {
                    Id = 2,
                    Name = "Test2",
                    Latitude = 1515151,
                    Longitude = 484848
                    
                },
                new Attraction
                {
                    Id = 3,
                    Name = "Test3",
                    Latitude = 1515151,
                    Longitude = 484848
                    
                },
                new Attraction
                {
                    Id = 4,
                    Name = "Test4",
                    Latitude = 1515151,
                    Longitude = 484848
                    
                },
                new Attraction
                {
                    Id = 5,
                    Name = "Test5",
                    Latitude = 1515151,
                    Longitude = 484848
                    
                });
            
        }
    }
}