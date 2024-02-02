
namespace Blackjack
{
    internal class Carta(Valore valore, Seme seme)
    {
        public Valore Valore => valore;
        public Seme Seme => seme;


        public override string ToString()
        {
            return $"{Valore} di {Seme}";
        }


    }
}
