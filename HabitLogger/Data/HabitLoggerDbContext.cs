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
    }
}
