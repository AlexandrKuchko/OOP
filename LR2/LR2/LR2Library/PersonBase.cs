using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace LR2Library
{
    /// <summary>
    /// Человек
    /// </summary>
    public abstract class PersonBase
    {

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = CheckName(value);
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = CheckName(value);
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                _age = CheckAge(value);
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

      
        /// <summary>
        /// Иноформация о персоне
        /// </summary>
        public abstract string Info();

        /// <summary>
        /// Проверка возраста
        /// </summary>
        /// <param name="value">Возраст</param>
        protected abstract int CheckAge(int value);
       
        /// <summary>
        /// Проверка имени или фамилии и перевод в нужный формат
        /// </summary>
        /// <param name="value">Имя или фамилия</param>
        /// /// <returns>Строка (имя или фамилия) приведенная к нужномк виду</returns>
        private string CheckName(string value)
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
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }
    }
}
