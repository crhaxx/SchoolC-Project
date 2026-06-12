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
        Cichnamon DomcaMon = new Cichnamon("Domca", 100, 100, 10, utoks[0], utoks[1]);
        Cichnamon SlabceMon = new Cichnamon("Slabce", 100, 100, 10, utoks[2], utoks[3]);
        Cichnamon SlusnaMon = new Cichnamon("Slusna", 100, 100, 10, utoks[3], utoks[4]);
        Cichnamon VekaMon = new Cichnamon("Veka", 100, 100, 10, utoks[0], utoks[1]);
        Cichnamon kouzelMon = new Cichnamon("Kouzel", 100, 100, 10, utoks[0], utoks[1]);
        Cichnamon tajnaMon = new Cichnamon("Tajna", 100, 100, 10, utoks[0], utoks[1]);
        Cichnamon prirodaMon = new Cichnamon("Priroda", 100, 100, 10, utoks[0], utoks[1]);

        List<Cichnamon> XuCichnamoni = [SvetrMon, VekaMon];
        List<Cichnamon> RabotCichnamoni = [kouzelMon, prirodaMon];
        List<Cichnamon> SlabceCichnamoni = [SlabceMon, tajnaMon];
        List<Cichnamon> SlusnaCichnamoni = [SlusnaMon, DomcaMon];

        Trener Xuperman = new Trener(jmeno: "Xuperman", XuCichnamoni, SvetrMon);
        Trener Rabot = new Trener(jmeno: "Rabot", RabotCichnamoni, kouzelMon);
        Trener Slabce = new Trener(jmeno: "Slabce", SlabceCichnamoni, SlabceMon);
        Trener Slusna = new Trener(jmeno: "Slusna", SlusnaCichnamoni, SlusnaMon);



        cichnamons.Add(SvetrMon);
        cichnamons.Add(DomcaMon);
        cichnamons.Add(SlabceMon);
        cichnamons.Add(SlusnaMon);
        cichnamons.Add(VekaMon);
        cichnamons.Add(kouzelMon);
        cichnamons.Add(tajnaMon);
        cichnamons.Add(prirodaMon);

        treners.Add(Xuperman);
        treners.Add(Rabot);
        treners.Add(Slabce);
        treners.Add(Slusna);

        Nastaveni defaultniNas = new Nastaveni(cichnamons, treners, utoks);


        return defaultniNas;
    }
}