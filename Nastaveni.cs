class Nastaveni
{
    List<Cichnamon> Cichnamons { get; set; }
    List<Trener> Treners { get; set; }
    List<Utok> Utoky { get; set; }

    public Nastaveni(List<Cichnamon> cichnamons, List<Trener> treners, List<Utok> utoky)
    {
        Cichnamons = cichnamons;
        Treners = treners;
        Utoky = utoky;
    }
}