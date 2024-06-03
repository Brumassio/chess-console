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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Knight(tab, Color.Preta), new Posicao(1, 2));
                tab.ColocarPeca(new King(tab, Color.Preta), new Posicao(2, 2));
                tab.ColocarPeca(new Knight(tab, Color.Preta), new Posicao(2, 0));
                tab.ColocarPeca(new King(tab, Color.Preta), new Posicao(2, 10));

                Tela.ImprimirTabuleiro(tab);
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
