using System;
using LR2Library;

namespace LR2.OOP.The_Final
{
    public class Program
    {
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

                Person inputperson = new Person(InputName("Name: "),
                    InputName("Surname: "), InputAge(), InputGender());
                Console.WriteLine();

                list1.Add(inputperson);

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
            for (int i = 0; i < personlist.Count; i++)
            {
                Console.WriteLine(personlist.Info[i]);
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
        private static bool QuitOfProgram()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to continue or Esc to exit...");
            Console.ResetColor();
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.Escape)
            {
                return true; 
            }
            return false;
        }

        /// <summary>
        /// Ввод фамилии или имени с проверкой
        /// </summary>
        /// <param name="message">Название вводимых данных</param>
        /// <returns>Проверенное и приведенное к нужному виду значение</returns>
        private static string InputName(string message)
        {
            try 
            {
                Console.Write(message);
                return Person.CheckName(Console.ReadLine());
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message + " Please enter again.");
                return InputName(message);
            }
        }

        /// <summary>
        /// Ввод возраста с проверкой
        /// </summary>
        /// <param name="message">Название вводимых данных</param>
        /// <returns>Проверенное и приведенное к нужному виду значение</returns>
        private static int InputAge()
        {
            try
            {
                int value;
                Console.Write("Age: ");
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    throw new ArgumentException($"{nameof(Person.Age)} should not contain symbols!");
                }
                return Person.CheckAge(value);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + " Please enter again.");
                return InputAge();
            }
        }

        /// <summary>
        /// Ввод пола человека
        /// </summary>
        /// <returns>Приведенное к нужному виду значение</returns>
        private static Gender InputGender()
        {
            try
            {
                Console.Write("Gender (enter M/F): ");

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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + " Please enter again.");
                return InputGender();
            }
        }
    }
}
