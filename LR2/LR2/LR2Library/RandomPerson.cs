using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2Library
{
    public static class RandomPerson
    {
        /// <summary>
        /// Список мужских имён
        /// </summary>
        private static List<string> _maleNames = new List<string>()
        {
            "Alexander", "Vladimir", "Oleg",
           "Ruslan", "Eugene", "Artyom", "Vladimir",
           "Michael", "Leonid", "Sergey"
        };

        /// <summary>
        /// Список женских имён
        /// </summary>
        private static List<string> _femaleNames = new List<string>()
        {
            "Valentina", "Eugene", "Alexandra",
           "Irina", "Daria", "Maria", "Marina",
           "Elizabeth", "Lily", "Anna"
        };

        /// <summary>
        /// Список фамилий
        /// </summary>
        private static List<string> _surnames = new List<string>() 
        {
            "Blok", "Bach", "Tsiskaridze",
             "Senda", "Hemingway", "Kuchko",
             "Gaidai", "Picasso", "Hugo", "Dumas"
        };

        /// <summary>
        /// Рандомное число
        /// </summary>
        private static Random _rnd = new Random();

        /// <summary>
        /// Возвращает случайно сгенерированную персону
        /// </summary>
        /// <returns>Случайно сгенерированный объект типа Person</returns>
        public static Person GetRandomPerson()
        {
            string name;
            Gender gender = (Gender)_rnd.Next(0, 2);
            switch (gender)
            {
                case Gender.Female:
               {
                   name = _femaleNames[_rnd.Next(0, _femaleNames.Count)];
                   break;
               }
               case Gender.Male:
               {
                   name = _maleNames[_rnd.Next(0, _maleNames.Count)];
                   break;
               }
               default:
               {
                   return new Person("default","default",1,Gender.Male);
               }
            }

            return new Person(name, _surnames[_rnd.Next(0, _surnames.Count)], 
                _rnd.Next(Person.minimumAge, Person.maximumAge), gender);
        } 

        /// <summary>
        /// Возвращает случайно сгенерированный PersonList
        /// </summary>
        /// <param name="count">Количесвто записей в PersonList</param>
        /// <returns>Случайно сгенерированный объект типа PersonList</returns>
        static public PersonList GetRandomPersonList(int count)
        {
            PersonList personlist = new PersonList();
            for(int i = 0; i<count;i++)
            {
                personlist[i] = GetRandomPerson();
            }

            return personlist;
        }
    }
}
