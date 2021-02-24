using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2Library
{
    public class GetRandomPerson
    {
        static private string[] _name = { "Александр", "Владимир", "Олег", 
            "Руслан","Дарья","Мария","Марина", "Елизавета", "Леонид", "Сергей"};
       
        static private string[] _surname = { "Климонов", "Андреев", "Цискаридзе",
            "Сенда","Петров","Кучко","Агеев", "Бродский", "Сахаров", "Гагарин"};
        
        static private Random rnd = new Random();

        /// <summary>
        /// Возвращает случайно сгенерированную персону
        /// </summary>
        /// <returns>Случайно сгенерированный объект типа Person</returns>
        static public Person GetRndPerson()
        {
            Person person = new Person(_name[rnd.Next(0, 10)],
                _surname[rnd.Next(0, 10)], rnd.Next(0, 100), (Gender)rnd.Next(0, 2));
            return person;
        }
        
    }
}
