﻿using tabuleiro;
using Xadrez;

namespace chess_console
{
    internal class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez part)
        {
            ImprimirTabuleiro(part.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(part);
            Console.WriteLine();
            Console.WriteLine("Turno: "+ part.Turno);

            if (!part.Terminada)
            {
                Console.WriteLine("Aguardando jogada: "+ part.JogadorAtual);
                if (part.Xeque)
                {
                    Console.WriteLine("Você está em xeque !");
                }
            }
            else
            {
                Console.WriteLine("XEQUE MATE");
                Console.WriteLine("Vencedor: "+ part.JogadorAtual);
            }

        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez part)
        {
            Console.WriteLine("\nPeças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(part.pecasCapturadas(Cores.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(part.pecasCapturadas(Cores.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conj)
        {
            Console.Write("[");
            foreach(Peca x in conj)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i=0;i<tab.Lines; i++)
            {
                Console.Write(8- i + " ");
                for (int j = 0; j<tab.Columns; j++)
                {
                    ImprimirPeca(tab.GetPeca(i,j));
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i<tab.Lines; i++)
            {
                Console.Write(8- i + " ");
                for (int j = 0; j<tab.Columns; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.GetPeca(i, j));
                    Console.BackgroundColor = fundoOriginal;    
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1]+ "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cores.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }

        }
    }
}
