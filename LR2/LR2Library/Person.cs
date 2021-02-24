using System;
using System.Collections.Generic;
using System.Text;

namespace LR2Library
{
    public class Person
    {
               
        public string Name { get; }

        public string Surname { get; }

        public int Age { get; }

        public Gender Gender { get; }

        public Person (string name, string surname, int age, Gender gender)
        {
                  
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        public Person()
        {

        }

        public string Info 
        {
            get
            {
                return $"Name: {Name}, " +
                    $"Surname:{Surname}, " +
                    $"Age: {Age}, " +
                    $"Gender: {Gender}";
            }
        }

    }
}
