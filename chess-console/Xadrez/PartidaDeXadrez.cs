
using tabuleiro;

namespace Xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int Turno { get; set; }
        private Color JogadorAtual { get; set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Color.Branca;
            Terminada = false;
            ColocarPecas();
        }

        public void executaMovimento(Posicao posOrigem, Posicao posDestino)
        {
            Peca p = Tab.RetirarPeca(posOrigem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(posDestino);
            Tab.ColocarPeca(p, posDestino);
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
