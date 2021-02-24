using System;
using System.Collections.Generic;
using System.Text;

namespace LR2Library
{
    public class PersonList
    { 
        private Person[] _listOfPerson;

        /// <summary>
        /// Возврат списка персон
        /// </summary>
        /// <returns>Список персон в виде массива элементов Person</returns>
        public Person[] Persons
        {
            get 
            { 
               return _listOfPerson; 
            }
        }

        /// <summary>
        /// Количество элементов списка
        /// </summary>
        /// <returns>Количество элементов списка</returns>
        public int Count
        {
            get
            {
                int _count = _listOfPerson.Length;
                return _count;
            }
        }

        /// <summary>
        /// Инициализация списка персон
        /// </summary>
        public PersonList()
        {
            _listOfPerson = new Person[0];
        }

        /// <summary>
        /// Вывод списка персон
        /// </summary>
        /// <returns>Массив строк состоящий из персон</returns>
        public string[] Info
        {
            get
            {
                string[] _info = new string[Count];
                for (int i = 0; i < Count; i++)
                {
                    _info[i] = _listOfPerson[i].Info;
                }
                return _info;
            }
        }


        public Person this[int index]
        {
           get
           {
             return _listOfPerson[index];
           }

           set
           {
                if (Count <= index)
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
            Array.Resize(ref _listOfPerson, Count + 1);
            _listOfPerson[Count-1] = newperson;
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        public void Delete(int index)
        {
           for (int i=index; i<Count-2; i++)
           {
                _listOfPerson[i] = _listOfPerson[i + 1];
           }
            Array.Resize(ref _listOfPerson, Count - 1);
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        public void Delete(string surname, string name)
        {
             int _index = IndexOf(surname, name);
             if (_index > -1)
             {
               Delete(_index);
             }
        }

        /// <summary>
        /// Очистка списка
        /// </summary>
        public void AllDelete()
        {
            Array.Resize(ref _listOfPerson, 0);
        }

        /// <summary>
        /// Поиск индекса первого вхождения элемента
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <returns>Индекс элемента, если элемента нет то возвращает -1</returns>
        public int IndexOf(string surname)
        {
            int _index =-1;
           foreach (var p in _listOfPerson)
           {
               if (p.Surname == surname)
               {
                    _index = Array.IndexOf(_listOfPerson, p);
                    break;
               }
           }
           return _index;
        }

        /// <summary>
        /// Поиск индекса первого вхождения элемента
        /// </summary>
        /// <param name="Surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <returns>Индекс элемента, если элемента нет то возвращает -1</returns>
        public int IndexOf(string surname, string name)
        {
            int _index = -1;
            foreach (var p in _listOfPerson)
            {
                if (p.Surname == surname & p.Name == name)
                {
                    _index = Array.IndexOf(_listOfPerson, p);
                    break;
                }
            }
            return _index;
        }

    }
}
