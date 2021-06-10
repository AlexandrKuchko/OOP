using System;
using LibraryLR3LR4;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;


namespace LR3_ConsoleApp
{
	/// <summary>
	/// Консольный ввод-вывод
	/// </summary>
	class Program
	{
		/// <summary>
		/// Вход в программу
		/// </summary>
		public static void Main(string[] args)
		{

			while (true)
			{

				Console.WriteLine("Creating a new list of edition.");
				Console.WriteLine();

				List <EditionBase> editionBaseList = new List<EditionBase>();

				PressAnyKey();

				Console.WriteLine("Add a new edition.");
				Console.WriteLine();

				editionBaseList.Add(InputEdition());
				
				Console.WriteLine("Edition add in list of edition.");
				Console.WriteLine();

				PressAnyKey();

				DisplayOrPrint(editionBaseList);

				PressAnyKey();

				if (QuitOfProgram())
				{
					return;
				}
			}
		}

		/// <summary>
		/// Вывод информации об изданиях из списка в консоль
		/// </summary>
		/// <param name="name">Название списка</param>
		/// <param name="editionlist">Спискок изданий</param>
		private static void Print(string name, List<EditionBase> editionlist)
		{
			Console.WriteLine(name);
			Console.WriteLine();
			foreach (EditionBase edition in editionlist)
			{
				Console.WriteLine(edition.Info);
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
		/// Ввод персоны с клавиатуры
		/// </summary>
		/// <returns>Введённая персона</returns>
		private static EditionBase InputEdition()
		{
			Console.WriteLine($"What edition you want to add? \n" +
				$"Press B to enter the book; \n" +
				$"Press M to enter the magazine; \n" +
				$"Press T to enter the thesis; \n" +
				$"Press C to enter the collection.");
			Console.WriteLine();

			EditionBase tmpEdition;

			while (true)
			{
				try
				{
					tmpEdition = GetDefaultEdition();

					List<PropertyInfo> propertyInfo = PropertyInfo(tmpEdition);

					for (int i = 0; i < propertyInfo.Count; i++)
					{
						foreach (var tuple in PropertyNameList)
                        {
							if (propertyInfo[i].Name == tuple.Item2 )
                            {
								Console.WriteLine(tuple.Item1);
								Console.WriteLine();
							}
                        }
						AssigningValue(tmpEdition, propertyInfo[i].Name);
					}
					break;
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message + " Please enter again.");
					Console.WriteLine();
				}
			}
			return tmpEdition;
		}

		/// <summary>
		/// Присвоение значения свойству класса 
		/// </summary>
		/// <param name="editionBase">Объект нужного издания 
		/// по ссылке на EditionBase</param>
		/// <param name="name">Имя свойства для строкового индексатора</param>
		private static void AssigningValue(EditionBase editionBase, string name)
		{
			while (true)
			{
				try
				{
					editionBase[name] = Console.ReadLine();
					break;
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.InnerException.Message + " Please enter again.");
					Console.WriteLine();
				}
			}
		}

		/// <summary>
		/// Получение листа с информацией о свойствах класса без Info
		/// </summary>
		/// <param name="editionBase">Объект нужного издания 
		/// по ссылке на EditionBase</param>
		private static List<PropertyInfo> PropertyInfo(EditionBase editionBase)
		{
			var propertyInfo = new List<PropertyInfo>();
			foreach (var info in editionBase.GetType().GetProperties())
			{
				if (info.Name == nameof(EditionBase.Info) || info.Name == "Item")
				{
					continue;
				}
				propertyInfo.Add(info);
			}
			return propertyInfo;
		}

		/// <summary>
		/// Выдаёт нужный объект издания для присвания в 
		/// зависимости от введённого значения
		/// </summary>
		/// <returns>Нужный объект издания</returns>
		private static EditionBase GetDefaultEdition()
		{
						return Console.ReadLine() switch
			{
				var enterValue when
				enterValue == "B" || enterValue == "b" ||
				enterValue == "и" || enterValue == "И" => new Book(),

				var enterValue when
				enterValue == "Е" || enterValue == "е" ||
				enterValue == "T" || enterValue == "t" => new Thesis(),

				var enterValue when
				enterValue == "С" || enterValue == "с" ||
				enterValue == "C" || enterValue == "c" => new Collection(),

				var enterValue when
				enterValue == "Ь" || enterValue == "ь" ||
				enterValue == "M" || enterValue == "m" => new Magazine(),

				_=> throw new ArgumentException($"Incorrect input!")
			};
		}

		/// <summary>
		/// Вывод листа или ввод нового издания
		/// </summary>
		/// <param name="editionBaseList">Лист с изданиями</param>
		private static void DisplayOrPrint(List<EditionBase> editionBaseList)
		{
			while (true)
			{
				try
				{
					Console.WriteLine($"Do you want to add another edition or display a list? \n" +
					$"Press A to add edition; \n" +
					$"Press D to display a list.");
					Console.WriteLine();

					switch (Console.ReadLine())
					{
						case ("D"):
						case ("d"):
						case ("в"):
						case ("В"):
						{
							Print("List of edition", editionBaseList);
							return;
						}

						case ("A"):
						case ("a"):
						case ("ф"):
						case ("Ф"):
						{
							editionBaseList.Add(InputEdition());
							DisplayOrPrint(editionBaseList);
							return;
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
					Console.WriteLine();
				}
			}
		}

		/// <summary>
		/// Список для понятного именования полей
		/// </summary>
		private static readonly List<Tuple<string, string>> PropertyNameList 
            = new List<Tuple<string, string>>()
		{
			new Tuple<string, string>
			(
				"Limit pages in edition: ",
				nameof(EditionBase.PageLimits)
			),
            new Tuple<string, string>
			(
			"Year of issue: ",
			nameof(EditionBase.Year)
			),

			new Tuple<string, string>
			(
			"Name of edition: ",
			nameof(EditionBase.Name)
			),

			new Tuple<string, string>
			(
			"Place of publication: ",
			nameof(EditionBase.Place)
			),

			new Tuple<string, string>
			(
			"The main author of the book: ",
			nameof(Book.MainAuthor)
			),

			new Tuple<string, string>
			(
			"The other author of the book: ",
			nameof(Book.SecondAuthor)
			),

			new Tuple<string, string>
			(
			"Type of edition: ",
			nameof(Book.Type)
			),

			new Tuple<string, string>
			(
			"Publisher of edition: ",
			nameof(Book.Publisher)
			),

			new Tuple<string, string>
			(
			"Additional information about the book: ",
			nameof(Book.AdditionalInformation)
			),

			new Tuple<string, string>
			(
			"Name of the conference for which the collection: ",
			nameof(Collection.NameOfConference)
			),

			new Tuple<string, string>
			(
			"Author of the thesis: ",
			nameof(Thesis.Author)
			),

			new Tuple<string, string>
			(
			"Specialization of the thesis: ",
			nameof(Thesis.Specialization)
			),

			new Tuple<string, string>
			(
			"University which published thesis: ",
			nameof(Thesis.University)
			),

			new Tuple<string, string>
			(
			"Founder of the magazine: ",
			nameof(Magazine.Founder)
			),

			new Tuple<string, string>
			(
			"Main editor of the magazine: ",
			nameof(Magazine.MainEditor)
			)
		};
	}
}
