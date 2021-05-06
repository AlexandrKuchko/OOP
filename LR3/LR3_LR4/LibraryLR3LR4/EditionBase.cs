using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryLR3LR4
{
	/// <summary>
	/// Издание (книга, сборник, журнал, статья)
	/// </summary>
	public abstract class EditionBase
	{
		/// <summary>
		/// Название издания
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Место издания
		/// </summary>
		private string _place;

		/// <summary>
		/// Место издания
		/// </summary>
		public string Place
		{
			get => _place;
			set
			{
				_place = ValidatePlace(value);
			}
		}

		/// <summary>
		/// Год издания
		/// </summary>
		private string _year;

		/// <summary>
		/// Год издания
		/// </summary>
		public string Year
		{
			get => _year;
			set
			{
				_year = ValidateYearOrPageLimits(value);
			}
		}

		/// <summary>
		/// Год издания
		/// </summary>
		private string _pageLimits;

		/// <summary>
		/// Количество страниц издания
		/// </summary>
		public string PageLimits
		{
			get => _pageLimits;
			set
			{
				_pageLimits = ValidateYearOrPageLimits(value);
			}
		}

		/// <summary>
		/// Информация об издании
		/// </summary>
		public abstract string Info();

		/// <summary>
		/// Проверка места изданя
		/// </summary>
		/// <param name="value">Место издания</param>
		/// /// <returns>Строка (имя или фамилия) приведенная к нужномк виду</returns>
		private string ValidatePlace(string value)
		{
			if (value == "" || value == null)
			{
				throw new ArgumentException($"Value should not be empty!");
			}

			const string pattern1 = @"^[a-z]+$";
			const string pattern2 = @"^[a-z]+-[a-z]+$";

			if (!Regex.IsMatch(value, pattern1, RegexOptions.IgnoreCase)
				&& !Regex.IsMatch(value, pattern2, RegexOptions.IgnoreCase))
			{
				throw new ArgumentException($"Value should contain only Latin and one hyphen!");
			}
			return value;
		}

		/// <summary>
		/// Проверка года и количеств страниц
		/// </summary>
		/// <param name="value">Год или количество страниц</param>
		/// <returns>Год или количество страниц</returns>
		private string ValidateYearOrPageLimits(string value)
		{
			if (value == "" || value == null)
			{
				throw new ArgumentException($"Value should not be empty!");
			}

			const string pattern = @"^[0-9]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"The value must only contain numbers!");
			}
			return value;
		}


	}
}
