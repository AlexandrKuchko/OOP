using System;
using System.Collections.Generic;
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
        public const int minimumAge = 0;

        private string _name;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name 
        {
           get => _name;
           private set
           {
              CheckName(value, nameof(Name));
              _name = value;
           }

        }

        private string _surname;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname 
        {
           get => _surname;
           private set
           {
              CheckName(value, nameof(Surname));
              _surname = value;
           }
        }

        private int _age;

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
           get => _age;
           private set
           {
              CheckAge(value);              
              _age = value;
           }
        }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; }

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
                    $"Surname:{this.Surname}, " +
                    $"Age: {this.Age}, " +
                    $"Gender: {this.Gender}";
            }
        }

        /// <summary>
        /// Проверка возраста
        /// </summary>
        /// <param name="value">Возраст</param>
        private void CheckAge(int value)
        {
            if (value >= maximumAge || value <= minimumAge)
            {
                throw new ArgumentException($"{nameof(Age)} should be between {maximumAge} and {minimumAge} !");
            }

            string pattern = @"^[0-9]+$";

            if (Regex.IsMatch(value.ToString(), pattern, RegexOptions.IgnoreCase)==false)
            {
                throw new ArgumentException($"{nameof(Age)} should not contain symbols!");
            }
        }

        /// <summary>
        /// Проверка имени или фамилии
        /// </summary>
        /// <param name="value">Имя или фамилия</param>
        /// <param name="name">Название параметра</param>
        private void CheckName(string value, string name)
        {
            string pattern1 = @"^[a-zа-я]+$";

            string pattern2 = @"^[a-zа-я]+-[a-zа-я]+$";

            if (Regex.IsMatch(value, pattern1, RegexOptions.IgnoreCase) == false
                && Regex.IsMatch(value, pattern2, RegexOptions.IgnoreCase) == false)
            {
                throw new ArgumentException($"{name} should contain only Latin or Cyrillic!");
            }
        }
    }
}
