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
        public Habit Add(Habit habit);
        public List<Habit> GetAll();
    }
}
