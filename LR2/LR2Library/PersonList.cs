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
                int count = _listOfPerson.Length;
                return count;
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
                int count = Count;
                string[] info = new string[count];
                for (int i = 0; i < count; i++)
                {
                    info[i] = _listOfPerson[i].Info;
                }
                return info;
            }
        }


        public Person this[int index]
        {
           get
           {
              if (index < 0 || index >= Count)
              {
                 throw new ArgumentException($"index should be between 0 and {Count - 1} !");
              }
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
            int count = Count;
            Array.Resize(ref _listOfPerson, count + 1);
            _listOfPerson[count] = newperson;
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента</param>
        public void Delete(int index)
        {
           int elementCount = Count;
           for (int i=index; i< elementCount - 1; i++)
           {
                _listOfPerson[i] = _listOfPerson[i + 1];
           }
            Array.Resize(ref _listOfPerson, elementCount - 1);
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="surname">Фамилия</param>
        public void Delete(string surname)
        {
            List<int> indexes = IndexOf(surname);
            foreach (int index in indexes)
            {
                if (index > -1)
                {
                    Delete(index);
                }
            }
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        public void Delete(string surname, string name)
        {
             List<int> indexes = IndexOf(surname, name);
             foreach(int index in indexes)
             {
                if (index > -1)
                {
                    Delete(index);
                }
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
        /// Поиск индексов элементов
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <returns>Лист с индексами элементов, если элементов нет то возвращает -1</returns>
        public List<int> IndexOf(string surname)
        {
           List<int> indexList = new List<int>();
            int check = 0;
           foreach (var p in _listOfPerson)
           {
               if (p.Surname == surname)
               {
                    indexList.Add(Array.IndexOf(_listOfPerson, p));
                    check++;
               }
               
               if (check == 0)
               {
                    indexList.Add(-1);
               }
           }
           return indexList;
        }

        /// <summary>
        /// Поиск индексов элементов
        /// </summary>
        /// <param name="Surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <returns>Лист с индексами элементов, если элементов нет то возвращает -1</returns>
        public List<int> IndexOf(string surname, string name)
        {
            List<int> indexList = new List<int>();
            int check = 0;
            foreach (var p in _listOfPerson)
            {
                if (p.Surname == surname && p.Name == name)
                {
                    indexList.Add(Array.IndexOf(_listOfPerson, p));
                    check++;
                }

                if (check == 0)
                {
                    indexList.Add(-1);
                }
            }
            return indexList;
        }

    }
}
