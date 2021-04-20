using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LR2Library
{
    /// <summary>
    /// Ребёнок
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public const int maximumAge = 17;

        /// <summary>
        /// Минимальный возраст
        /// </summary>
        public const int minimumAge = 0;

        /// <summary>
        /// Первый родитель
        /// </summary>
        public Adult ParentOne { get; set; }

        /// <summary>
        /// Второй родитель
        /// </summary>
        public Adult ParentTwo { get; set; }

        /// <summary>
        /// Образовательное учреждение
        /// </summary>
        private string _educationalInstitutionName;

        /// <summary>
        /// Образовательное учреждение
        /// </summary>
        public string EducationalInstitutionName
        {
            get => _educationalInstitutionName;
            set
            {
                _educationalInstitutionName = ValidateEducationalInstitutionName(value);
            }
        }

        //TODO: XML
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="parentOne">Первый родитель</param>
        /// <param name="parentTwo">Второй родитель</param>
        /// <param name="educationalInstitutionName">Название образовательного учреждения</param>
        public Child(string name, string surname, int age, Gender gender, Adult parentOne, 
            Adult parentTwo, string educationalInstitutionName)
        {
            Gender = gender;
            Age = age;
            Surname = surname;
            Name = name;
            ParentOne = parentOne;
            ParentTwo = parentTwo;
            EducationalInstitutionName = educationalInstitutionName;
        }

        /// <summary>
        /// Иноформация о ребёнке
        /// </summary>
        /// <returns>Информация о ребёнке в формате строки</returns> 
        public override string Info()
        {
            string parrentOneName = this.ParentOne == null
                ? "No first parent"
                : $"First parrent: {ParentOne.Name} {ParentOne.Surname}";

            string parrentTwoName = this.ParentTwo == null
                ? "No second parent"
                : $"Second parrent: {this.ParentTwo.Name} {this.ParentTwo.Surname}";

            string educationalInstitutionName = this.EducationalInstitutionName == null
                ? "No educational institution"
                : $"Educational institution: {this.EducationalInstitutionName}";

            return $"Name: {this.Name}\n" +
                   $"Surname: {this.Surname}\n" +
                   $"Age: {this.Age}\n" +
                   $"Gender: {this.Gender}\n" +
                   $"{parrentOneName}\n" +
                   $"{parrentTwoName}\n" +
                   $"{educationalInstitutionName}";
        }

        /// <summary>
        /// Сменить учебное заведение
        /// </summary>
        /// <param name="name">Название нового учебного заведения</param>
        public void GoToStudy(string name)
        {
            EducationalInstitutionName = name;
        }

        /// <summary>
        /// Проверка паспортных данных
        /// </summary>
        /// <param name="value">Название учебного заведения</param>
        /// <returns>Название учебного заведения</returns>
        private string ValidateEducationalInstitutionName(string value)
        {
            if (value == null)
            {
                return value;
            }

            if (value == "")
            {
                throw new ArgumentException($"Value should not be empty!");
            }

            const string pattern = @"^[-.№0-9a-zA-Z\s]+$";

            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException($"The name must be in English!");
            }
            return value;
        }

        /// <summary>
        /// Проверка возраста
        /// </summary>
        /// <param name="value">Возраст</param>
        /// <returns>Возраст</returns>
        protected override int CheckAge(int value)
        {
            if (value > maximumAge || value < minimumAge)
            {
                throw new ArgumentException($"{nameof(Age)} should be between {minimumAge} and {maximumAge} !");
            }
            return value;
        }


    }
}
