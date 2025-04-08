using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Models.DTO
{
    public class AddHabitDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
 