﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace LR2Library
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public const int maximumAge = 100;

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
        /// <returns>Возраст</returns>
        private static int CheckAge(int value)
        {
            if (value > maximumAge || value < minimumAge)
            {
                throw new ArgumentException($"{nameof(Age)} should be between {maximumAge} and {minimumAge} !");
            }            
            return value;
        }

        /// <summary>
        /// Проверка имени или фамилии и перевод в нужный формат
        /// </summary>
        /// <param name="value">Имя или фамилия</param>
        /// /// <returns>Строка (имя или фамилия) приведенная к нужномк виду</returns>
        private static string CheckName(string value)
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
