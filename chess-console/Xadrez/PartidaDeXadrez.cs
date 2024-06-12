
using System.Drawing;
using tabuleiro;

namespace Xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cores JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cores.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao posOrigem, Posicao posDestino)
        {
            Peca p = Tab.RetirarPeca(posOrigem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(posDestino);
            Tab.ColocarPeca(p, posDestino);
            if(pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem,Posicao destino,Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQteMovimentos();
            if(pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }
        public void RealizaJogada(Posicao posOrigem, Posicao posDestino)
        {
            Peca pecaCapturada = ExecutaMovimento(posOrigem, posDestino);
            if (EstaEmXeque(JogadorAtual))
            {
                desfazMovimento(posOrigem, posDestino, pecaCapturada);
                throw new TabuleiroException("você não pode se colocar em xeque");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (testeXequemate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.GetPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem !");
            }
            if (JogadorAtual != Tab.GetPeca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é a sua !");
            }
            if (!Tab.GetPeca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida !");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.GetPeca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de Destino Inválida");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cores.Branca)
            {
                JogadorAtual = Cores.Preta;
            }
            else
            {
                JogadorAtual = Cores.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cores cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in PecasCapturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cores cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cores Adversaria(Cores cor)
        {
            if(cor == Cores.Branca)
            {
                return Cores.Preta;
            }
            else
            {
                return Cores.Branca;
            }
        }

        private Peca Rei(Cores cor)
        {
            foreach ( Peca x in pecasEmJogo(cor))
            {
                if(x is King)
                {
                    return x;
                }
            }

            return null;
        }

        public bool EstaEmXeque(Cores cor)
        {
            Peca R = Rei(cor);
            if(R == null)
            {
                throw new TabuleiroException("Não tem rei dessa cor: "+ cor);
            }
            foreach(Peca x in pecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Line, R.Posicao.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequemate(Cores cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for(int i=0; i<Tab.Lines; i++)
                {
                    for(int j=0;j<Tab.Columns; j++)
                    {
                        Posicao origem = x.Posicao;
                        Posicao destino = new Posicao(i, j);
                        Peca pecaCapturada = ExecutaMovimento(origem, destino);
                        bool testeXeque = EstaEmXeque(cor);
                        desfazMovimento(origem, destino, pecaCapturada);
                        if (testeXeque)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1,new Rook(Tab, Cores.Branca));
            ColocarNovaPeca('b', 1, new Knight(Tab, Cores.Branca));
            ColocarNovaPeca('c', 1, new Bishop(Tab, Cores.Branca));
            ColocarNovaPeca('d', 1, new Queen(Tab, Cores.Branca));
            ColocarNovaPeca('e', 1, new King(Tab, Cores.Branca));
            ColocarNovaPeca('f', 1, new Bishop(Tab, Cores.Branca));
            ColocarNovaPeca('g', 1, new Knight(Tab, Cores.Branca));
            ColocarNovaPeca('h', 1, new Rook(Tab, Cores.Branca));
            ColocarNovaPeca('a', 2, new Pawn(Tab, Cores.Branca));
            ColocarNovaPeca('b', 2, new Pawn(Tab, Cores.Branca));
            ColocarNovaPeca('c', 2, new Pawn(Tab, Cores.Branca));
            ColocarNovaPeca('d', 2, new Pawn(Tab, Cores.Branca));
            ColocarNovaPeca('e', 2, new Pawn(Tab, Cores.Branca));
            ColocarNovaPeca('f', 2, new Pawn(Tab, Cores.Branca));
            ColocarNovaPeca('g', 2, new Pawn(Tab, Cores.Branca));
            ColocarNovaPeca('h', 2, new Pawn(Tab, Cores.Branca));

            ColocarNovaPeca('a', 8, new Rook(Tab, Cores.Preta));
            ColocarNovaPeca('b', 8, new Knight(Tab, Cores.Preta)); 
            ColocarNovaPeca('c', 8, new Bishop(Tab, Cores.Preta));
            ColocarNovaPeca('d', 8, new Queen(Tab, Cores.Preta));
            ColocarNovaPeca('e', 8, new King(Tab, Cores.Preta));
            ColocarNovaPeca('f', 8, new Bishop(Tab, Cores.Preta));
            ColocarNovaPeca('g', 8, new Knight(Tab, Cores.Preta));
            ColocarNovaPeca('h', 8, new Rook(Tab, Cores.Preta));
            ColocarNovaPeca('a', 7, new Pawn(Tab, Cores.Preta));
            ColocarNovaPeca('b', 7, new Pawn(Tab, Cores.Preta));
            ColocarNovaPeca('c', 7, new Pawn(Tab, Cores.Preta));
            ColocarNovaPeca('d', 7, new Pawn(Tab, Cores.Preta));
            ColocarNovaPeca('e', 7, new Pawn(Tab, Cores.Preta));
            ColocarNovaPeca('f', 7, new Pawn(Tab, Cores.Preta));
            ColocarNovaPeca('g', 7, new Pawn(Tab, Cores.Preta));
            ColocarNovaPeca('h', 7, new Pawn(Tab, Cores.Preta));



        }
    }
}
