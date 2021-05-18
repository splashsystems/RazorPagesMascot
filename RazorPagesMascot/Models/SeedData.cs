using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMascot.Data;

namespace RazorPagesMascot.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMascotContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMascotContext>>()))
            {
                // Look for any Mascots.
                if (context.Mascot.Any())
                {
                    return;   // DB has been seeded
                }

                context.Mascot.AddRange(
                    new Mascot
                    {
                        MascotName = "Brutus Buckeye",
                        DateBegan = DateTime.Parse("1928-1-1"),
                        School = "The Ohio State University",
                        Salary = 23000.00M
                    },

                    new Mascot
                    {
                        MascotName = "Josephine Bruin",
                        DateBegan = DateTime.Parse("1967-9-15"),
                        School = "UCLA",
                        Salary = 26000.00M
                    },

                    new Mascot
                    {
                        MascotName = "The Phoenix",
                        DateBegan = DateTime.Parse("1874-9-15"),
                        School = "University of Chicago",
                        Salary = 24500.00M
                    },

                    new Mascot
                    {
                        MascotName = "Cactus Needle",
                        DateBegan = DateTime.Parse("2005-9-15"),
                        School = "Western Desert",
                        Salary = 12000M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}