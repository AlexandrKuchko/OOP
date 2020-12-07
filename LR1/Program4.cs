using System;

namespace Лаба1
{
    class Program4
    {
        static void Main()
        {
            int a;
            string b;
            while (true) //бесконечный цикл, для удобной проверки
            {
                Console.WriteLine("Введите номер месяца");
                int.TryParse(Console.ReadLine(), out a); //изменяем текстовый тип на float, записываем значение в переменную a
                switch (a) 
                   {
                    case 1:
                    case 2:
                    case 12:
                        b = "Зима";
                        break;
                    case 3:
                    case 4:
                    case 5:
                        b = "Весна";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        b = "Лето";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        b = "Осень";
                        break;
                    default:
                        b = "ошибка ввода данных";
                        break;
                }
                Console.WriteLine("Сейчас " + b);
            }

        }
    }
}
