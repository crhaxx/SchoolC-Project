class Nastaveni
{
    public List<Cichnamon> Cichnamons { get; set; }
    public List<Trener> Treners { get; set; }
    public List<Utok> Utoky { get; set; }

    public Nastaveni(List<Cichnamon> cichnamons, List<Trener> treners, List<Utok> utoky)
    {
        Cichnamons = cichnamons;
        Treners = treners;
        Utoky = utoky;
    }

    public Nastaveni DefaultniNastaveni()
    {
        List<Cichnamon> cichnamons = new List<Cichnamon>();
        List<Trener> treners = new List<Trener>();
        List<Utok> utoks = new List<Utok>();

        utoks.Add(new Utok("Backend", 25, "Útočník zahájí velmi podceňovaný backend, při kterém spadnou trenky protihráči"));
        utoks.Add(new Utok("Forehand", 15, "Forehand je silný při správném použití, ale na backhand nemá"));
        utoks.Add(new Utok("Chop", 5, "Chop spíše zaskočí než ublíží, ale trenýrky můžou míti potíže"));
        utoks.Add(new Utok("Smeč", 60, "Nejsilnější ze všech velikánů, avšak vyžaduje skill. Nepřeceňuj ho!"));
        utoks.Add(new Utok("Topspin", 35, "Velmi jednoduchý a i použitelný útok, nejlepší kompromis pro útok i jistotu"));

        Cichnamon SvetrMon = new Cichnamon("Svetr", 100, 100, 20, utoks[2], utoks[3]);
        Cichnamon DomcaMon = new Cichnamon("Domca", 100, 100, 10, utoks[2], utoks[3]);

        List<Cichnamon> XuCichnamoni = [SvetrMon];

        Trener Xuperman = new Trener(jmeno: "Xuperman", XuCichnamoni, SvetrMon);

        cichnamons.Add(SvetrMon);
        treners.Add(Xuperman);

        Nastaveni defaultniNas = new Nastaveni(cichnamons, treners, utoks);


        return defaultniNas;
    }
}