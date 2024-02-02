namespace Blackjack;

class CarteGiocatore
{
    public List<Carta> Carte { get; set; } = [];
    public int ValoreTotale => Carte.Sum(x => (int)x.Valore);

}
