static class Nastaveni
{
    public static List<Cichnamon> Cichnamons { get; set; }
    public static List<Trener> Treners { get; set; }
    public static List<Utok> Utoky { get; set; }

    public static void DefaultniNastaveni()
    {
        List<Cichnamon> cichnamons = new List<Cichnamon>();
        List<Trener> treners = new List<Trener>();
        List<Utok> utoks = new List<Utok>();

        utoks.Add(new Utok("Backend", 25, "Útočník zahájí velmi podceňovaný backend, při kterém spadnou trenky protihráči"));
        utoks.Add(new Utok("Forehand", 15, "Forehand je silný při správném použití, ale na backhand nemá"));
        utoks.Add(new Utok("Chop", 5, "Chop spíše zaskočí než ublíží, ale trenýrky můžou míti potíže"));
        utoks.Add(new Utok("Smeč", 60, "Nejsilnější ze všech velikánů, avšak vyžaduje skill. Nepřeceňuj ho!"));
        utoks.Add(new Utok("Topspin", 35, "Velmi jednoduchý a i použitelný útok, nejlepší kompromis pro útok i jistotu"));
        utoks.Add(new Utok("Servis", 22, "Krátký servis přistane těsně za sítí a protihráč běží jak blázen"));
        utoks.Add(new Utok("Backspin", 18, "Míček letí pomalu, ale po odrazu padá k zemi jak zrádná past"));
        utoks.Add(new Utok("Lob", 10, "Vysoký oblouk přes protihráče — trpělivost je taky zbraň"));
        utoks.Add(new Utok("Blok", 8, "Pasivní blok vrátí energii soupeře, ale občas ho úplně vygumuje"));
        utoks.Add(new Utok("Drive", 28, "Rovný rychlý drive bez obalu, čistá rychlost a přesnost"));
        utoks.Add(new Utok("Síťovka", 24, "Jemná síťovka — protihráč se natahuje, ale míček už je na druhé straně"));
        utoks.Add(new Utok("Backhand", 20, "Backhand z rohu stolu, technicky náročný, ale spolehlivý"));
        utoks.Add(new Utok("Boční rotace", 32, "Míček ostře zatáčí do boku, soupeř míří špatným směrem"));

        Cichnamon SvetrMon = new Cichnamon("Svetr", 85, 85, utoks[2], utoks[3]);
        Cichnamon DomcaMon = new Cichnamon("Domca", 115, 115, utoks[1], utoks[0]);
        Cichnamon PepikMon = new Cichnamon("Pepík", 125, 125, utoks[2], utoks[8]);
        Cichnamon MaraMon = new Cichnamon("Mára", 80, 80, utoks[5], utoks[4]);
        Cichnamon VitekMon = new Cichnamon("Vítek", 70, 70, utoks[9], utoks[4]);
        Cichnamon RobikMon = new Cichnamon("Robík", 95, 95, utoks[6], utoks[12]);
        Cichnamon FilaMon = new Cichnamon("Fíla", 90, 90, utoks[2], utoks[10]);
        Cichnamon LubaMon = new Cichnamon("Luba", 110, 110, utoks[7], utoks[11]);

        List<Cichnamon> XuCichnamoni = [SvetrMon, VitekMon];
        List<Cichnamon> RabotCichnamoni = [RobikMon, LubaMon];
        List<Cichnamon> KubaCichnamoni = [PepikMon, FilaMon];
        List<Cichnamon> HonzaCichnamoni = [MaraMon, DomcaMon];

        Trener Xuperman = new Trener(jmeno: "Xuperman", XuCichnamoni, SvetrMon);
        Trener Rabot = new Trener(jmeno: "Rabot", RabotCichnamoni, RobikMon);
        Trener Kuba = new Trener(jmeno: "Kuba", KubaCichnamoni, PepikMon);
        Trener Honza = new Trener(jmeno: "Honza", HonzaCichnamoni, MaraMon);

        cichnamons = [SvetrMon, DomcaMon, PepikMon, MaraMon, VitekMon, RobikMon, FilaMon, LubaMon];

        treners = [Xuperman, Rabot, Kuba, Honza];

        Cichnamons = cichnamons;
        Treners = treners;
        Utoky = utoks;
    }
}
