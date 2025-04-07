using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Models.Domain
{
    public class Habit
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsCompleted { get; set; }

    }
}
