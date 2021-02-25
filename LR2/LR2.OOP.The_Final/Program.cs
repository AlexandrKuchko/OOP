using System;
using LR2Library;

namespace LR2.OOP.The_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание двух списков

            PersonList list1 = RandomPerson.GetRandomPersonList(3);

            PersonList list2 = RandomPerson.GetRandomPersonList(3);

            //Вывод списков на экран
            Print("Список 1", list1);

            Print("Список 2", list2);

            PressAnyKey();
                       
            // Добавление нового человека в первый список

            list1.Add(RandomPerson.GetRandomPerson());

            // Копирование второго человека из первого 
            // списка в конец второго списка
            list2.Add(list1[1]);

            //Вывод списков на экран
            Print("Список 1", list1);

            Print("Список 2", list2);

            PressAnyKey();

            list1.Delete(1);

            //Вывод списков на экран
            Print("Список 1", list1);

            Print("Список 2", list2);

            PressAnyKey();

            //Удаление второго списка
            list2.AllDelete();

            //Вывод списков на экран
            Print("Список 1", list1);

            Print("Список 2", list2);

            PressAnyKey();
        }

        /// <summary>
        /// Вывод списка PersonList в консоль
        /// </summary>
        /// <param name="name">Название списка</param>
        /// <param name="personlist">Выводимый элемент PersonList</param>
        static private void Print(string name, PersonList personlist)
        {
            Console.WriteLine(name);
            for (int i = 0; i < personlist.Count; i++)
            {
                Console.WriteLine(personlist.Info[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Нажмите клавишу чтобы продолжить
        /// </summary>
        static private void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.ResetColor();
        }

    }
    
}
