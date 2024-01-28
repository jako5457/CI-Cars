using CarLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                      new Car { Id = 1, Name = "Tesla Roadster", Type = "EV" }
                    , new Car { Id = 2, Name = "Fiat 500", Type = "Gas" }
                    , new Car { Id = 3, Name = "Folksvargen Polo", Type = "Diesel" }
                    , new Car { Id = 4, Name = "Tesla Cybertruck", Type = "EV" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
