using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Reflection;
using System.Xml.Serialization;

namespace LibraryLR3LR4
{
	/// <summary>
	/// Издание (книга, сборник, журнал, статья)
	/// </summary>
	[Serializable]
    [XmlInclude(typeof(Book))]
    [XmlInclude(typeof(Collection))]
    [XmlInclude(typeof(Magazine))]
    [XmlInclude(typeof(Thesis))]
	public abstract class EditionBase
	{
		/// <summary>
		/// Название издания
		/// </summary>
		private string _name;

		/// <summary>
		/// Место издания
		/// </summary>
		public string Name
		{
			get => _name;
			set => _name = ValidateEmptyOrNull(value, nameof(Name));
        }

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
			set => _place = ValidatePlace(value, nameof(Place));
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
			set => _year = ValidateYearOrPageLimits(value, nameof(Year));
        }

		/// <summary>
		/// Количество страниц издания
		/// </summary>
		private string _pageLimits;

		/// <summary>
		/// Количество страниц издания
		/// </summary>
		public string PageLimits
		{
			get => _pageLimits;
			set => _pageLimits = ValidateYearOrPageLimits(value, nameof(PageLimits));
        }

		/// <summary>
		/// Информация об издании
		/// </summary>
		public abstract string Info { get; }
		
		/// <summary>
		/// Текстовый индексатор
		/// </summary>
		public object this[string propertyName]
		{
			get
			{
				// probably faster without reflection:
				// like:  return Properties.Settings.Default.PropertyValues[propertyName] 
				// instead of the following
				Type myType = this.GetType();
				PropertyInfo myPropInfo = myType.GetProperty(propertyName);
				return myPropInfo.GetValue(this, null);
			}
			set
			{
				Type myType = this.GetType();
				PropertyInfo myPropInfo = myType.GetProperty(propertyName);
				myPropInfo.SetValue(this, value, null);
			}
		}
		
		/// <summary>
		/// Проверка места изданя
		/// </summary>
		/// <param name="value">Место издания</param>
		/// /// <returns>Строка (имя или фамилия) приведенная к нужномк виду</returns>
		private string ValidatePlace(string value, string name)
		{
			if (value == "" || value == null)
			{
				throw new ArgumentException($"{name} should not be empty!");
			}

			const string pattern1 = @"^[a-z]+$";
			const string pattern2 = @"^[a-z]+-[a-z]+$";

			if (!Regex.IsMatch(value, pattern1, RegexOptions.IgnoreCase)
				&& !Regex.IsMatch(value, pattern2, RegexOptions.IgnoreCase))
			{
				throw new ArgumentException($"{name} should contain only Latin and one hyphen!");
			}
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
		}

		/// <summary>
		/// Проверка года и количеств страниц
		/// </summary>
		/// <param name="value">Год или количество страниц</param>
		/// <param name="name">Название вводимой величины</param>
		/// <returns>Год или количество страниц</returns>
		private string ValidateYearOrPageLimits(string value, string name)
		{
			//TODO: string.IsNullOrEmpty
			if (value == "" || value == null)
			{
				throw new ArgumentException($"{name} should not be empty!");
			}

			const string pattern = @"^[0-9]*$";

			if (!Regex.IsMatch(value, pattern))
			{
				throw new ArgumentException($"{name} must only contain numbers!");
			}
			return value;
		}

		/// <summary>
		/// Проверка на пустую строку и null
		/// </summary>
		/// <param name="value">Входная величина</param>
		/// <returns>Выходная величина</returns>
		protected string ValidateEmptyOrNull(string value, string name)
		{
            //TODO: string.IsNullOrEmpty
			if (value == "" || value == null)
			{
				throw new ArgumentException($"{name} should not be empty!");
			}
			return value;
		}
	}
}
