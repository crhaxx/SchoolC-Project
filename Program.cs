using static System.Console;

class Projekt
{
    static void Game(Nastaveni nastaveni) {
                    Clear();
                    WriteLine();
                    WriteLine("Hra spuštěna!");
                    WriteLine();
                    WriteLine();

                    Trener hrac = null;
                    Trener protivnik = null;

                    WriteLine("Zvolte svého trenéra");
                    for (int i = 0; i < nastaveni.Treners.Count; i++)
                    {
                        WriteLine($"{i + 1} - {nastaveni.Treners[i].Jmeno}");
                    }

                    Write("Zadej číslo trenéra: ");

                    int volbaTrenera = int.Parse(ReadLine()) - 1;

                    WriteLine();

                    if (volbaTrenera >= 0 && volbaTrenera < nastaveni.Treners.Count)
                    {
                        hrac = nastaveni.Treners[volbaTrenera];
                        WriteLine($"Zvolil jste trenéra: {hrac.Jmeno}");
                    }
                    else
                    {
                        WriteLine("Neplatná volba trenéra.");
                    }

                    WriteLine();

                    Random random = new Random();
                    int indexProtihrace;

                    do
                    {
                        indexProtihrace = random.Next(nastaveni.Treners.Count);
                    } while (nastaveni.Treners.Count > 1 && indexProtihrace == volbaTrenera);

                    protivnik = nastaveni.Treners[indexProtihrace];
                    WriteLine($"Protivník si zvolil trenéra: {protivnik.Jmeno}");

                    int akce = 0;
                    bool nekdoUmrel = false;

                    WriteLine();
                    WriteLine();
                    WriteLine("Hra spuštěna! Bojujte!");
                    
                    while(nekdoUmrel == false) {
                        Clear();
                        WriteLine();
                        WriteLine();
                        WriteLine($"Vaš trenér: {hrac.Jmeno} - HP: {hrac.ZobrazitZijiciCichnamony()[0].Zdravi}/{hrac.ZobrazitZijiciCichnamony()[0].MaxZdravi}");
                        WriteLine($"Protihráč: {protivnik.Jmeno} - HP: {protivnik.ZobrazitZijiciCichnamony()[0].Zdravi}/{protivnik.ZobrazitZijiciCichnamony()[0].MaxZdravi}");
                        WriteLine();
                        WriteLine("1 - Útok");
                        WriteLine("2 - Obrana");
                        Write("Zvolte akci: ");

                        akce = int.Parse(ReadLine());

                        switch (akce)
                        {
                            case 1:
                                WriteLine("Zvolil jste útok!");
                                WriteLine();
                                WriteLine("Zvolte cichnamona pro útok");
                                hrac.ZobrazitCichnamony();
                                WriteLine();
                                Write("Zvolte cichnamona: ");
                                Cichnamon zvolenyCichnamon = null;
                                int volbaCichnamona = int.Parse(ReadLine()) - 1;

                                if (volbaCichnamona < 0 || volbaCichnamona >= hrac.Cichnamoni.Count)
                                {
                                    WriteLine("Neplatná volba cichnamona.");
                                    break;
                                } else {
                                    WriteLine($"Zvolil jste cichnamona: {hrac.Cichnamoni[volbaCichnamona].Jmeno}");
                                    zvolenyCichnamon = hrac.Cichnamoni[volbaCichnamona];
                                }

                                random = new Random();

                                int indexUtoku = random.Next(2);

                                Cichnamon prvniProtivnikuvCichnamon = protivnik.ZobrazitZijiciCichnamony()[0];
                                
                                if (indexUtoku == 0)
                                {
                                    zvolenyCichnamon.ZautocitZakladniUtok(prvniProtivnikuvCichnamon);
                                }
                                else
                                {
                                    zvolenyCichnamon.ZautocitSpecialniUtok(prvniProtivnikuvCichnamon);
                                }

                                if (prvniProtivnikuvCichnamon.Zdravi <= 0)
                                {
                                    nekdoUmrel = true;
                                    WriteLine($"Protihráč {protivnik.Jmeno} byl poražen!");

                                    WriteLine();
                                    WriteLine();
                                    WriteLine("Hra ukončena!");
                                    WriteLine();
                                    WriteLine();
                                    return;
                                }

                                break;
                            case 2:
                                
                                break;
                            default:
                                WriteLine("Neplatná akce.");
                                break;
                        }
                    }
    }

    static void Main()
    {
        Nastaveni nastaveni = new Nastaveni(new List<Cichnamon>(), new List<Trener>(), new List<Utok>()).DefaultniNastaveni();
        int akce = 0;
        bool pokracovat = true;

        while (pokracovat)
        {
            WriteLine("Akce: 1 - Spustit hru");
            WriteLine("Akce: 2 - Zobrazit Cichnamony");
            WriteLine("Akce: 3 - Zobrazit Trenery");
            WriteLine("Akce: 4 - Ukoncit program");
            WriteLine();
            Write("Zadej číslo akce: ");

            akce = int.Parse(ReadLine());

            switch (akce)
            {
                case 1:
                    Game(nastaveni);
                    break;
                case 2:
                    WriteLine("");
                    WriteLine("Dostupní Cichnamoni:");
                    WriteLine("");
                    foreach (Cichnamon cichnamon in nastaveni.Cichnamons)
                    {
                        WriteLine($"Cichnamon: {cichnamon.Jmeno}, HP: {cichnamon.Zdravi}, MaxHP: {cichnamon.MaxZdravi}");
                    }
                    WriteLine("");
                    WriteLine("");
                    break;
                case 3:
                    WriteLine("");
                    WriteLine("Dostupní Trenéři:");
                    WriteLine("");
                    foreach (Trener trener in nastaveni.Treners)
                    {
                        WriteLine($"Trener: {trener.Jmeno}");
                    }
                    WriteLine("");
                    WriteLine("");
                    break;
                case 4:
                    WriteLine("");
                    WriteLine("");
                    WriteLine("");
                    WriteLine("Program ukončen.");
                    pokracovat = false;
                    return;
                default:
                    WriteLine("Neplatná akce.");
                    break;
            }
        }
    }
}