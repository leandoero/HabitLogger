using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HabitLogger.Models.Domain;
using Microsoft.EntityFrameworkCore;
using HabitLogger.Data;

namespace HabitLogger.Repositories
{
    public class SQLHabitRepository : IHabitRepository
    {
        private readonly HabitLoggerDbContext dbContext;

        public SQLHabitRepository(HabitLoggerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Habit Add(Habit habit)
        {
            dbContext.Habits.Add(habit);
            dbContext.SaveChanges();
            return habit;
        }
       public List<Habit> GetAll() => dbContext.Habits.ToList();
    }
}
