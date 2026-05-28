class Projekt
{
    static Nastaveni DefaultniNastaveni()
    {
        List<Cichnamon> cichnamons = new List<Cichnamon>();
        List<Trener> treners = new List<Trener>();
        List<Utok> utoks = new List<Utok>();

        utoks[0] = new Utok("Backend", 25, "Útočník zahájí velmi podceňovaný backend, při kterém spadnou trenky protihráči");
        utoks[1] = new Utok("Forehand", 15, "Forehand je silný při správném použití, ale na backhand nemá");
        utoks[2] = new Utok("Chop", 5, "Chop spíše zaskočí než ublíží, ale trenýrky můžou míti potíže");
        utoks[3] = new Utok("Smeč", 60, "Nejsilnější ze všech velikánů, avšak vyžaduje skill. Nepřeceňuj ho!");
        utoks[4] = new Utok("Topspin", 35, "Velmi jednoduchý a i použitelný útok, nejlepší kompromis pro útok i jistotu");

        Cichnamon SvetrMon = new Cichnamon("Svetr", 100, 100, 20, utoks[2], utoks[3]);

        List<Cichnamon> XuCichnamoni = [SvetrMon];

        Trener Xuperman = new Trener(jmeno: "Xuperman", XuCichnamoni, SvetrMon);

        cichnamons.Add(SvetrMon);
        treners.Add(Xuperman);

        Nastaveni defaultniNas = new Nastaveni(cichnamons, treners, utoks);


        return defaultniNas;
    }
    static void Main()
    {
        Console.WriteLine("Akce: 1 - Vytvořit Cichnamona");
        Console.WriteLine("Akce: 2 - Útok základním útokem");
        Console.WriteLine("Akce: 3 - Útok speciálním útokem");
        Console.WriteLine("Akce: 4 - Uzdravit Cichnamona");

    }
}