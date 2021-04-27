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
    public class Adult: PersonBase
    {
        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public const int maximumAge = 100;

        /// <summary>
        /// Минимальный возраст
        /// </summary>
        public const int minimumAge = 18;

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
        public FamilyStatus FamilyStatus { get; set; }

        /// <summary>
        /// Супруг/супруга
        /// </summary>
        public Adult Partner { get; set; }

        /// <summary>
        /// Место работы
        /// </summary>
        private string _placeOfWork;

        /// <summary>
        /// Место работы
        /// </summary>
        public string PlaceOfWork
        {
            get => _placeOfWork;
            set
            {
                _placeOfWork = ValidatePlaceOfWork(value);
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="passportData">Паспортные данные</param>
        /// <param name="familyStatus">Семейное положение</param>
        /// <param name="partner">Ссылка на партнёра</param>
        /// <param name="placeOfWork">Название работы</param>
        public Adult(string name, string surname, int age, Gender gender, string passportData, 
            FamilyStatus familyStatus, Adult partner, string placeOfWork)
        {
            Gender = gender;
            Age = age;
            Surname = surname;
            Name = name;
            PassportData = passportData;
            FamilyStatus = familyStatus;
            Partner = partner;
            PlaceOfWork = placeOfWork;
        }

        /// <summary>
        /// Иноформация о взрослом человеке
        /// </summary>
        /// <returns>Информация о взрослом человеке в формате строки</returns> 
        public override string Info()
        {
            string partnerName = this.FamilyStatus == FamilyStatus.Single
                ? "No partner"
                : $"Partner name: {Partner.Name} {Partner.Surname}";

            string placeOfWork = this.PlaceOfWork == null
                ? "No work place"
                : $"Work place: {this.PlaceOfWork}";

            return $"Name: {this.Name}\n" +
                   $"Surname: {this.Surname}\n" +
                   $"Age: {this.Age}\n" +
                   $"Gender: {this.Gender}\n" +
                   $"Passport data: {this.PassportData}\n" +
                   $"Family status: {this.FamilyStatus}\n" +
                   $"{partnerName}\n" +
                   $"{placeOfWork}";
        }

        /// <summary>
        /// Проверка паспортных данных
        /// </summary>
        /// <param name="value">Серия и номер паспорта</param>
        /// <returns>Серия и номер паспорта в формате строки</returns>
        private string ValidatePassportData(string value)
        {
            if (value == "" || value == null)
            {
                throw new ArgumentException($"Value should not be empty!");
            }

            const string pattern = @"^[0-9]{10}$";

            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException($"The value must be 10 digits!");
            }
            return value;
        }

        /// <summary>
        /// Проверка паспортных данных
        /// </summary>
        /// <param name="value">Название учебного заведения</param>
        /// <returns>Название учебного заведения</returns>
        private string ValidatePlaceOfWork(string value)
        {
            if (value == null)
            {
                return value;
            }

            if (value == "")
            {
                throw new ArgumentException($"Value should not be empty!");
            }

            const string pattern = @"^[-.№0-9a-zA-Z\s""]+$";

            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException($"The name must be in English!");
            }
            return value;
        }

        /// <summary>
        /// Совмещение двух людей в брачный союз
        /// </summary>
        /// <param name="partnerOne">Первый партнёр</param>
        /// <param name="partnerTwo">Второй партнёр</param>
        public static void Married(Adult partnerOne, Adult partnerTwo)
        {
            partnerOne.FamilyStatus = FamilyStatus.Married;
            partnerTwo.FamilyStatus = FamilyStatus.Married;
            partnerOne.Partner = partnerTwo;
            partnerTwo.Partner = partnerOne;
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

        /// <summary>
        /// Сменить работу
        /// </summary>
        /// <param name="name">Название новой работы</param>
        public void GoToWork(string name)
        {
            PlaceOfWork = name;
        }
    }
}
