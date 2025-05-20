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
        private Point _emtpyFieldPosition;
        private int _boardSize;
        private Board _board;

        private int ParseCoordinatesToArrayIndex(Point coordinates)
        {
            return coordinates.Y * _boardSize + coordinates.X;
        }

        private Point ParseArrayIndexToCoordinates(int index)
        {
            Point coordinates = new Point();
            coordinates.Y = index / _boardSize;
            coordinates.X = index % _boardSize;
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

        private void MoveEmptyField(string direction)
        {
            switch (direction)
            {
                case "Up":
                    if (_emtpyFieldPosition.Y > 0)
                    {
                        _emtpyFieldPosition.Y -= 1;
                    }
                    break;
                case "Down":
                    if (_emtpyFieldPosition.Y < _boardSize - 1)
                    {
                        _emtpyFieldPosition.Y += 1;
                    }
                    break;
                case "Left":
                    if (_emtpyFieldPosition.X > 0)
                    {
                        _emtpyFieldPosition.X -= 1;
                    }
                    break;
                case "Right":
                    if (_emtpyFieldPosition.X < _boardSize - 1)
                    {
                        _emtpyFieldPosition.X += 1;
                    }
                    break;
            }
        }

        public Game(int boardSize = 3)
        {
            _boardSize = boardSize;
            _board = ResetBoard(_boardSize);
            _emtpyFieldPosition = ParseArrayIndexToCoordinates(_board.GetNullIndex());
        }
        public void Run()
        {
            RulesMessage();
            _board.Draw();


            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveEmptyField("Up");
                        _board.SetNullIndex(ParseCoordinatesToArrayIndex(_emtpyFieldPosition));
                        break;
                    case ConsoleKey.DownArrow:
                        MoveEmptyField("Down");
                        _board.SetNullIndex(ParseCoordinatesToArrayIndex(_emtpyFieldPosition));
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveEmptyField("Left");
                        _board.SetNullIndex(ParseCoordinatesToArrayIndex(_emtpyFieldPosition));
                        break;
                    case ConsoleKey.RightArrow:
                        MoveEmptyField("Right");
                        _board.SetNullIndex(ParseCoordinatesToArrayIndex(_emtpyFieldPosition));
                        break;
                    case ConsoleKey.S:
                        _board = ResetBoard(_boardSize);
                        _emtpyFieldPosition = ParseArrayIndexToCoordinates(_board.GetNullIndex());
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                UpdateView(_board);
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