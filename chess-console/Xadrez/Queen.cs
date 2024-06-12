using System.Runtime.ConstrainedExecution;
using tabuleiro;

namespace Xadrez
{
    internal class Queen :Peca
    {
        public Queen(Tabuleiro tab, Cores cor) : base(tab, cor)
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

            //acima
            pos.DefinirValores(Posicao.Line -1, Posicao.Column);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line -1, pos.Column);
            }

            //abaixo
            pos.DefinirValores(Posicao.Line +1, Posicao.Column);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line +1, pos.Column);
            }

            //direita
            pos.DefinirValores(Posicao.Line, Posicao.Column +1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line, pos.Column+1);
            }

            //esquerda
            pos.DefinirValores(Posicao.Line, Posicao.Column -1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line, pos.Column -1);
            }

            //NO
            pos.DefinirValores(Posicao.Line -1, Posicao.Column-1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line -1, pos.Column -1);
            }

            //NE
            pos.DefinirValores(Posicao.Line -1, Posicao.Column +1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line -1, pos.Column +1);
            }

            //SE
            pos.DefinirValores(Posicao.Line+1, Posicao.Column +1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line +1, pos.Column +1);

            }

            //SO
            pos.DefinirValores(Posicao.Line +1, Posicao.Column -1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line +1, pos.Column -1);

            }

            return mat;
        }
        public override string ToString()
        {
            return "Q";
        }
    }
}
