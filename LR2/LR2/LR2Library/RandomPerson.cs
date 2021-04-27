using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2Library
{

	/// <summary>
	/// Рандомный человек
	/// </summary>
	public static class RandomPerson
	{
		/// <summary>
		/// Список мужских имён
		/// </summary>
		private static List<string> _maleNames = new List<string>()
		{
			"Alexander", "Vladimir", "Oleg",
		   "Ruslan", "Eugene", "Artyom", "Vladimir",
		   "Michael", "Leonid", "Sergey"
		};

		/// <summary>
		/// Список женских имён
		/// </summary>
		private static List<string> _femaleNames = new List<string>()
		{
			"Valentina", "Eugene", "Alexandra",
		   "Irina", "Daria", "Maria", "Marina",
		   "Elizabeth", "Lily", "Anna"
		};

		/// <summary>
		/// Список фамилий
		/// </summary>
		private static List<string> _surnames = new List<string>()
		{
			"Blok", "Bach", "Tsiskaridze",
			 "Senda", "Hemingway", "Kuchko",
			 "Gaidai", "Picasso", "Hugo", "Dumas"
		};

		/// <summary>
		/// Рандомное число
		/// </summary>
		private static Random _rnd = new Random();

		/// <summary>
		/// Возвращает случайно сгенерированного взрослого человека без пары
		/// </summary>
		/// <returns>Имя в зависимости от пола</returns>
		public static string GetRandomName(Gender gender)
		{
			string name;
			switch (gender)
			{
				case Gender.Female:
				{
					name = _femaleNames[_rnd.Next(0, _femaleNames.Count)];
					return name;
				}
				case Gender.Male:
				{
					name = _maleNames[_rnd.Next(0, _maleNames.Count)];
					return name;
				}
				default:
				{
					throw new ArgumentException($"Unknown gender!");
				}
			}
		}

			/// <summary>
			/// Возвращает случайно сгенерированного взрослого человека без пары
			/// </summary>
			/// <returns>Случайно сгенерированный объект типа Adult</returns>
		public static Adult GetRandomSingleAdult()
		{
			Gender gender = (Gender)_rnd.Next(0, 2);
			string name = GetRandomName(gender);

			string passportData = "";

			for (int i = 0; i < 10; i++)
			{
				passportData = passportData + _rnd.Next(0, 10).ToString();
			}

			string placeOfWork = "Work №" + _rnd.Next(0, 10).ToString();

			return new Adult(name, _surnames[_rnd.Next(0, _surnames.Count)], 
			_rnd.Next(Adult.minimumAge, Adult.maximumAge + 1), gender, 
			passportData, FamilyStatus.Single, null, placeOfWork);
		}

		/// <summary>
		/// Возвращает случайно сгенерированного взрослого человека
		/// </summary>
		/// <returns>Случайно сгенерированный объект типа Adult</returns>
		public static List <PersonBase> GetRandomAdult()
		{
			Adult adult = GetRandomSingleAdult();

			List<PersonBase> listAdult = new List<PersonBase>();

			FamilyStatus familyStatus = (FamilyStatus)_rnd.Next(0, 2);

			switch (familyStatus)
			{
				case FamilyStatus.Married:
				{
					Adult partner = GetRandomSingleAdult();
					Adult.Married(adult, partner);
					listAdult.Add(adult);
					listAdult.Add(partner);
					return listAdult;
				}
				case FamilyStatus.Single:
				{
					listAdult.Add(adult);
					return listAdult;
				}
				default:
				{
					throw new ArgumentException($"Unknown family status!");
				}
			}
		}

		/// <summary>
		/// Возвращает случайно сгенерированного ребёнка и родителей при их наличии
		/// </summary>
		/// <returns>Случайно сгенерированный объект типа List <Person></returns>
		public static List <PersonBase> GetRandomChild()
		{
			Gender gender = (Gender)_rnd.Next(0, 2);
			string name = GetRandomName(gender);

			string edutionInstitutionName = "Education institution №" + _rnd.Next(0, 10).ToString();
			 
			//TODO: 7 -> const 
			Adult parentOne = GetRandomBool(7)
				? GetRandomSingleAdult()
				: null;

			Adult parentTwo = GetRandomBool(7)
				? GetRandomSingleAdult()
				: null;

			List<PersonBase> childAndParents = new List<PersonBase>();

			childAndParents.Add(new Child(name, _surnames[_rnd.Next(0, _surnames.Count)],
				_rnd.Next(Child.minimumAge, Child.maximumAge + 1), 
				gender, parentOne, parentTwo, edutionInstitutionName));

			if (parentOne != null && parentTwo != null)
			{
				if (GetRandomBool(7))
				{
					Adult.Married(parentOne, parentTwo);
				}

				childAndParents.Add(parentOne);
				childAndParents.Add(parentTwo);
			}

			if (parentOne != null && parentTwo == null)
			{
				childAndParents.Add(parentOne);
			}

			if (parentOne == null && parentTwo != null)
			{
				childAndParents.Add(parentTwo);
			}
			return childAndParents;
		}

		/// <summary>
		/// Вывод случайно сгенерированного логического флага
		/// </summary>
		/// <param name="value">Необходимая вероятность в виде целого числа от 0 до 9,
		/// если 0 то 10% что true, если 9 то 100% что true</param>
		/// <returns>Флаг случайной величины</returns>
		public static bool GetRandomBool(int value)
		{
			bool flag = _rnd.Next(0, 10) <= value
				? true
				: false;
			return flag;
		}

	}
}
