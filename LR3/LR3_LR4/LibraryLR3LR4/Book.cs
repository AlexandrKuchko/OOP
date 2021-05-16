using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryLR3LR4
{
	/// <summary>
	/// Книга
	/// </summary>
	[Serializable]
	public class Book : EditionBase
	{

		/// <summary>
		/// Главный автор
		/// </summary>
		private string _mainAuthor;

		/// <summary>
		/// Главный автор
		/// </summary>
		public string MainAuthor
		{
			get => _mainAuthor;
			set
			{
				_mainAuthor = ValidateAuthor(value, nameof(MainAuthor));
			}
		}

		/// <summary>
		/// Тип книги
		/// </summary>
		private string _type;

		/// <summary>
		/// Тип книги
		/// </summary>
		public string Type
		{
			get => _type;
			set
			{
				_type = ValidateType(value, nameof(Type));
			}
		}

		/// <summary>
		/// Соавтор(ы)
		/// </summary>
		private string _secondAuthor;

		/// <summary>
		/// Соавтор(ы)
		/// </summary>
		public string SecondAuthor
		{
			get => _secondAuthor;
			set
			{
				_secondAuthor = ValidateAuthor(value, nameof(SecondAuthor));
			}
		}

		/// <summary>
		/// Издательство
		/// </summary>
		private string _publisher;

		/// <summary>
		/// Издательство
		/// </summary>
		public string Publisher
		{
			get => _publisher;
			set
			{
				_publisher = ValidateEmptyOrNull(value, nameof(Publisher));
			}
		}

		/// <summary>
		/// Дополнительные сведения
		/// </summary>
		public string AdditionalInformation { get; set; }

		/// <summary>
		/// Проверка автора
		/// </summary>
		/// <param name="value">Имя или имена авторов</param>
		/// <param name="value">Название проверяемой величины</param>
		/// <returns>Имя или имена авторов</returns>
		private string ValidateAuthor(string value, string name)
		{
			if (value == null)
			{
				throw new ArgumentException($"{name} should not be null!");
			}

			const string pattern = @"^[-.,a-zA-Z\s]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"{name} must be in English!");
			}
			return value;
		}

		/// <summary>
		/// Проверка типа издания
		/// </summary>
		/// <param name="value">Тип издания</param>
		/// <returns>Тип издания</returns>
		private string ValidateType(string value, string name)
		{
			if (value == null)
			{
				throw new ArgumentException($"{name} should not be null!");
			}

			const string pattern = @"^[-a-zA-Z\s]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"{name} must be in English!");
			}
			return value;
		}

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="mainAuthor">Главный автор</param>
		/// <param name="name">Название</param>
		/// <param name="type">Тип</param>
		/// <param name="secondAuthor">Со-авторы</param>
		/// <param name="place">Место издания</param>
		/// <param name="publisher">Издательство</param>
		/// <param name="year">Год издания</param>
		/// <param name="pageLimits">Количество страниц</param>
		/// <param name="additionalInformation">Дополнительная информация</param>
		public Book(string mainAuthor, string name, string type, string secondAuthor, string place,
			string publisher, string year, string pageLimits, string additionalInformation)
		{
			MainAuthor = mainAuthor;
			Name = name;
			Type = type;
			SecondAuthor = secondAuthor;
			Place = place;
			Publisher = publisher;
			Year = year;
			PageLimits = pageLimits;
			AdditionalInformation = additionalInformation;
		}

		/// <summary>
		/// Конструктор класса для сериализации
		/// </summary>
		public Book()
		{

		}

		/// <summary>
		/// Информация о книге
		/// </summary>
		public override string Info
		{
			get
			{
				string mainAuthor = MainAuthor == ""
					? ""
					: MainAuthor + " ";

				string type = Type == ""
					? ""
					: ": " + Type + ",";

				string slash = Type == ""
					? ": "
					: " / ";

				string secondAuthors = SecondAuthor == ""
					? ""
					: slash + SecondAuthor;

				string additionalInformation = (AdditionalInformation == "") || (AdditionalInformation == null)
					? ""
					: " - " + AdditionalInformation + ".";

				return $"{mainAuthor}{Name}{type}{secondAuthors}. - {Place}.: {Publisher}" +
					$", {Year}. - {PageLimits}.{additionalInformation}";
			}
		}
	}
}
