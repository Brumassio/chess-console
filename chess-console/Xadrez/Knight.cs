using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez
{
    internal class Knight : Peca
    {
        public Knight(Tabuleiro tab, Color cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
