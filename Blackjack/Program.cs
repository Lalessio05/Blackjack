using System.Net.Http.Headers;

namespace Blackjack;
internal class Program
{

    static void Main(string[] args)
    {
        Game g = new();
        g.Start();
    }
}
