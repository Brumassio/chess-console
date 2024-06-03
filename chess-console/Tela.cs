using tabuleiro;

namespace chess_console
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i=0;i<tab.Lines; i++)
            {
                for(int j = 0; j<tab.Columns; j++)
                {
                    if(tab.GetPeca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.GetPeca(i, j)+" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
