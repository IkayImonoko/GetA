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
        private Point EmtpyFiendPosition;
        private int BoardSize;
        private Board Board;
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
            RulesMessage();
            if (!board.IsVictory())
            {
                board.Draw();
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
        public void Run()
        {
            //int boardSize = 3;
            ////int difficulty = 1;
            //Board Board;
            Board = ResetBoard(boardSize);
            RulesMessage();
            Board.Draw();

            var emptyFieldCoordinates = ParseArrayIndexToCoordinates(Board.GetNullIndex(), Board.Size);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveEmptyField(ref emptyFieldCoordinates, Board.Size, "Up");
                        Board.SetNullIndex(ParseCoordinatesToArrayIndex(emptyFieldCoordinates, Board.Size));
                        break;
                    case ConsoleKey.DownArrow:
                        MoveEmptyField(ref emptyFieldCoordinates, Board.Size, "Down");
                        Board.SetNullIndex(ParseCoordinatesToArrayIndex(emptyFieldCoordinates, Board.Size));
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveEmptyField(ref emptyFieldCoordinates, Board.Size, "Left");
                        Board.SetNullIndex(ParseCoordinatesToArrayIndex(emptyFieldCoordinates, Board.Size));
                        break;
                    case ConsoleKey.RightArrow:
                        MoveEmptyField(ref emptyFieldCoordinates, Board.Size, "Right");
                        Board.SetNullIndex(ParseCoordinatesToArrayIndex(emptyFieldCoordinates, Board.Size));
                        break;
                    case ConsoleKey.S:
                        Board = ResetBoard(boardSize);
                        emptyFieldCoordinates = ParseArrayIndexToCoordinates(Board.GetNullIndex(), Board.Size);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }

                UpdateView(Board);
            }
        }

        private static Board ResetBoard(int boardSize, int difficulty)
        {
            Board board = new Board(boardSize);
            while (!board.IsSolvable() || board.Difficulty > difficulty)
            {
                board = new Board(boardSize);
            }
            return board;
        }
        private static Board ResetBoard(int boardSize)
        {
            Board board = new Board(boardSize);
            while (!board.IsSolvable())
            {
                board = new Board(boardSize);
            }
            return board;
        }

        private static void RulesMessage()
        {
            Console.WriteLine("Move \"0\" with arrows\nPush \"s\" to refresh the Board\nPush \"Esc\" to exit\n\n");
        }
    }
}