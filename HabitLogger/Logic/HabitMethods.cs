using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
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

      
        public async Task<HabitDto> CreateHabitAsync(AddHabitDto addHabitDto)
        {
            var habitDomain = mapper.Map<Habit>(addHabitDto);

            habitDomain = await repository.AddAsync(habitDomain);

            var habitDto = mapper.Map<HabitDto>(habitDomain);

            return habitDto;
        }

        public async Task<List<HabitDto>> GetHabitsAsync()
        {
            var habitDomain = await repository.GetAllAsync();

            var habitDto = mapper.Map<List<HabitDto>>(habitDomain);

            return habitDto;

        }
        public async Task<HabitDto?> RemoveByIdAsync(Guid id)
        {
            var habitById = await repository.DeleteAsync(id);
            if (habitById == null)
            {
                return null;
            }
            else
            {
                var habitDto = mapper.Map<HabitDto>(habitById);
                return habitDto;
            }

        }

        public async Task<List<HabitDto>?> RemoveAllAsync()
        {
            var habitsDomain = await repository.DeleteAllAsync();

            if (habitsDomain == null) {
                return null;
            }

            var habitsDto = mapper.Map<List<HabitDto>>(habitsDomain);
            return habitsDto;
        }



    }
}
