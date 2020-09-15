using System;

namespace labs01
{
    class Program
    {
        static void Main()
        {
            string name;
            int date, moths, day;
            int number;
            Console.WriteLine("Привествую в консольной программе Labs01!");
            while (true)
            {
                Console.Write("Введите свое имя: ");
                name = Console.ReadLine();
                break;
            } 

            while (true)
            {
                Console.Write("Введите свой год рождения: ");
                date = Convert.ToInt32(Console.ReadLine());
                break;
            }

            while (true)
            {
                Console.Write("Введите свой месяц рождения: ");
                moths = Convert.ToInt32(Console.ReadLine());
                break;
            }

            while (true)
            {
                Console.Write("Введите свой день рождения: ");
                day = Convert.ToInt32(Console.ReadLine());
                break;
            }

            number = date;
            Console.WriteLine($"Привет, {name}. Ваш возраст равен {number} лет. Приятно познакомиться.");
        }
    }
}
