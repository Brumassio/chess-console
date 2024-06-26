﻿using tabuleiro;

namespace Xadrez
{
    internal class PosicaoXadrez
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public PosicaoXadrez(char column, int line)
        {
            Column=column;
            Line=line;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - Line, Column - 'a');
        }
        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
