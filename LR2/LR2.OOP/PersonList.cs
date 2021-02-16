using System;
using System.Collections.Generic;
using System.Text;

namespace LR2.OOP
{
    class PersonList
    {
        Person[] ListOfPerson;
       
        public PersonList()
        {
            ListOfPerson = new Person[0];
        }

        public Person this[int index]
        {
           get
           {
             return ListOfPerson[index];
           }

           set
           {
                if (ListOfPerson.Length <= index)
                {
                    Array.Resize(ref ListOfPerson, index + 1);
                }
                ListOfPerson[index] = value;
           }
        }

        /*
        public Person this[string Surname]
        {
            get
            {
                Person person = null;
                foreach (var p in ListOfPerson)
                {
                    if (p.Surname == Surname)
                    {
                        person = p;
                        //break;
                    }
                }
                return person;
            }
        }  */

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="Index">Индекс элемента</param>
        /// <returns></returns>
        public void Delete(int Index)
        {
            Array.Clear(ListOfPerson,Index,1);
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="Surname">Фамилия</param>
        /// <returns></returns>
        public void Delete(string Surname)
        {
            foreach (var p in ListOfPerson)
            {
                if (p.Surname == Surname)
                {
                    int a = Array.IndexOf(ListOfPerson, p);
                    Array.Clear(ListOfPerson, a, 1);
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
           foreach (var p in ListOfPerson)
           {
               if (p.Surname == Surname)
               {
                    a = Array.IndexOf(ListOfPerson, p);
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
            Array.Clear(ListOfPerson, 0, ListOfPerson.Length);
        }

        /// <summary>
        /// Получить количество элементов списка
        /// </summary>
        /// <returns>Индекс элемента, если элемента нет индекс=-1</returns>
        public int CountOfPerson()
        {
            int a = ListOfPerson.Length;
            return a;
        }

    }
}
