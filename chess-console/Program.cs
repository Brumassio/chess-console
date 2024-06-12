using tabuleiro;
using Xadrez;
namespace chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez game = new PartidaDeXadrez();
                while (!game.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(game);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        game.ValidarPosicaoDeOrigem(origem);
                        bool[,] possicoesPossiveis = game.Tab.GetPeca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(game.Tab, possicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        game.ValidarPosicaoDeDestino(origem, destino);

                        game.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine("Error: "+ e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.ImprimirPartida(game);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
        }
    }
}
