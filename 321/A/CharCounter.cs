using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace A
{
    internal class CharCounter
    {
        private int[] _counts;
        private string _text;

        public CharCounter(string text  = "")
        {
            var range = 250;
            _counts = new int[range];
            _text = text;
        }

        public void SetText(string text)
        {
            _text = text;
        }

        public void Count()
        {
            if(_text.Length > 0)
            {
                foreach (var character in _text)
                {
                    _counts[(int)character]++;
                }
            }
        }

        public void Show()
        {
            var range = 250;
            for (var i = 0; i < range; i++)
            {
                if (_counts[i] > 0)
                {
                    var character = (char)i;
                    Console.WriteLine(character + " - " + _counts[i]);
                }
            }
        }
    }
}
