using System;

namespace labs01
{
    class Program
    {
        static void Main()
        {
            string name; // переменная для имени пользователя
            string input_number; // переменная для проверки ввода

            int year, moths, day; // переменные даты рождения пользователя
            int number; // переменная вычисленного возраста

            DateTime current_date = DateTime.Now; // текущая дата

            Console.WriteLine("Приветствую в консольной программе Labs01!\n");

            Console.Write("Введите свое имя: ");
            name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name)) // проверка на пустую строку
            { 
                name = "Unknown"; 
            }

            while (true) // цикл ввода года пользователя
            {
                Console.Write("Введите свой год рождения: ");
                input_number = Console.ReadLine();

                if (!Int32.TryParse(input_number, out year)) // проверка на символы
                {
                    Console.WriteLine("[ОШИБКА]: Введите корректную дату!\n");
                    continue;
                }

                if (year < 0 || year > current_date.Year) // проверка на диапозон
                {
                    Console.WriteLine("[ОШИБКА]: Введите корректную дату!");
                    Console.WriteLine($"Примеч.: Дата не должна быть меньше 0 или больше {current_date.Year}\n");
                    continue;
                }
                break;
            }

            while (true) // цикл ввода месяца пользователя
            {
                Console.Write("Введите свой месяц рождения: ");
                input_number = Console.ReadLine();

                if (!Int32.TryParse(input_number, out moths)) // проверка на символы
                {
                    Console.WriteLine("[ОШИБКА]: Введите корректный месяц!\n");
                    continue;
                }

                if (moths <= 0 || moths > 12) // проверка на диапозон
                {
                    Console.WriteLine("[ОШИБКА]: Введите корректный месяц!");
                    Console.WriteLine("Примеч.: Месяц не должен быть меньше 1 или больше 12\n");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Введите свой день рождения: ");
                input_number = Console.ReadLine();

                if (!Int32.TryParse(input_number, out day)) // проверка на символы
                {
                    Console.WriteLine("[ОШИБКА]: Введите корректный день!\n");
                    continue;
                }

                if (day < 0 || day > 31) // проверка на диапозон
                {
                    Console.WriteLine("[ОШИБКА]: Введите корректный день!");
                    Console.WriteLine("Примеч.: День не должен быть меньше 1 или больше 31\n");
                    continue;
                }

                if (moths == 2) // проверка дней в феврале
                {
                    if (day > 29)
                    {
                        Console.WriteLine("[ОШИБКА]: Введите корректный день!");
                        Console.WriteLine("Примеч.: В феврале не может быть больше 29 дней!\n");
                        continue;
                    }

                    if (day >= 29 && !(year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))) // проверка на високосный год
                    {
                        Console.WriteLine("[ОШИБКА]: Введите корректный день!");
                        Console.WriteLine("Примеч.: В феврале не високосного года может быть только 28 дней!\n");
                        continue;
                    }   
                }
                break;
            }
 
            number = current_date.Year - year; // вычисление возраста пользователя
            if (current_date.Month < moths || (current_date.Month == moths && current_date.Day > day)) // проверка на достижения возраста
            {
                number -= 1;
            }

            Console.WriteLine($"\nПривет, {name}. Ваш возраст равен {number} лет. Приятно познакомиться. :)");
            Console.ReadKey();
        }
    }
}
