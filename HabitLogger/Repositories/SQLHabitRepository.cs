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
        public async Task<Habit> AddAsync(Habit habit)
        {
            await dbContext.Habits.AddAsync(habit);
            await dbContext.SaveChangesAsync();
            return habit;
        }
        public async Task<List<Habit>> GetAllAsync()
        {
            return await dbContext.Habits.ToListAsync();
        }

        public async Task<Habit?> DeleteAsync(Guid id)
        {
            var habitById = await dbContext.Habits.FindAsync(id);
            if (habitById != null)
            {
                dbContext.Habits.Remove(habitById);
                await dbContext.SaveChangesAsync();
                return habitById;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Habit>?> DeleteAllAsync()
        {
            var allHabits = await dbContext.Habits.ToListAsync();
            if (allHabits.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in allHabits)
                {
                    dbContext.Habits.Remove(item);
                    await dbContext.SaveChangesAsync();
                }
                return allHabits;
            }
        }
    }
}
