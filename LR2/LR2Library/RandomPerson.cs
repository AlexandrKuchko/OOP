using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2Library
{
    public class RandomPerson
    {
        static private string[] _name = { "Александр", "Владимир", "Олег", 
            "Руслан","Дарья","Мария","Марина", "Елизавета", "Леонид", "Сергей"};
       
        static private string[] _surname = { "Климонов", "Андреев", "Цискаридзе",
            "Сенда","Петров","Кучко","Агеев", "Бродский", "Сахаров", "Гагарин"};
        
        static private Random _rnd = new Random();

        /// <summary>
        /// Возвращает случайно сгенерированную персону
        /// </summary>
        /// <returns>Случайно сгенерированный объект типа Person</returns>
        static public Person GetRandomPerson()
        {
            Person person = new Person(_name[_rnd.Next(0, 10)],
                _surname[_rnd.Next(0, 10)], _rnd.Next(0, 100), (Gender)_rnd.Next(0, 2));
            return person;
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
