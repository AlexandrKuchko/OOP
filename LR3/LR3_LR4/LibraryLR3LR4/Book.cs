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
			set =>_mainAuthor = ValidateNullEnglish(value, nameof(MainAuthor), @"^[-.,a-zA-Z\s]*$");
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
			set => _type = ValidateNullEnglish(value, nameof(Type), @"^[-a-zA-Z\s]*$");
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
			set => _secondAuthor = ValidateNullEnglish(value, nameof(MainAuthor), @"^[-.,a-zA-Z\s]*$");
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
			set => _publisher = ValidateEmptyOrNull(value, nameof(Publisher));
		}

		/// <summary>
		/// Дополнительные сведения
		/// </summary>
		public string AdditionalInformation { get; set; }

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

				string additionalInformation = string.IsNullOrEmpty(AdditionalInformation)
					? ""
					: " - " + AdditionalInformation + ".";

				return $"{mainAuthor}{Name}{type}{secondAuthors}. - {Place}.: {Publisher}" +
					$", {Year}. - {PageLimits}.{additionalInformation}";
			}
		}
	}
}
