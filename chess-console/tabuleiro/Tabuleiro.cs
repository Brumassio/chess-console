﻿
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

        public Peca GetPeca(int line, int column)
        {
            return Pecas[line, column];
        }

        public Peca GetPeca(Posicao pos)
        {
            return Pecas[pos.Line, pos.Column];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return GetPeca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("There is already a piece in that position !");
            }
            Pecas[pos.Line,pos.Column] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if(GetPeca(pos) == null)
            {
                return null;
            }
            Peca aux = GetPeca(pos);
            aux.Posicao = null;
            Pecas[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if(pos.Line<0 || pos.Line >= Lines || pos.Column<0 || pos.Column >= Columns)
            {
                Console.WriteLine(pos.Line);
                Console.WriteLine(pos.Column);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Position invalid !");
            }
        }
    }

}
