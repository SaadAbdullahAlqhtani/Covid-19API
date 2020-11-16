using covid.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid.Services
{
    public class CaseDBContext : DbContext
    {
        public CaseDBContext(DbContextOptions<CaseDBContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Case> Cases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>().HasData(
                new Case()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Type = "Cured",
                    Description = "Description"
                },
                new Case()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Doe",
                    Type = "Cured",
                    Description = "Description"
                },
                new Case()
                {
                    Id = 3,
                    FirstName = "Amy",
                    LastName = "Doe",
                    Type = "Infected",
                    Description = "Description"
                },
                new Case()
                {
                    Id = 4,
                    FirstName = "Steve",
                    LastName = "Doe",
                    Type = "Cured",
                    Description = "Description"
                },
                new Case()
                {
                    Id = 5,
                    FirstName = "Amy",
                    LastName = "House",
                    Type = "Infected",
                    Description = "Description"
                },
                new Case()
                {
                    Id = 6,
                    FirstName = "Sam",
                    LastName = "Wood",
                    Type = "Deceased",
                    Description = "Description"
                },
                new Case()
                {
                    Id = 7,
                    FirstName = "Alex",
                    LastName = "Clay",
                    Type = "Deceased",
                    Description = "Description"
                }
            );
        }
    }
}
