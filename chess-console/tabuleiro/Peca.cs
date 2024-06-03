
namespace tabuleiro
{
    internal class Peca
    {
        public Posicao Posicao { get; set; }
        public Color Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Color cor)
        {
            Posicao=null;
            Tab=tab;
            Cor=cor;
            QteMovimentos = 0;
        }
    }
}
