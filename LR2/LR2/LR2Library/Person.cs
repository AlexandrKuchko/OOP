using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace LR2Library
{
    public class Person
    {
        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public const int maximumAge = 150;

        /// <summary>
        /// Минимальный возраст
        /// </summary>
        public const int minimumAge = 1;

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
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public Person (string name, string surname, int age, Gender gender)
        {
                  
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Иноформация о персоне
        /// </summary>
        public string Info 
        {
            get
            {
                return $"Name: {this.Name}, " +
                    $"Surname: {this.Surname}, " +
                    $"Age: {this.Age}, " +
                    $"Gender: {this.Gender}";
            }
        }
         
        /// <summary>
        /// Проверка возраста
        /// </summary>
        /// <param name="value">Возраст</param>
        private static int CheckAge(int value)
        {
            if (value > maximumAge || value < minimumAge)
            {
                throw new ArgumentException($"{nameof(Age)} should be between {maximumAge} and {minimumAge} !");
            }

            string pattern = @"^[0-9]+$";

            if (!Regex.IsMatch(value.ToString(), pattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException($"{nameof(Age)} should not contain symbols!");
            }
            return value;
        }

        /// <summary>
        /// Проверка имени или фамилии и перевод в нужный формат
        /// </summary>
        /// <param name="value">Имя или фамилия</param>
        private static string CheckName(string value)
        {
            const string pattern1 = @"^[a-zа-яё]+$";

            const string pattern2 = @"^[a-zа-я]+-[a-zа-я]+$";

            if (value == "" || value == null)
            {
                throw new ArgumentException($"Value should not be empty!");
            }

            if (!Regex.IsMatch(value, pattern1, RegexOptions.IgnoreCase)
                && !Regex.IsMatch(value, pattern2, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException($"Value should contain only Latin or Cyrillic and one hyphen!");
            }
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }
    }
}
