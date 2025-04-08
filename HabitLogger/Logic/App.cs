using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HabitLogger.Models.DTO;

namespace HabitLogger.Logic
{
    public class App
    {
        private readonly HabitMethods methods;

        public App(HabitMethods methods) {
            this.methods = methods;
        }
        public void Run()
        {
           
           
            Console.WriteLine("1. View habits\n2. Add the habit\n" +
            "3. Fire the habit of\n4. Complete the habit\n" +
            "5. Exit\n\n");

            int userChoice = 0;

            while (true)
            {
                Console.Write("Input:");
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    if (userChoice <= 5 && userChoice >= 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input. Try again");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again");
                }
            }

            switch (userChoice)
            {
                case 1:
                    methods.GetHabits();
                    break;
                case 2:
                    var addHabitDto = new AddHabitDto();
                    addHabitDto.Title = Console.ReadLine();
                    addHabitDto.Description = Console.ReadLine();
                    addHabitDto.CreatedTime = DateTime.Now;
                    methods.CreateHabit(addHabitDto);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }
    }
}
