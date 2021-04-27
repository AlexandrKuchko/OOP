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

				Console.WriteLine("Add a new list.");
				Console.WriteLine();

				PersonList personList = new PersonList();
				PersonListAdd(personList, RandomPerson.GetRandomAdult());
				PersonListAdd(personList, RandomPerson.GetRandomChild());
				PersonListAdd(personList, RandomPerson.GetRandomAdult());
				PersonListAdd(personList, RandomPerson.GetRandomChild());

				Print("List 1", personList);

				switch (personList[3])
				{
					case Adult adult:
						{
							Console.WriteLine("Foutrth person is adult");
							adult.GoToWork("NewWork");
							break;
						}
					case Child child:
						{
							Console.WriteLine("Foutrth person is adult");
							child.GoToStudy("NewSchool");
							break;
						}
				}

				personList.Add(InputPerson());

				Print("List 1", personList);

				if (QuitOfProgram())
				{
					return;
				}

			}
		}

		/// <summary>
		/// Перетаскивание из одного листа в другой
		/// </summary>
		/// <param name="listOfPerson">Список персон</param>
		/// <param name="personlist">Список персон</param>
		private static void PersonListAdd(PersonList personlist, List<PersonBase> listOfPerson)
		{
			foreach (PersonBase person in listOfPerson)
			{
				personlist.Add(person);
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
			Console.WriteLine();
			foreach (string info in personlist.Info)
			{
				Console.WriteLine($"Person № {Array.IndexOf(personlist.Info, info)+1}");
				Console.WriteLine(info);
				Console.WriteLine();
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
				throw new ArgumentException($"{nameof(PersonBase.Age)} should not contain symbols!");
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
		private static PersonBase InputPerson()
		{
			Console.WriteLine("Do you want to add a child or an adult? (enter С/A)");

			bool personIsAdultFlag;
			while (true)
			{
				try
				{
					switch (Console.ReadLine())
					{
						case ("a"):
						case ("A"):
						case ("ф"):
						case ("Ф"):
							{
								personIsAdultFlag = true;
								break;
							}

						case ("c"):
						case ("C"):
						case ("с"):
						case ("С"):
							{
								personIsAdultFlag = false;
								break;
							}

						default:
							{
								throw new ArgumentException($"Incorrect input!");
							}
					}
					break;
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message + " Please enter again.");
				}
			}

			PersonBase inputperson = personIsAdultFlag
				? new Adult("default", "default", 18, Gender.Male, "0000000000", FamilyStatus.Single, null, null)
				: new Child("default", "default", 1, Gender.Male, null, null, null);

			var validationActionPerson = new List<Tuple<string, Action>>()
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

			ForEacher(validationActionPerson);

			switch (inputperson)
			{
				case Adult adult:
				{
					var validationActionAdult = new List<Tuple<string, Action>>()
					{
						new Tuple<string, Action>
						(
						"Passport data: ",
						() =>
						{
							adult.PassportData = Console.ReadLine();
						}
						),

						new Tuple<string, Action>
						(
						"Place of work: ",
						() =>
						{
							adult.PlaceOfWork = Console.ReadLine();
						}
						)
					};

					ForEacher(validationActionAdult);

					break;
				}
				case Child child:
				{
					var validationActionAdult = new List<Tuple<string, Action>>()
					{
						new Tuple<string, Action>
						(
						"Place of study: ",
						() =>
						{
							child.EducationalInstitutionName = Console.ReadLine();
						}
						)
					};

					ForEacher(validationActionAdult);

					break;
				}
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

		/// <summary>
		/// Передача делегатов
		/// </summary>
		private static void ForEacher(List<Tuple<string, Action>> validationAction)
		{
			foreach (var action in validationAction)
			{
				ValidateInput(action.Item1, action.Item2);
			}
		}
	}
}
