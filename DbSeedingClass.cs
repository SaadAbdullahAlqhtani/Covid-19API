using covid.Models;
using covid.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid
{
    public static class DbSeedingClass
    {
        public static void SeedDataContext(this CaseDBContext context)
        {
            var data = new List<Case>()
            {
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
            };

            context.Cases.AddRange(data);
            context.SaveChanges();
        }
    }
}
