using System;
using System.Collections.Generic;
using System.Text;

namespace LR2Library
{
    public class PersonList
    {
        Person[] _listOfPerson;
       
        public PersonList()
        {
            _listOfPerson = new Person[0];
        }

        public Person this[int index]
        {
           get
           {
             return _listOfPerson[index];
           }

           set
           {
                if (_listOfPerson.Length <= index)
                {
                    Array.Resize(ref _listOfPerson, index + 1);
                }
                _listOfPerson[index] = value;
           }
        }

        /// <summary>
        /// Добавление элемента в список
        /// </summary>
        /// <param name="newperson">Добавляемый элемент</param>
        public void Add(Person newperson)
        {
            Array.Resize(ref _listOfPerson, _listOfPerson.Length + 1);
            _listOfPerson[_listOfPerson.Length-1] = newperson;
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="Index">Индекс элемента</param>
        public void Delete(int Index)
        {
            Array.Clear(_listOfPerson,Index,1);
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="Surname">Фамилия</param>
        public void Delete(string Surname)
        {
            foreach (var p in _listOfPerson)
            {
                if (p.Surname == Surname)
                {
                    int a = Array.IndexOf(_listOfPerson, p);
                    Array.Clear(_listOfPerson, a, 1);
                    //break;
                }
            }
        }

        /// <summary>
        /// Поиск индекса элемента по фамилии
        /// </summary>
        /// <param name="Surname">Фамилия</param>
        /// <returns>Индекс элемента, если элемента нет индекс=-1</returns>
        public int SearchIndex(string Surname)
        {
            int a=-1;
           foreach (var p in _listOfPerson)
           {
               if (p.Surname == Surname)
               {
                    a = Array.IndexOf(_listOfPerson, p);
                    break;
               }
           }
           return a;
        }

        /// <summary>
        /// Очистка списка
        /// </summary>
        public void AllDelete()
        {
            Array.Clear(_listOfPerson, 0, _listOfPerson.Length);
        }

        //TODO: сделать свойством
        /// <summary>
        /// Получить количество элементов списка
        /// </summary>
        /// <returns>Индекс элемента, если элемента нет индекс=-1</returns>
        public int Count()
        {
            int a = _listOfPerson.Length;
            return a;
        }

    }
}
