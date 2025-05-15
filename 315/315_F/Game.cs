using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace _315_F
{
    internal class Game
    {
        private static void Draw(Board board)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Console.Write($"{board.Numbers[board.Size * i + j]}   ");
                }
                Console.Write("\n\n");
            }
        }
        private static int ParseCoordinatesToArrayIndex(Point coordinates, int boardSize)
        {
            return coordinates.Y * boardSize + coordinates.X;
        }

        private static Point ParseArrayIndexToCoordinates(int index, int boardSize)
        {
            Point coordinates = new Point();
            coordinates.Y = index / boardSize;
            coordinates.X = index % boardSize;
            return coordinates;
        }
        private static void UpdateView(Board board)
        {
            Console.Clear();
            if (!board.IsVictory())
            {
                Draw(board);
            }
            else
            {
                Console.WriteLine("You Winn!!!");
            }
        }

        private static void MoveEmptyField(ref Point currentPosition, int bordSize, string direction)
        {
            switch (direction)
            {
                case "Up":
                    if (currentPosition.Y > 0)
                    {
                        currentPosition.Y -= 1;
                    }
                    break;
                case "Down":
                    if (currentPosition.Y < bordSize - 1)
                    {
                        currentPosition.Y += 1;
                    }
                    break;
                case "Left":
                    if (currentPosition.X > 0)
                    {
                        currentPosition.X -= 1;
                    }
                    break;
                case "Right":
                    if (currentPosition.X < bordSize - 1)
                    {
                        currentPosition.X += 1;
                    }
                    break;
            }
        }
        public static void Run()
        {
            Board board = new Board(2);
            Draw(board);

            var emptyFieldCoordinates = ParseArrayIndexToCoordinates(board.GetNullIndex(), board.Size);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveEmptyField(ref emptyFieldCoordinates, board.Size, "Up");
                        board.SetNullIndex(ParseCoordinatesToArrayIndex(emptyFieldCoordinates, board.Size));
                        break;
                    case ConsoleKey.DownArrow:
                        MoveEmptyField(ref emptyFieldCoordinates, board.Size, "Down");
                        board.SetNullIndex(ParseCoordinatesToArrayIndex(emptyFieldCoordinates, board.Size));
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveEmptyField(ref emptyFieldCoordinates, board.Size, "Left");
                        board.SetNullIndex(ParseCoordinatesToArrayIndex(emptyFieldCoordinates, board.Size));
                        break;
                    case ConsoleKey.RightArrow:
                        MoveEmptyField(ref emptyFieldCoordinates, board.Size, "Right");
                        board.SetNullIndex(ParseCoordinatesToArrayIndex(emptyFieldCoordinates, board.Size));
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }

                UpdateView(board);
            }
        }
    }
}