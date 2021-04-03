using System;
using LR2Library;
using System.Linq;
using System.Collections.Generic;

namespace LR2.OOP.The_Final
{
    /// <summary>
    /// Работа с консолью
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Вход в программу
        /// </summary>
        public static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Creating two lists:");
                Console.WriteLine();

                PersonList list1 = RandomPerson.GetRandomPersonList(3);

                PersonList list2 = RandomPerson.GetRandomPersonList(3);

                Print("list1", list1);

                Print("list2", list2);

                PressAnyKey();

                Console.WriteLine("Add a new person to the first list.");
                Console.WriteLine();

                list1.Add(InputPerson());

                Console.WriteLine("Copy the second person from the " +
                    "first list to the end of the second list.");
                Console.WriteLine();

                list2.Add(list1[1]);

                Print("list1", list1);

                Print("list2", list2);

                PressAnyKey();

                Console.WriteLine("Removing the second person from the first list.");
                Console.WriteLine();

                list1.Delete(1);

                Print("list1", list1);

                Print("list2", list2);

                PressAnyKey();

                Console.WriteLine("Removing the second list.");
                Console.WriteLine();

                list2.AllDelete();

                Print("list1", list1);

                Print("list2", list2);

                if (QuitOfProgram())
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Вывод списка PersonList в консоль
        /// </summary>
        /// <param name="name">Название списка</param>
        /// <param name="personlist">Выводимый элемент PersonList</param>
        private static void Print(string name, PersonList personlist)
        {
            Console.WriteLine(name);
            foreach (string info in personlist.Info)
            {
                Console.WriteLine(info);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Нажмите клавишу чтобы продолжить
        /// </summary>
        private static void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
            Console.WriteLine();
        }

        /// <summary>
        /// Выход из программы или продолжение выполнения
        /// </summary>
        /// <returns>true если нажат Esc, false если любая другая клавиша</returns>
        private static bool QuitOfProgram()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to continue or Esc to exit...");
            Console.ResetColor();
            var key = Console.ReadKey();
            Console.WriteLine();

            return key.Key == ConsoleKey.Escape;
        }

        /// <summary>
        /// Ввод возраста персоны с проверкой
        /// </summary>
        /// <returns>Возраст персоны</returns>
        private static int InputAge()
        {
            int inputValue;
            if (!int.TryParse(Console.ReadLine(), out inputValue))
            {
                throw new ArgumentException($"{nameof(Person.Age)} should not contain symbols!");
            }
            return inputValue;
        }

        /// <summary>
        /// Ввод пола человека с клавиатуры
        /// </summary>
        /// <returns>Гендер персоны</returns>
        private static Gender InputGender()
        {
            switch (Console.ReadLine())
            {
                case ("m"):
                case ("M"):
                case ("ь"):
                case ("Ь"):
                {
                    return Gender.Male;
                }

                case ("F"):
                case ("f"):
                case ("а"):
                case ("А"):
                {
                    return Gender.Female;
                }

                default:
                {
                    throw new ArgumentException($"Incorrect input!");
                }
            }
        }

        /// <summary>
        /// Ввод персоны с клавиатуры
        /// </summary>
        /// <returns>Введённая персона</returns>
        private static Person InputPerson()
        {
            Person inputperson = new Person("default", "default", 1, Gender.Male);

            var validationAction = new List<Tuple<string, Action>>()
            {
                new Tuple<string, Action>
               (
               "Name: ",
               () =>
               {
                   inputperson.Name = Console.ReadLine();
               }
               ),

               new Tuple<string, Action>
               (
               "Surname: ",
               () =>
               {
                   inputperson.Surname = Console.ReadLine();
               }
               ),

               new Tuple<string, Action>
               (
               "Age: ",
               () =>
               {
                   inputperson.Age = InputAge();
               }
               ),

               new Tuple<string, Action>
               (
               "Gender (enter M/F): ",
               () =>
               {
                   inputperson.Gender = InputGender();
               }
               )
            };
                        
            foreach(var action in validationAction)
            {
                ValidateInput(action.Item1, action.Item2);
            }

          return inputperson;
        }

        /// <summary>
        /// Проверка ввода на всплывающие ошибки
        /// </summary>
        private static void ValidateInput(string message, Action input)
        {                
            while (true)
            {    
                try
                {
                    Console.Write(message);
                    input.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message + " Please enter again.");
                }
            }
        }
    }
}
