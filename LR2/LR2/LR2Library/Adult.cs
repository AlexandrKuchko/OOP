using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace LR2Library
{

    /// <summary>
    /// Взрослый человек
    /// </summary>
    public class Adult: Person
    {

        /// <summary>
        /// Паспортные данные
        /// </summary>
        private string _passportData;
        
        /// <summary>
        /// Паспортные данные
        /// </summary>
        public string PassportData
        {
            get => _passportData;
            set
            {
                _passportData = ValidatePassportData(value);
            }
        }

        /// <summary>
        /// Семейное положение
        /// </summary>
        public string FamilyStatus { get; set; }

        /// <summary>
        /// Супруг/супруга
        /// </summary>
        public Adult Partner { get; set; }

        /// <summary>
        /// Место работы
        /// </summary>
        public string PlaceOfWork { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Adult(string name, string surname, int age, Gender gender): base(name, surname, age, gender)
        {
            /*
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;*/
        }

        /// <summary>
        /// Проверка паспортных данных
        /// </summary>
        /// <param name="value">Серия и номер паспорта</param>
        /// /// <returns>Серия и номер паспорта в формате строки</returns>
        private static string ValidatePassportData(string value)
        {
            if (value == "" || value == null)
            {
                throw new ArgumentException($"Value should not be empty!");
            }

            const string pattern = @"^[0-9]{8}$";

            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException($"The value must be 8 digits!");
            }
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }


    }
}
