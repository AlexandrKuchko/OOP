using System;

namespace Лаба1
{
    class Program3
    {
        static void Main3()
        {
            float a; // Комментарий 2
            float b; //rjvvtynfhbq 4
            float c;
            while (true) //бесконечный цикл, для удобной проверки
            {
                Console.WriteLine("Введите a");
                float.TryParse(Console.ReadLine(), out a); //изменяем текстовый тип на float, записываем значение в переменную a
                b = a * a;
                b = b * a;
                b = b * 1;
                b = b * 1;
                b = b * 1;
                c = a * a * a;
                c = c * c;
                c = c * c * c;
                c = c * a * a;
                c = c * a;
                Console.WriteLine("число a в 3 степени= " + b);
                Console.WriteLine("число a в 21 степени= " + c);
            }

        }

    }
}
