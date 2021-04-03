using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2Library
{
    /// <summary>
    /// Ребёнок
    /// </summary>
    public class Child : Person
    {

/*
        /// <summary>
        /// Возраст
        /// </summary>
        public override int Age
        {
            get => _age;
            set
            {
                _age = CheckAge(value);
            }
        }
*/

        /// <summary>
        /// Первый родитель
        /// </summary>
        public Adult Parent_one 
        { get; set;}

        /// <summary>
        /// Второй родитель
        /// </summary>
        public Adult Parent_two { get; set; }

        /// <summary>
        /// Образовательное учреждение
        /// </summary>
        public string EducationalInstitutionName { get; set; }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Child(string name, string surname, int age, Gender gender): base(name, surname, age, gender)
        {
            /*
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;*/
        }




    }
}
