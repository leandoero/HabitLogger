using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HabitLogger.Models.DTO;
using Microsoft.IdentityModel.Tokens;

namespace HabitLogger.Logic
{
    public class App
    {
        private readonly HabitMethods methods;

        public App(HabitMethods methods)
        {
            this.methods = methods;
        }
        public async Task RunAsync()
        {
            int userChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. View habits\n2. Add the habit\n" +
            "3. Remove the habit\n4. Remove all habits\n" +
            "5. Update the habit\n6. Exit\n\n");

                while (true)
                {
                    Console.Write("Input:");
                    if (int.TryParse(Console.ReadLine(), out userChoice))
                    {
                        if (userChoice <= 6 && userChoice >= 1)
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
                        Console.Clear();
                        var habits = await methods.GetHabitsAsync();

                        foreach (var item in habits)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"ID: {item.Id}");
                            Console.WriteLine($"Title: {item.Title}");
                            Console.WriteLine($"Description: {item.Description}");
                            Console.WriteLine($"Created time: {item.CreatedTime}");
                            Console.WriteLine($"Completed status: {item.IsCompleted}");
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        Console.WriteLine("To continue click Enter on the keyboard");
                        Console.ReadLine();

                        break;
                    case 2:
                        var addHabitDto = new AddHabitDto();
                        while (true)
                        {
                            Console.Clear();
                            do
                            {
                                Console.Write("Title: ");
                                string inputChoice = Console.ReadLine();
                                if (!IsValidInput(inputChoice, out string titleError))
                                {
                                    Console.WriteLine(titleError);
                                }
                                else
                                {
                                    addHabitDto.Title = inputChoice;
                                }
                            } while (addHabitDto.Title.IsNullOrEmpty());

                            do
                            {
                                Console.Write("Description: ");
                                string inputForDescription = Console.ReadLine();
                                if (!IsValidInput(inputForDescription, out string descriptionError))
                                {
                                    Console.WriteLine(descriptionError);
                                }
                                else
                                {
                                    addHabitDto.Description = inputForDescription;
                                }
                            } while (addHabitDto.Description.IsNullOrEmpty());


                            addHabitDto.CreatedTime = DateTime.Now;
                            Console.Clear();
                            Console.Write($"Title:{addHabitDto.Title}\nDescription:{addHabitDto.Description}\n" +
                                $"\nRight?   y/n\n\n");
                            string choice;
                            do
                            {
                                Console.Write("Input: ");
                                choice = Console.ReadLine();
                            } while (choice.ToUpper() != "Y" && choice.ToUpper() != "N");
                            if (choice.ToUpper() == "Y")
                            {
                                await methods.CreateHabitAsync(addHabitDto);
                                break;
                            }
                            else if (choice.ToUpper() == "N")
                            {
                                break;
                            }
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Введите ID (GUID): ");
                            string inputForCase = Console.ReadLine();

                            if (Guid.TryParse(inputForCase, out Guid id))
                            {
                                var habit = await methods.RemoveByIdAsync(id);

                                if (habit != null)
                                {
                                    Console.WriteLine("\nRemoved:\n");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"ID: {habit.Id}");
                                    Console.WriteLine($"Title: {habit.Title}");
                                    Console.WriteLine($"Description: {habit.Description}");
                                    Console.WriteLine($"Created time: {habit.CreatedTime}");
                                    Console.WriteLine($"Completed status: {habit.IsCompleted}");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    Console.WriteLine("To continue click Enter on the keyboard");
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("The habit is not found\n");
                                    Console.WriteLine("To continue click Enter on the keyboard");
                                    Console.ReadLine();
                                    break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Incorrect GUID format.");
                            }
                        }
                        break;
                    case 4:
                        Console.Clear();

                        Console.WriteLine("Are you sure? This command will destroy all records! Remove? y/n");
                        while (true)
                        {
                            Console.Write("Input:");
                            string input = Console.ReadLine();
                            if (input.ToUpper() == "Y")
                            {
                                Console.Clear();

                                var habitsAll = await methods.RemoveAllAsync();
                                if (habitsAll != null)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("\n\nLoading: [");
                                    int total = 20;

                                    for (int i = 0; i <= total; i++)
                                    {
                                        Console.SetCursorPosition(11 + i, Console.CursorTop);
                                        Console.Write("=");
                                        Thread.Sleep(100);
                                    }

                                    Console.WriteLine(" ] All habits are removed!");
                                    Console.ResetColor();
                                    Console.WriteLine("\nTo return to the menu click Enter");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("There are no records!");
                                    Console.WriteLine("To return to the menu click Enter");
                                    Console.ReadLine();
                                    Console.ResetColor();
                                    break;
                                }

                                break;
                            }
                            else if (input.ToUpper() == "N")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input!");
                            }

                        }
                        break;
                    case 5:
                        break;
                }
            } while (userChoice != 6);
        }


        public bool IsValidInput(string input, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "The name cannot be empty or consist only of spaces.";
                return false;
            }
            if (!input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                errorMessage = "The name may contain only letters and gaps.";
                return false;
            }
            errorMessage = string.Empty; // Нет ошибок
            return true;
        }
    }
}
