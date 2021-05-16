using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryLR3LR4
{

	/// <summary>
	/// Диссертация
	/// </summary>
	[Serializable]
	public class Thesis: EditionBase
    {
		/// <summary>
		/// Главный автор
		/// </summary>
		private string _author;

		/// <summary>
		/// Главный автор
		/// </summary>
		public string Author
		{
			get => _author;
			set
			{
				_author = ValidateAuthor(value, nameof(Author));
			}
		}

		/// <summary>
		/// Тип диссертиции
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
				_type = ValidateTypeOrSpecialization(value, nameof(Type));
			}
		}

		/// <summary>
		/// Соавтор(ы)
		/// </summary>
		private string _specialization;

		/// <summary>
		/// Соавтор(ы)
		/// </summary>
		public string Specialization
		{
			get => _specialization;
			set
			{
				_specialization = ValidateTypeOrSpecialization(value, nameof(Specialization));
			}
		}

		/// <summary>
		/// Университет
		/// </summary>
		private string _university;

		/// <summary>
		/// Университет
		/// </summary>
		public string University
		{
			get => _university;
			set
			{
				_university = ValidateEmptyOrNull(value, nameof(University));
			}
		}

		/// <summary>
		/// Проверка автора
		/// </summary>
		/// <param name="value">Имя или имена авторов</param>
		/// <returns>Имя или имена авторов</returns>
		private string ValidateAuthor(string value, string name)
		{
			if (value == "" || value == null)
			{
				throw new ArgumentException($"{name} should not be empty!");
			}

			const string pattern = @"^[-.a-zA-Z\s]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"{name} must be in English!");
			}
			return value;
		}

		/// <summary>
		/// Проверка типа издания или специализации
		/// </summary>
		/// <param name="value">Тип издания или специализация</param>
		/// <returns>Тип издания или специализация</returns>
		private string ValidateTypeOrSpecialization(string value, string name)
		{
			if (value == "" || value == null)
			{
				throw new ArgumentException($"{name} should not be empty!");
			}

			const string pattern = @"^[-""a-zA-Z\s]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"{name} must be in English!");
			}
			return value;
		}

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="author">Автор</param>
		/// <param name="name">Название</param>
		/// <param name="type">Тип</param>
		/// <param name="specialization">Специализация исследования</param>
		/// <param name="place">Место издания</param>
		/// <param name="university">Университет</param>
		/// <param name="year">Год издания</param>
		/// <param name="pageLimits">Количество страниц</param>
		public Thesis(string author, string name, string type, string specialization, string place,
			string university, string year, string pageLimits)
		{
			Author = author;
			Name = name;
			Type = type;
			Specialization = specialization;
			Place = place;
			University = university;
			Year = year;
			PageLimits = pageLimits;
		}

		/// <summary>
		/// Конструктор класса пустой
		/// </summary>
		public Thesis()
		{

		}

		/// <summary>
		/// Информация о диссертации
		/// </summary>
		public override string Info
		{
			get
			{
				return $"{Author}. {Name}: {Specialization}: {Type} ; {University}. - {Place}" +
					$", {Year}. - {PageLimits}.";
			}
		}
	}
}
