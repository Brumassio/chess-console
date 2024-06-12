using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez
{
    internal class Bishop : Peca
    {
        public Bishop(Tabuleiro tab, Cores cor) : base(tab, cor) { }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];

            Posicao pos = new Posicao(0, 0);

            //NO
            pos.DefinirValores(Posicao.Line -1, Posicao.Column-1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Line -1 , pos.Column -1);
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
            return "B";
        }
    }


}
