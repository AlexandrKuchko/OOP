﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryLR3LR4
{
	/// <summary>
	/// Сборник
	/// </summary>
	class Collection : EditionBase
	{

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
				_publisher = ValidateEmptyOrNull(value);
			}
		}

		/// <summary>
		/// Название конференции
		/// </summary>
		public string _nameOfConference;

		/// <summary>
		/// Название конференции
		/// </summary>
		public string NameOfConference
		{
			get => _nameOfConference;
			set
			{
				_nameOfConference = ValidateEmptyOrNull(value);
	        }
		}

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="name">Название</param>
		/// <param name="nameOfConference">Название конференции</param>
		/// <param name="place">Место издания</param>
		/// <param name="publisher">Издательство</param>
		/// <param name="year">Год издания</param>
		/// <param name="pageLimits">Количество страниц</param>
		public Collection(string name, string nameOfConference, string place,
			string publisher, string year, string pageLimits)
		{
			Name = name;
			NameOfConference = nameOfConference;
			Place = place;
			Publisher = publisher;
			Year = year;
			PageLimits = pageLimits;
		}

		/// <summary>
		/// Информация о сборнике
		/// </summary>
		public override string Info()
		{
			return $"{Name}: {NameOfConference}. - {Place}: {Publisher}," +
				$" {Year}. - {PageLimits}";
		}
	}
}
