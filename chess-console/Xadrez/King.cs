using tabuleiro;

namespace Xadrez
{
    internal class King : Peca
    {
        public King (Tabuleiro tab, Color cor) : base (tab, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
