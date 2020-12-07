using System;

namespace Лаба1
{
    class Program1
    {
         static void Main1()
        {
            float R1;
            float R2;
            float R;
            while (true) //бесконечный цикл, для удобной проверки
            {
                Console.WriteLine("Введите первое сопротивление R1");
                float.TryParse(Console.ReadLine(), out R1); //изменяем текстовый тип на float, записываем значение в переменную R
                Console.WriteLine("Введите второе сопротивление R2");
                float.TryParse(Console.ReadLine(), out R2);
                R = R1 + R2;
                Console.WriteLine("Сопротивление R= " + R);
            }

        }
    }
}
