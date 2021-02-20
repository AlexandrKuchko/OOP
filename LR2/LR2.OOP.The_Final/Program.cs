using System;
using LR2Library;

namespace LR2.OOP.The_Final
{
    class Program
    {
        static void Main(string[] args)
        {
           // Создание двух списков
            PersonList List1 = new PersonList();
            List1[0] = new Person("Елена", "Парфёнова", 23, Person.Gender.Woman);
            List1[1] = new Person("Елизавета", "Лобач", 22, Person.Gender.Woman);
            List1[2] = new Person("Дарья", "Сенда", 21, Person.Gender.Woman);

            PersonList List2 = new PersonList();
            List2[0] = new Person("Александр", "Кучко", 23, Person.Gender.Men);
            List2[1] = new Person("Дмитрий", "Косовский", 22, Person.Gender.Men);
            List2[2] = new Person("Иван", "Жданов", 50, Person.Gender.Men);

            //Вывод списков на экран
            Console.WriteLine("Список 1");
            for (int i = 0; i < List1.Count(); i++)
            {
                List1[i].Print();
            }
            Console.WriteLine();

            Console.WriteLine("Список 2");
            for (int i = 0; i < List2.Count(); i++)
                List2[i].Print();
            Console.WriteLine();

            // Добавление нового человека в первый список
            Person personAdd = new Person("Евгения", "Белей", 25, Person.Gender.Woman);
            List1.Add(personAdd);

            // Внесение человека в 2 список
            List2.Add(List1[1]);

            //Вывод списков на экран
            Console.WriteLine("Список 1");
            for (int i = 0; i < List1.Count(); i++)
                List1[i].Print();
            Console.WriteLine();

            Console.WriteLine("Список 2");
            for (int i = 0; i < List2.Count(); i++)
                List2[i].Print();
            Console.WriteLine();

            List1.Delete(1);

            //Вывод списков на экран
            Console.WriteLine("Список 1");
            for (int i = 0; i < List1.Count(); i++)
                List1[i].Print();
            Console.WriteLine();

            Console.WriteLine("Список 2");
            for (int i = 0; i < List2.Count(); i++)
                List2[i].Print();
            Console.WriteLine();

        }
    }
}
