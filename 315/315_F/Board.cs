using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _315_F
{
    internal class Board
    {
        private int _size;
        private int[] _numbers;
        public Board(int size = 3)
        {
            Random random = new Random();
            _size = size;
            _numbers = Enumerable.Range(0, (_size * _size) + 1).OrderBy(_ => random.Next()).ToArray();
        }

        public void Draw()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write($"{_numbers[_size * i + j]}   ");
                }
                Console.Write("\n\n");
            }
        }
    }
}