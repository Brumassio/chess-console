using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Peca[,] Pecas { get; set; }

        public Tabuleiro(int lines, int columns)
        {
            Lines=lines;
            Columns=columns;
            Pecas = new Peca[Lines, Columns];
        }
    }
}
