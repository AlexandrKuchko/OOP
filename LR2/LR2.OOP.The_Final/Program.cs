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
            List1[0] = GetRandomPerson.GetRndPerson();
            List1[1] = GetRandomPerson.GetRndPerson();
            List1[2] = GetRandomPerson.GetRndPerson();

            PersonList List2 = new PersonList();
            List2[0] = new Person("Александр", "Кучко", 23, Gender.Male);
            List2[1] = new Person("Дмитрий", "Косовский", 22, Gender.Male);
            List2[2] = new Person("Иван", "Жданов", 50, Gender.Male);
            
            //Вывод списков на экран
            Console.WriteLine("Список 1");
            for (int i = 0; i < List1.Count; i++)
            {
                Console.WriteLine(List1.Info[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Список 2");
            for (int i = 0; i < List2.Count; i++)
            {
                Console.WriteLine(List2.Info[i]);
            }
            Console.WriteLine();

            // Добавление нового человека в первый список
            Person personAdd = new Person("Евгения", "Белей", 25, Gender.Female);
            List1.Add(personAdd);

            // Внесение человека в 2 список
            List2.Add(List1[1]);

            //Вывод списков на экран
            Console.WriteLine("Список 1");
            for (int i = 0; i < List1.Count; i++)
            {
                Console.WriteLine(List1.Info[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Список 2");
            for (int i = 0; i < List2.Count; i++)
            {
                Console.WriteLine(List2.Info[i]);
            }
            Console.WriteLine();

            List1.Delete(1);

            //Вывод списков на экран
            Console.WriteLine("Список 1");
            for (int i = 0; i < List1.Count; i++)
            {
                Console.WriteLine(List1.Info[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Список 2");
            for (int i = 0; i < List2.Count; i++)
            {
                Console.WriteLine(List2.Info[i]);
            }
            Console.ReadLine();
        }
    }
    
}
