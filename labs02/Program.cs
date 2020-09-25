using System;

namespace labs02
{
    class PieceMove
    {
        public bool CheckMove(int figure, string startCoordMoved, string endCoordMoved)
        {
            switch (figure)
            {
                case 1:
                    return CheckMovePawn(startCoordMoved, endCoordMoved);
                case 2:
                    return CheckMoveRook(startCoordMoved, endCoordMoved);
                case 3:
                    return CheckMoveElephant(startCoordMoved, endCoordMoved);
                case 4:
                    return CheckMoveHorse(startCoordMoved, endCoordMoved);
                case 5:
                    return CheckMoveQueen(startCoordMoved, endCoordMoved);
                case 6:
                    return CheckMoveKing(startCoordMoved, endCoordMoved);
                default:
                    return false;
            }
        }

        static bool CheckMovePawn(string start, string end)
        {
            int diff = end[1] - start[1];
            if ((start[0] == end[0]) && (diff == 1 || (start[1] == '2' && diff == 2))) 
                return true;

            return false;
        }

        static bool CheckMoveRook(string start, string end)
        {
            if (end[0] == start[0] || end[1] == start[1]) 
                return true;

            return false;
        }

        static bool CheckMoveElephant(string start, string end)
        {
            if (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1])) 
                return true;

            return false;
        }

        static bool CheckMoveHorse(string start, string end)
        {
            int dx = Math.Abs(start[0] - end[0]);
            int dy = Math.Abs(start[1] - end[1]);
            if (dx == 1 && dy == 2 || dx == 2 && dy == 1) 
                return true;

            return false;
        }

        static bool CheckMoveQueen(string start, string end)
        {
            if (end[0] == start[0] || end[1] == start[1] || (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]))) 
                return true;

            return false;
        }

        static bool CheckMoveKing(string start, string end)
        {
            if (Math.Abs(start[0] - end[0]) <= 1 && Math.Abs(start[1] - end[1]) <= 1) 
                return true;

            return false;
        }

    }
    class Program
    {
        public const char MinFirstCoord = 'A';
        public const char MaxFirstCoord = 'H';
        public const char MinSecondCoord = '1';
        public const char MaxSecondCoord = '8';

        static void Main()
        {
            string[] Figures = { "Пешка", "Ладья", "Слон", "Конь", "Ферзь", "Король" };
            Console.WriteLine("Приветствую в консольной программе Labs02!\n");

            // ввод фигуры
            Console.WriteLine("Выберите шахматную фигуру:\n" +
                              "1. {0} (навального...)\n" +
                              "2. {1}\n" +
                              "3. {2}\n" +
                              "4. {3}\n" +
                              "5. {4}\n" +
                              "6. {5}", Figures);
            string figure_str;
            int figure;
            do
            {
                Console.Write("Поле для ввода: ");
                figure_str = Console.ReadLine();
            }
            while (!Int32.TryParse(figure_str, out figure) || !Correct_Check(figure));
            Console.WriteLine($"\nХорошо, ваша фигура - {Figures[figure-1]}\n");

            // ввод координат
            string startCoordFigure;
            string endCoordFigure;
            do
            {
                Console.WriteLine($"Примеч.: Координаты состоят из 2-х символов. Первый - от {MinFirstCoord} до {MaxFirstCoord}, второй - от {MinSecondCoord} до {MaxSecondCoord}");
                Console.Write("Введите начальные координаты вашей фигуры: ");
                startCoordFigure = Console.ReadLine().ToUpper();

                Console.Write("Введите конечные координаты вашей фигуры: ");
                endCoordFigure = Console.ReadLine().ToUpper();
            }
            while (!Correct_Check(startCoordFigure, endCoordFigure));

            PieceMove response = new PieceMove();
            if (response.CheckMove(figure, startCoordFigure, endCoordFigure))
            {
                Console.WriteLine("Ваш ход правилен!");
            }
            else
            {
                Console.WriteLine("Ваш ход не правилен!");
            }
            Console.ReadKey();

            
        }
        static bool Correct_Check(string startCoord, string endCoord)
        {
            if (startCoord.Length != 2 || endCoord.Length != 2)
            {
                Console.WriteLine("\n[ОШИБКА]: Введена координата превышающая допустимый размер!");
                return false;
            }

            if (startCoord[0] < MinFirstCoord || startCoord[0] > MaxFirstCoord || startCoord[1] < MinSecondCoord|| startCoord[1] > MaxSecondCoord)
            {
                Console.WriteLine("\n[ОШИБКА]: Введена неверно начальная координата!");
                return false;
            }

            if (endCoord[0] < MinFirstCoord || endCoord[0] > MaxFirstCoord || endCoord[1] < MinSecondCoord || endCoord[1] > MaxSecondCoord)
            {
                Console.WriteLine("\n[ОШИБКА]: Введена неверно конечная координата!");
                return false;
            }

            return true;
        }
        static bool Correct_Check(int figure)
        {
            if (figure < 1 || figure > 6)
            {
                Console.WriteLine("\n[ОШИБКА]: Введите корректный номер фигуры!");
                Console.WriteLine("Примеч.: Могут быть введены только числа от 1 до 6\n");
                return false;
            }

            return true;
        }
    }
}
