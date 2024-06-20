
using tabuleiro;

namespace Xadrez
{
    internal class Pawn : Peca
    {
        private PartidaDeXadrez Partida;
        public Pawn(Tabuleiro tab, Cores cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            Partida=partida;
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
            if (Cor == Cores.Branca)
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

                //#jogada especial em passant
                if (Posicao.Line == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Line, Posicao.Column-1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.GetPeca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Line-1, esquerda.Column] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Line, Posicao.Column+1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.GetPeca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Line-1, direita.Column] = true;
                    }
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

                //#jogada especial em passant
                if (Posicao.Line == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Line, Posicao.Column-1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.GetPeca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Line+1, esquerda.Column] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Line, Posicao.Column+1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.GetPeca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Line+1, direita.Column] = true;
                    }
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
