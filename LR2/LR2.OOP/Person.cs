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

        public string Name;
        public string Surname;
        public int Age;
        public Gender sex;
       
    

        public Person (string a1, string a2, int a3, Gender sex)
        {
            Name = a1;
            Surname = a2;
            Age = a3;
            this.sex = sex;
        }



    }









}
