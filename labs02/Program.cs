using System;
using System.Net;

namespace labs02
{
    class PieceMove
    {
        public int figure; 
        public string x0y0;    
        public string xy;

    }
    class Program
    {
        static void Main()
        {
            // создание класса
            string figure;
            while (true)
            {
                figure = Console.ReadLine();
                // проверка на число
                // проверка на корректность
                break;
            }

            string x0y0;
            string xy;
            while (true)
            {
                x0y0 = Console.ReadLine();
                xy = Console.ReadLine();
                // проверка на корректность
                // проверка на границы
                break;
            }
            Boolean response = true;// вызов функции проверки возможности хода
            if (response)
            {
                // ваш ход правилен
            }
            else
            {
                // ваш ход неправилен, учись играть
            }

            
        }
        static Boolean Correct_Check(string data)
        {
            return true;
        }
        static Boolean Correct_Check(int data)
        {
            return true;
        }

    }
}
