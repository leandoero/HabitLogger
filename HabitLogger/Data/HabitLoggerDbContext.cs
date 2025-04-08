using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HabitLogger.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HabitLogger.Data
{
    public class HabitLoggerDbContext : DbContext
    {
        public HabitLoggerDbContext(DbContextOptions<HabitLoggerDbContext> options) : base(options) { }

        public DbSet<Habit> Habits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for Difficulties
            //easy, medium, hard

            var habits = new List<Habit>()
            {
                new Habit()
                {
                    Id = Guid.Parse("c7666d67-56da-410f-8ab2-16a7fff82747"),
                    Title = "adad",
                    CreatedTime = new DateTime(2023, 4, 8),
                    IsCompleted = false
                }

            };
            modelBuilder.Entity<Habit>().HasData(habits);

        }
    }
}
