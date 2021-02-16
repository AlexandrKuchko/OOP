using System;
using System.Collections.Generic;
using System.Text;

namespace LR2.OOP
{
    class Person
    {

        public enum Gender
        {
            Men,
            Woman
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Gender sex { get; set; }

        public Person (string a1, string a2, int a3, Gender sex)
        {
            Name = a1;
            Surname = a2;
            Age = a3;
            this.sex = sex;
        }

        public Person()
        {

        }

        public void Print()
        {
            Console.WriteLine("Имя: {0}  Фамилия: {1}  Возраст: {2}  Пол: {3}", 
                Name, Surname, Age, sex);
        }

    }
}
