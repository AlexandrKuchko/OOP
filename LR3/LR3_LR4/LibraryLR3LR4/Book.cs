using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryLR3LR4
{
	class Book : EditionBase
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
				_mainAuthor = ValidateAuthor(value);
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
				_type = ValidateType(value);
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
			get => _mainAuthor;
			set
			{
				_secondAuthor = ValidateAuthor(value);
			}
		}

		/// <summary>
		/// Издательство
		/// </summary>
		public string Publisher { get;}

		/// <summary>
		/// Дополнительные сведения
		/// </summary>
		public string AdditionalInformation { get; }

		/// <summary>
		/// Проверка паспортных данных
		/// </summary>
		/// <param name="value">Название учебного заведения</param>
		/// <returns>Название учебного заведения</returns>
		private string ValidateAuthor(string value)
		{
			if (value == null)
			{
				throw new ArgumentException($"Value should not be NULL!");
			}

			const string pattern = @"^[-.,a-zA-Z\s]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"The name must be in English!");
			}
			return value;
		}

		private string ValidateType(string value)
		{
			if (value == null)
			{
				throw new ArgumentException($"Value should not be NULL!");
			}

			const string pattern = @"^[-a-zA-Z\s]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"The name must be in English!");
			}
			return value;
		}

		/// <summary>
		/// Название издания
		/// </summary>
		public override string Info()
		{
			throw new NotImplementedException();
		}




	}
}
