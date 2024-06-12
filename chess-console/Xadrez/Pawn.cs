
using tabuleiro;

namespace Xadrez
{
    internal class Pawn : Peca
    {
        public Pawn(Tabuleiro tab, Cores cor) : base(tab, cor)
        {
        }

        public bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p != null && p.Cor != Cor;
        }

        public bool Livre(Posicao pos)
        {
            return Tab.GetPeca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];

            Posicao pos = new Posicao(0, 0);
            if(Cor == Cores.Branca)
            {
                pos.DefinirValores(Posicao.Line-1, Posicao.Column);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefinirValores(Posicao.Line-2, Posicao.Column);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefinirValores(Posicao.Line-1, Posicao.Column-1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefinirValores(Posicao.Line-1, Posicao.Column+1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }


            }
            else
            {
                pos.DefinirValores(Posicao.Line+1, Posicao.Column);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefinirValores(Posicao.Line+2, Posicao.Column);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefinirValores(Posicao.Line + 1, Posicao.Column-1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefinirValores(Posicao.Line + 1, Posicao.Column+1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }



            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
