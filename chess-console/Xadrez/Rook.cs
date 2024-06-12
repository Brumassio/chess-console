using tabuleiro;

namespace Xadrez
{
    internal class Rook : Peca
    {
        public Rook(Tabuleiro tab, Cores cor) : base(tab, cor)
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
                pos.Line = pos.Line - 1;
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
                pos.Line = pos.Line + 1;
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
                pos.Column = pos.Column +1;
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
                pos.Column = pos.Column -1;
            }


            return mat;
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
