using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal struct WordInfo
    {
        public string Word { get; set; }
        public int Length => Word.Length;

        public WordInfo(string word)
        {
            Word = word;
        }

        public override string ToString()
        {
            return $"Word: {Word}, Length: {Length}";
        }
    }
}
