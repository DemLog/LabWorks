using System;

namespace labs02
{
    class PieceMove // класс с методами проверки
    {
        public bool CheckMove(int figure, string startCoordMoved, string endCoordMoved) // распределительный метод с проверками
        {
            switch (figure)
            {
                case 1:
                    return CheckMovePawn(startCoordMoved, endCoordMoved); // метод проверки хода пешки
                case 2: 
                    return CheckMoveRook(startCoordMoved, endCoordMoved); // метод проверки хода ладьи
                case 3:
                    return CheckMoveElephant(startCoordMoved, endCoordMoved); // метод проверки хода слона
                case 4:
                    return CheckMoveHorse(startCoordMoved, endCoordMoved); // метод проверки хода коня
                case 5:
                    return CheckMoveQueen(startCoordMoved, endCoordMoved); // метод проверки хода ферзя
                case 6:
                    return CheckMoveKing(startCoordMoved, endCoordMoved); // метод проверки хода короля
            }

            return false;
        }

        static bool CheckMovePawn(string start, string end) // метод проверки хода пешки
        {
            int diff = end[1] - start[1]; // разница Y в координатах
            if ((start[0] == end[0]) && (diff == 1 || (start[1] == '2' && diff == 2)))
                return true;

            return false;
        }

        static bool CheckMoveRook(string start, string end) // метод проверки хода ладьи
        {
            if (end[0] == start[0] || end[1] == start[1]) 
                return true;

            return false;
        }

        static bool CheckMoveElephant(string start, string end) // метод проверки хода слона
        {
            if (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1])) 
                return true;

            return false;
        }

        static bool CheckMoveHorse(string start, string end) // метод проверки хода коня
        {
            int dx = Math.Abs(start[0] - end[0]); // модуль разницы X координат
            int dy = Math.Abs(start[1] - end[1]); // модуль разницы Y координат
            if (dx == 1 && dy == 2 || dx == 2 && dy == 1) 
                return true;

            return false;
        }

        static bool CheckMoveQueen(string start, string end) // метод проверки хода ферзя
        {
            if (end[0] == start[0] || end[1] == start[1] || (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]))) 
                return true;

            return false;
        }

        static bool CheckMoveKing(string start, string end) // метод проверки хода короля
        {
            if (Math.Abs(start[0] - end[0]) <= 1 && Math.Abs(start[1] - end[1]) <= 1) 
                return true;

            return false;
        }

    }
    class Program
    {
        // КОНСТАНТЫ ГРАНИЦ ПОЛЯ ~~~~~~~~~~~~~
        public const char MinFirstCoord = 'A';
        public const char MaxFirstCoord = 'H';
        public const char MinSecondCoord = '1';
        public const char MaxSecondCoord = '8';

        static void Main()
        {
            Console.WriteLine("Приветствую в консольной программе Labs02!\n");

            string[] Figures = { "Пешка", "Ладья", "Слон", "Конь", "Ферзь", "Король" }; // массив с именами фигур
            //==================================================== Ввод номера фигуры ====================================================
            Console.WriteLine("Выберите шахматную фигуру:\n" +
                              "1. {0} (навального...)\n" +
                              "2. {1}\n" +
                              "3. {2}\n" +
                              "4. {3}\n" +
                              "5. {4}\n" +
                              "6. {5}", Figures);
            string figure_str; // переменная для ввода фигуры в string
            int figure; // переменная для конвертации фигуры в integer 
            do
            {
                Console.Write("Поле для ввода: ");
                figure_str = Console.ReadLine();
            }
            while (!Int32.TryParse(figure_str, out figure) || !Correct_Check(figure)); // цикл ввода с проверкой на корректность
            Console.WriteLine($"\nХорошо, ваша фигура - {Figures[figure-1]}\n");

            //======================================================= Ввод координат ======================================================
            string startCoordFigure; // переменная с начальной координатой
            string endCoordFigure; // переменная с конечной координатой
            do
            {
                Console.WriteLine($"Примеч.: Координаты состоят из 2-х символов. Первый - от {MinFirstCoord} до {MaxFirstCoord}, второй - от {MinSecondCoord} до {MaxSecondCoord}");
                Console.Write("Введите начальные координаты вашей фигуры: ");
                startCoordFigure = Console.ReadLine().ToUpper(); // начальная координата

                Console.Write("Введите конечные координаты вашей фигуры: ");
                endCoordFigure = Console.ReadLine().ToUpper(); // конечная координата
            }
            while (!Correct_Check(startCoordFigure, endCoordFigure)); // цикл ввода с проверкой на корректность
            //=============================================================================================================================

            PieceMove response = new PieceMove(); // создание экземпляра класса с проверкой хода
            if (response.CheckMove(figure, startCoordFigure, endCoordFigure)) // основное условие проверки хода
            {
                Console.WriteLine("Ваш ход верен!");
            }
            else
            {
                Console.WriteLine("Ваш ход не верен! Master не доволен");
            }
            Console.ReadKey();

        }
        static bool Correct_Check(string startCoord, string endCoord) // метод проверки корректности координат
        {
            if (startCoord.Length != 2 || endCoord.Length != 2) // проверка размера
            {
                Console.WriteLine("\n[ОШИБКА]: Введена координата превышающая допустимый размер!");
                return false;
            }

            if (startCoord[0] < MinFirstCoord || startCoord[0] > MaxFirstCoord || startCoord[1] < MinSecondCoord|| startCoord[1] > MaxSecondCoord) // проверка начальной координаты
            {
                Console.WriteLine("\n[ОШИБКА]: Введена неверно начальная координата!");
                return false;
            }

            if (endCoord[0] < MinFirstCoord || endCoord[0] > MaxFirstCoord || endCoord[1] < MinSecondCoord || endCoord[1] > MaxSecondCoord) // проверка конечной координаты
            {
                Console.WriteLine("\n[ОШИБКА]: Введена неверно конечная координата!");
                return false;
            }

            return true;
        }
        static bool Correct_Check(int figure) // метод проверки корректности номера фигуры
        {
            if (figure < 1 || figure > 6) // проверка диапазона фигур
            {
                Console.WriteLine("\n[ОШИБКА]: Введите корректный номер фигуры!");
                Console.WriteLine("Примеч.: Могут быть введены только числа от 1 до 6\n");
                return false;
            }

            return true;
        }
    }
}
