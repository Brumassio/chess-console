using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        Console.WriteLine("- ");
                    }
                    else
                    {
                        Console.WriteLine(tab.GetPeca(i, j)+" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
