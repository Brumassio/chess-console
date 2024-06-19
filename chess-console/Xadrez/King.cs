using tabuleiro;

namespace Xadrez
{
    internal class King : Peca
    {
        private PartidaDeXadrez Partida;
        public King(Tabuleiro tab, Cores cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            Partida =partida;

        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p == null || p.Cor != Cor;
        }

        public bool TesteTorreRoque(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p != null && p is Rook && p.Cor == Cor && p.QteMovimentos == 0;
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

            //jogada especial ROQUE

            if(QteMovimentos == 0 && !Partida.Xeque)
            {
                //#jogadaespeciaal roque pequeno
                Posicao posT1 = new Posicao(Posicao.Line, Posicao.Column+3);
                if (TesteTorreRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Line, Posicao.Column+1);
                    Posicao p2 = new Posicao(Posicao.Line, Posicao.Column+2);   
                    if(Tab.GetPeca(p1) == null && Tab.GetPeca(p2) == null)
                    {
                        mat[Posicao.Line, Posicao.Column +2] = true;
                    }

                }

                //#jogadaespeciaal roque grande
                Posicao posT2 = new Posicao(Posicao.Line, Posicao.Column-4);
                if (TesteTorreRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Line, Posicao.Column-1);
                    Posicao p2 = new Posicao(Posicao.Line, Posicao.Column-2);
                    Posicao p3 = new Posicao(Posicao.Line, Posicao.Column-3);

                    if (Tab.GetPeca(p1) == null && Tab.GetPeca(p2) == null && Tab.GetPeca(p3) == null)
                    {
                        mat[Posicao.Line, Posicao.Column -2] = true;
                    }

                }
            }

            return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
