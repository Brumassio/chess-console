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
                    Console.Clear();
                    Tela.ImprimirTabuleiro(game.Tab);
                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    game.executaMovimento(origem, destino);


                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
        }
    }
}
