
using tabuleiro;

namespace Xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Color JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Color.Branca;
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao posOrigem, Posicao posDestino)
        {
            Peca p = Tab.RetirarPeca(posOrigem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(posDestino);
            Tab.ColocarPeca(p, posDestino);
        }

        public void RealizaJogada(Posicao posOrigem, Posicao posDestino)
        {
            ExecutaMovimento(posOrigem, posDestino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(Tab.GetPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem !");
            }
            if (JogadorAtual != Tab.GetPeca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é a sua !");
            }
            if(!Tab.GetPeca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida !");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.GetPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de Destino Inválida");
            }
        }

        private void MudaJogador()
        {
            if(JogadorAtual == Color.Branca)
            {
                JogadorAtual = Color.Preta;
            }
            else
            {
                JogadorAtual = Color.Branca;
            }
        }
        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Knight(Tab, Color.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Knight(Tab, Color.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Knight(Tab, Color.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Knight(Tab, Color.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Knight(Tab, Color.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tab.ColocarPeca(new King(Tab, Color.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tab.ColocarPeca(new Knight(Tab, Color.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tab.ColocarPeca(new Knight(Tab, Color.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tab.ColocarPeca(new Knight(Tab, Color.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tab.ColocarPeca(new Knight(Tab, Color.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            Tab.ColocarPeca(new Knight(Tab, Color.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tab.ColocarPeca(new King(Tab, Color.Preta), new PosicaoXadrez('d', 8).ToPosicao());


        }
    }
}
