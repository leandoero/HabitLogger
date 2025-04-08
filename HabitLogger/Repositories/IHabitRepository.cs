using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HabitLogger.Models.Domain;

namespace HabitLogger.Repositories
{
    public interface IHabitRepository
    {
        Task<Habit> AddAsync(Habit habit);
        Task<List<Habit>> GetAllAsync();

        Task<Habit?> DeleteAsync(Guid id);

        Task<List<Habit>?> DeleteAllAsync();
    }
}
