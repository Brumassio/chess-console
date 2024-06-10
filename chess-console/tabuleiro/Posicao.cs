
using System.Data.Common;

namespace tabuleiro
{
    internal class Posicao
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Posicao(int line, int column)
        {
            Line=line;
            Column=column;
        }

        public void DefinirValores(int line, int column)
        {
            Line=line;
            Column=column;
        }
        public override string ToString()
        {
            return Line+ ", " + Column;
        }
    }
}
