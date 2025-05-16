using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _315_F
{
    internal class Board
    {
        private int _size;
        private int[] _numbers;
        private int[] _victoryOrder;
        private int _inversions;

        private static int countInversions(int[] numbers)
        {
            int[] numbersWithoutZero = numbers.Where(x => x != 0).ToArray();
            int inversionsCounter = 0;
            foreach (int number in numbersWithoutZero)
            {
                int index = Array.IndexOf(numbersWithoutZero, number);
                int[] numbersAfterIndex = numbersWithoutZero.Skip(index).ToArray();
                foreach (int nuberAfterIndex in numbersAfterIndex)
                {
                    if (nuberAfterIndex < number)
                    {
                        inversionsCounter++;
                    }
                }
            }

            return inversionsCounter;
        }
        public Board(int size = 3)
        {
            Random random = new Random();
            _size = size;
            _numbers = Enumerable.Range(0, _size * _size).OrderBy(_ => random.Next()).ToArray();
            _victoryOrder = Enumerable.Range(1, _size * _size - 1).Concat(new[] { 0 }).ToArray();
            _inversions = countInversions(_numbers);
        }
        public int Size
        {
            get { return _size; }
        }

        public int Difficulty
        {
            get { return _inversions;  }
        }
        public int[] Numbers
        {
            get { return _numbers; }
        }
        public int GetNullIndex()
        {
            return Array.IndexOf(_numbers, 0);
        }
        public void SetNullIndex(int newIndex)
        {
            int oldIndex = GetNullIndex();
            if (newIndex >= 0 && newIndex <= _size * _size - 1)
            {
                int temp = _numbers[oldIndex];
                _numbers[oldIndex] = _numbers[newIndex];
                _numbers[newIndex] = temp;
            }
            else
            {
                Console.WriteLine("Error: Board: _numbers out of the range");
            }
        }
        public bool IsVictory()
        {
            return _numbers.SequenceEqual(_victoryOrder);
        }
        public bool IsSolvable()
        {
            if (_size % 2 == 0)
            {
                int zeroIndex = Array.IndexOf(_numbers, 0);
                int zeroRow = zeroIndex / _size;

                return (_inversions + zeroRow) % 2 != 0;
            }
            else
            {
                return _inversions % 2 == 0;
            }
        }
    }
}