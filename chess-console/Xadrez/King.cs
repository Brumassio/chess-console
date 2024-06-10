using tabuleiro;

namespace Xadrez
{
    internal class King : Peca
    {
        public King(Tabuleiro tab, Color cor) : base(tab, cor)
        {
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];

            Posicao pos = new Posicao(0, 0);

            //em cima
            pos.DefinirValores(Posicao.Line, Posicao.Column);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //em ne
            pos.DefinirValores(Posicao.Line -1, Posicao.Column + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //direita
            pos.DefinirValores(Posicao.Line, Posicao.Column+1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            //em se
            pos.DefinirValores(Posicao.Line+1, Posicao.Column+1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            //em baixo
            pos.DefinirValores(Posicao.Line+1, Posicao.Column);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //so
            pos.DefinirValores(Posicao.Line+1, Posicao.Column-1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // esquerda
            pos.DefinirValores(Posicao.Line, Posicao.Column-1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            // no
            pos.DefinirValores(Posicao.Line -1, Posicao.Column-1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
