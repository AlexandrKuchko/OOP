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
			set => _founder = ValidateEmptyOrNull(value, nameof(Founder));
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
			set => _type = ValidateNullEmptyEnglish(value, nameof(Type), @"^[-a-zA-Z\s]*$");
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
			set => _mainEditor = ValidateNullEmptyEnglish(value, nameof(MainEditor), @"^[-.a-zA-Z\s]*$");
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
		public override string Info =>
            $"{Name}: {Type} / {Founder} ; {MainEditor}. - {Place}" +
            $", {Year}. - {PageLimits}.";
    }
}
