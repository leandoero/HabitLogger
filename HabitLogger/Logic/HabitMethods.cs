using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HabitLogger.Models.Domain;
using HabitLogger.Models.DTO;
using HabitLogger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HabitLogger.Logic
{
    public class HabitMethods
    {
        private readonly IHabitRepository repository;
        private readonly IMapper mapper;

        public HabitMethods(IHabitRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

      
        public void CreateHabit(AddHabitDto addHabitDto)
        {
            var habitDomain = mapper.Map<Habit>(addHabitDto);

            habitDomain = repository.Add(habitDomain);

            var habitDto = mapper.Map<HabitDto>(habitDomain);

            Console.WriteLine(habitDto);
        }

        public void GetHabits()
        {
            var habitDomain = repository.GetAll();

            var habitDto = mapper.Map<List<HabitDto>>(habitDomain);

            foreach (var item in habitDto)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Description);
                Console.WriteLine();
            }
        }


    }
}
