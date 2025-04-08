using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HabitLogger.Models.Domain;
using HabitLogger.Models.DTO;

namespace HabitLogger.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() { 
            CreateMap<Habit, HabitDto>().ReverseMap();
            CreateMap<Habit, AddHabitDto>().ReverseMap();
        }
    }
}
