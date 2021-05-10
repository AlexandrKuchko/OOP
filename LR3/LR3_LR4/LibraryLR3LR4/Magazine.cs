using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryLR3LR4
{
	/// <summary>
	/// Журнал
	/// </summary>
	[Serializable]
	public class Magazine : EditionBase
	{

		/// <summary>
		/// Учредитель журнала
		/// </summary>
		private string _founder;

		/// <summary>
		/// Учредитель журнала
		/// </summary>
		public string Founder
		{
			get => _founder;
			set
			{
				_founder = ValidateEmptyOrNull(value);
			}
		}

		/// <summary>
		/// Тип журнала
		/// </summary>
		private string _type;

		/// <summary>
		/// Тип журнала
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
		/// Главный редактор
		/// </summary>
		private string _mainEditor;

		/// <summary>
		/// Главный редактор
		/// </summary>
		public string MainEditor
		{
			get => _mainEditor;
			set
			{
				_mainEditor = ValidateEditor(value);
			}
		}

		/// <summary>
		/// Проверка редактора
		/// </summary>
		/// <param name="value">Имя главного редактора</param>
		/// <returns>Имя главного редактора</returns>
		private string ValidateEditor(string value)
		{
			if (value == "" || value == null)
			{
				throw new ArgumentException($"Value should not be empty!");
			}

			const string pattern = @"^[-.a-zA-Z\s]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"The name must be in English!");
			}
			return value;
		}

		/// <summary>
		/// Проверка типа издания
		/// </summary>
		/// <param name="value">Тип издания</param>
		/// <returns>Тип издания</returns>
		private string ValidateType(string value)
		{
			if (value == "" || value == null)
			{
				throw new ArgumentException($"Value should not be empty!");
			}

			const string pattern = @"^[-a-zA-Z\s]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"The name must be in English!");
			}
			return value;
		}

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="name">Название</param>
		/// <param name="type">Тип</param>
		/// <param name="founder">Учредитель</param>
		/// <param name="place">Место издания</param>
		/// <param name="mainEditor">Главный редактор</param>
		/// <param name="year">Год издания</param>
		/// <param name="pageLimits">Количество страниц</param>
		public Magazine(string name, string type, string founder, string place,
			string mainEditor, string year, string pageLimits)
		{
			Name = name;
			Type = type;
			Founder = founder;
			Place = place;
			MainEditor = mainEditor;
			Year = year;
			PageLimits = pageLimits;
		}

		/// <summary>
		/// Конструктор класса пустой
		/// </summary>
		public Magazine()
		{

		}

		/// <summary>
		/// Информация о журнале
		/// </summary>
		public override string Info()
		{
			return $"{Name}: {Type} / {Founder} ; {MainEditor}. - {Place}" +
				$", {Year}. - {PageLimits}.";
		}
	}
}
