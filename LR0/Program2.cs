using System;

namespace Лаба1
{
    class Program2
    {
        static void Main2()
        {
            float a;
            while (true) //бесконечный цикл, для удобной проверки
            {
                Console.WriteLine("Введите a");
                float.TryParse(Console.ReadLine(), out a); //изменяем текстовый тип на float, записываем значение в переменную a
                a = a * a;
                a = a * a;
                a = a * a;
                a = a * 1;
                Console.WriteLine("число a в 8 степени= " + a);
            }

        }
    }
}
