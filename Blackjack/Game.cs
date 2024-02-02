using System.Net;
using System.Net.Sockets;

namespace Blackjack;

class Game
{
    private bool Playing { get; set; } = true;
    private List<Carta> Mazzo { get; set; } = RiempiMazzo().ToList();
    private CarteGiocatore CarteGiocatoreAttuale { get; set; } = new();
    private int ValoreTotale => CarteGiocatoreAttuale.Carte.Sum(x => (int)x.Valore);
    public Game()
    {
        Mazzo.Shuffle();
    }
    public void Start()
    {
        List<CarteGiocatore> CarteGiocatori = [];
        
        for (int i = 0; i < 2; i++)
        {
            while (Playing)
            {
                Console.WriteLine($"{CheckProbability()}%");
                CarteGiocatoreAttuale.Carte.ForEach(Console.WriteLine);
                switch (int.Parse(Console.ReadLine() ?? "0"))
                {
                    case 1:
                        CarteGiocatoreAttuale.Carte.Add(DrawCard());
                        break;
                    case 2:
                        Playing = false;
                        break;
                }
                if (CarteGiocatoreAttuale.Carte.Sum(x => (int)x.Valore) > 21)
                {
                    CarteGiocatoreAttuale.Carte.ForEach(Console.WriteLine);
                    Console.WriteLine("Sballato");
                    Playing = false;
                }
            }
            CarteGiocatori.Add(CarteGiocatoreAttuale);
            Playing = true;
        }
        var a = CarteGiocatori[^1].ValoreTotale;
        foreach (var x in CarteGiocatori)
        {
            if (x.ValoreTotale < a)
                Console.WriteLine("Giocatore ... ha perso");
            else if (x.ValoreTotale > a)
                Console.WriteLine("Giocatore ... ha vinto");
            else
                Console.WriteLine("Pareggio");
        }
        
    }
    private double CheckProbability()
    {
        List<Carta> carteValide = [];
        foreach (var carta in Mazzo)
        {
            if (ValoreTotale+(int)carta.Valore <= 21)
                carteValide.Add(carta);
        }
        return (double)carteValide.Count / Mazzo.Count * 100;
    }
    private Carta DrawCard()
    {
        Carta carta = Mazzo[0];
        Mazzo.Remove(carta);
        return carta;
    }
    static IEnumerable<Carta> RiempiMazzo()
    {
        foreach (var seme in Enum.GetValues(typeof(Seme)))
        {
            foreach (var valore in Enum.GetValues(typeof(Valore)))
            {
                yield return new((Valore)valore, (Seme)seme);
            }
        }
    }
}
