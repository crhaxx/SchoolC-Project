using static System.Console;

class Projekt
{
    static bool ProtivnikuvTah(Trener protivnik, Cichnamon zvolenyCichnamon, bool hracSeBrani, out bool protivnikSeBrani) {
        Random random = new Random();
        int volbaAkce = random.Next(1, 4);
        protivnikSeBrani = false;

        int volbaCichnamona = random.Next(protivnik.Cichnamoni.Count);
        Cichnamon zvolenyProtivnikuvCichnamon = protivnik.Cichnamoni[volbaCichnamona];
        ConsoleUI.ZobrazitAkci($"Protivník zvolil cichnamona: {zvolenyProtivnikuvCichnamon.Jmeno}");

        switch (volbaAkce) {
            case 1:
                ConsoleUI.ZobrazitAkci("Protivník si zvolil útok!");
                WriteLine();

                if (hracSeBrani && random.Next(2) == 0)
                {
                    ConsoleUI.ZobrazitObranu(zvolenyCichnamon.Jmeno);
                }
                else
                {
                    int indexUtoku = random.Next(2);

                    if (indexUtoku == 0) {
                        zvolenyProtivnikuvCichnamon.ZautocitZakladniUtok(zvolenyCichnamon);
                    }
                    else
                    {
                        zvolenyProtivnikuvCichnamon.ZautocitSpecialniUtok(zvolenyCichnamon);
                    }
                }

                if (zvolenyCichnamon.Zdravi <= 0)
                {
                    return true;
                }
                break;
            case 2:
                ConsoleUI.ZobrazitAkci("Protivník si zvolil obranu!");
                protivnikSeBrani = true;
                break;
            case 3:
                ConsoleUI.ZobrazitAkci("Protivník si zvolil doplnění zdraví!");

                List<Cichnamon> potrebujiUzdraveni = new List<Cichnamon>();
                foreach (Cichnamon c in protivnik.Cichnamoni)
                {
                    if (c.Zdravi > 0 && c.Zdravi < c.MaxZdravi)
                    {
                        potrebujiUzdraveni.Add(c);
                    }
                }

                if (potrebujiUzdraveni.Count == 0)
                {
                    volbaAkce = random.Next(1, 3);
                    if (volbaAkce == 1)
                    {
                        goto case 1;
                    }
                    goto case 2;
                }

                if (zvolenyProtivnikuvCichnamon.Zdravi >= zvolenyProtivnikuvCichnamon.MaxZdravi)
                {
                    zvolenyProtivnikuvCichnamon = potrebujiUzdraveni[random.Next(potrebujiUzdraveni.Count)];
                    ConsoleUI.ZobrazitVarovani("Cichnamon již má maximální zdraví!");
                    ConsoleUI.ZobrazitAkci($"Protivník zvolil jiného cichnamona: {zvolenyProtivnikuvCichnamon.Jmeno}");
                }

                bool bylUzdrav = zvolenyProtivnikuvCichnamon.Uzdravit(10);

                if (bylUzdrav)
                {
                    ConsoleUI.ZobrazitUzdraveni(zvolenyProtivnikuvCichnamon.Jmeno, 10, false);
                }
                break;
    }

    return false;
    }

    static void Game() {
        Clear();
        ConsoleUI.ZobrazitLogo();
        ConsoleUI.ZobrazitNadpis("NOVÁ HRA", ConsoleColor.Green);

        Trener hrac = null;
        Trener protivnik = null;

        ConsoleUI.ZobrazitNadpis("VÝBĚR TRENÉRA", ConsoleColor.Cyan);

        List<string> treneriMenu = new List<string>();
        for (int i = 0; i < Nastaveni.Treners.Count; i++)
        {
            treneriMenu.Add($"{i + 1} - {Nastaveni.Treners[i].Jmeno}");
        }
        ConsoleUI.ZobrazitMenu("Zvolte svého trenéra", treneriMenu);

        int volbaTrenera = ConsoleUI.CtiVolbu("Zadej číslo trenéra: ") - 1;
        WriteLine();

        if (volbaTrenera >= 0 && volbaTrenera < Nastaveni.Treners.Count)
        {
            hrac = Nastaveni.Treners[volbaTrenera];
            ConsoleUI.ZobrazitUspech($"Zvolil jste trenéra: {hrac.Jmeno}");
        }
        else
        {
            ConsoleUI.ZobrazitChybu("Neplatná volba trenéra.");
            ConsoleUI.ZobrazitPokracovat();
            return;
        }

        WriteLine();

        Random random = new Random();
        int indexProtihrace;

        do
        {
            indexProtihrace = random.Next(Nastaveni.Treners.Count);
        } while (Nastaveni.Treners.Count > 1 && indexProtihrace == volbaTrenera);

        protivnik = Nastaveni.Treners[indexProtihrace];
        ConsoleUI.ZobrazitInfo($"Protivník si zvolil trenéra: {protivnik.Jmeno}");
        ConsoleUI.ZobrazitPokracovat();

        int akce = 0;
        bool nekdoUmrel = false;
        bool protivnikSeBrani = false;

        while(nekdoUmrel == false) {
            Clear();
            ConsoleUI.ZobrazitBojovyPrehled(hrac, protivnik);

            ConsoleUI.ZobrazitMenu("VAŠE AKCE", new[]
            {
                "1 - Útok",
                "2 - Obrana",
                "3 - Doplnění zdraví"
            });

            akce = ConsoleUI.CtiVolbu("Zvolte akci: ");
            bool hracSeBrani = false;
            Cichnamon zvolenyCichnamon = null;

            switch (akce)
            {
                case 1:
                {
                    ConsoleUI.ZobrazitAkci("Zvolil jste útok!");
                    WriteLine();
                    bool platnyCichnamon = false;

                    while (platnyCichnamon == false) {
                        ConsoleUI.ZobrazitNadpis("VÝBĚR CICHNAMONA", ConsoleColor.Yellow);
                        hrac.ZobrazitCichnamony();
                        WriteLine();

                        int volbaCichnamona = ConsoleUI.CtiVolbu("Zvolte cichnamona: ") - 1;

                        if (volbaCichnamona < 0 || volbaCichnamona >= hrac.Cichnamoni.Count || hrac.Cichnamoni[volbaCichnamona].Zdravi <= 0)
                        {
                            ConsoleUI.ZobrazitChybu("Neplatná volba cichnamona.");
                            continue;
                        }

                        ConsoleUI.ZobrazitUspech($"Zvolil jste cichnamona: {hrac.Cichnamoni[volbaCichnamona].Jmeno}");
                        zvolenyCichnamon = hrac.Cichnamoni[volbaCichnamona];
                        platnyCichnamon = true;
                    }

                    int indexUtoku = random.Next(2);

                    Cichnamon prvniProtivnikuvCichnamon = protivnik.ZobrazitZijiciCichnamony()[0];

                    if (protivnikSeBrani && random.Next(2) == 0)
                    {
                        ConsoleUI.ZobrazitObranu(prvniProtivnikuvCichnamon.Jmeno);
                    }
                    else if (indexUtoku == 0)
                    {
                        zvolenyCichnamon.ZautocitZakladniUtok(prvniProtivnikuvCichnamon);
                    }
                    else
                    {
                        zvolenyCichnamon.ZautocitSpecialniUtok(prvniProtivnikuvCichnamon);
                    }

                    protivnikSeBrani = false;

                    if (protivnik.ZobrazitZijiciCichnamony().Count == 0) {
                        nekdoUmrel = true;
                        Clear();
                        ConsoleUI.ZobrazitLogo();
                        ConsoleUI.ZobrazitVysledek($"Protihráč {protivnik.Jmeno} byl poražen!", true);
                        ConsoleUI.ZobrazitKonecHry();
                        return;
                    }

                    break;
                }
                case 2:
                {
                    hracSeBrani = true;
                    ConsoleUI.ZobrazitAkci("Zvolil jste obranu!");
                    WriteLine();
                    bool platnyCichnamon = false;

                    while (platnyCichnamon == false) {
                        ConsoleUI.ZobrazitNadpis("VÝBĚR CICHNAMONA", ConsoleColor.Yellow);
                        hrac.ZobrazitCichnamony();
                        WriteLine();

                        int volbaCichnamona = ConsoleUI.CtiVolbu("Zvolte cichnamona: ") - 1;

                        if (volbaCichnamona < 0 || volbaCichnamona >= hrac.Cichnamoni.Count || hrac.Cichnamoni[volbaCichnamona].Zdravi <= 0)
                        {
                            ConsoleUI.ZobrazitChybu("Neplatná volba cichnamona.");
                            continue;
                        }

                        ConsoleUI.ZobrazitUspech($"Zvolil jste cichnamona: {hrac.Cichnamoni[volbaCichnamona].Jmeno}");
                        zvolenyCichnamon = hrac.Cichnamoni[volbaCichnamona];
                        platnyCichnamon = true;
                    }
                    break;
                }
                case 3:
                {
                    ConsoleUI.ZobrazitAkci("Zvolil jste doplnění zdraví!");
                    WriteLine();
                    bool zvolenCichnamon = false;
                    while (zvolenCichnamon == false) {
                        ConsoleUI.ZobrazitNadpis("UZDRAVENÍ", ConsoleColor.Green);
                        ConsoleUI.ZobrazitInfo("Pro změnu zvolte číslo 0");
                        WriteLine();
                        hrac.ZobrazitCichnamony();
                        WriteLine();

                        int volbaCichnamona = ConsoleUI.CtiVolbu("Zvolte cichnamona: ") - 1;

                        if (volbaCichnamona == 0)
                        {
                            continue;
                        }

                        if (volbaCichnamona < 0 || volbaCichnamona >= hrac.Cichnamoni.Count || hrac.Cichnamoni[volbaCichnamona].Zdravi <= 0)
                        {
                            ConsoleUI.ZobrazitChybu("Neplatná volba cichnamona.");
                            continue;
                        }

                        zvolenyCichnamon = hrac.Cichnamoni[volbaCichnamona];
                        bool bylUzdrav = zvolenyCichnamon.Uzdravit(10);
                        if (bylUzdrav) {
                            ConsoleUI.ZobrazitUzdraveni(zvolenyCichnamon.Jmeno, 10, true);
                            zvolenCichnamon = true;
                        } else {
                            ConsoleUI.ZobrazitVarovani($"Vybraný cichnamon {zvolenyCichnamon.Jmeno} již má maximální zdraví!");
                        }
                    }
                    break;
                }
                default:
                    ConsoleUI.ZobrazitChybu("Neplatná akce.");
                    break;
            }

            if (zvolenyCichnamon != null)
            {
                WriteLine();
                ConsoleUI.ZobrazitNadpis("TAH PROTIVNÍKA", ConsoleColor.Red);
                ConsoleUI.ZobrazitOddelovac();

                bool hracUmrel = ProtivnikuvTah(protivnik, zvolenyCichnamon, hracSeBrani, out protivnikSeBrani);
                if (hracUmrel)
                {
                    if (hrac.ZobrazitZijiciCichnamony().Count == 0)
                    {
                        nekdoUmrel = true;
                        Clear();
                        ConsoleUI.ZobrazitLogo();
                        ConsoleUI.ZobrazitVysledek($"Vy ({hrac.Jmeno}) jste poraženi!", false);
                        ConsoleUI.ZobrazitKonecHry();
                        return;
                    }
                }

                ConsoleUI.ZobrazitPokracovat();
            }
        }
    }

    static void Main()
    {
        Clear();
        Nastaveni.DefaultniNastaveni();
        int akce = 0;
        bool pokracovat = true;

        while (pokracovat)
        {
            Clear();
            ConsoleUI.ZobrazitLogo();
            ConsoleUI.ZobrazitMenu("HLAVNÍ MENU", new[]
            {
                "1 - Spustit hru",
                "2 - Zobrazit Cichnamony",
                "3 - Zobrazit Trenery",
                "4 - Ukončit program"
            });

            akce = ConsoleUI.CtiVolbu("Zadej číslo akce: ");
            WriteLine();

            switch (akce)
            {
                case 1:
                    Game();
                    break;
                case 2:
                    Clear();
                    ConsoleUI.ZobrazitVsechnyCichnamony();
                    ConsoleUI.ZobrazitPokracovat();
                    break;
                case 3:
                    Clear();
                    ConsoleUI.ZobrazitTrenery();
                    ConsoleUI.ZobrazitPokracovat();
                    break;
                case 4:
                    Clear();
                    ConsoleUI.ZobrazitLogo();
                    ConsoleUI.ZobrazitInfo("Program ukončen. Na shledanou!");
                    pokracovat = false;
                    return;
                default:
                    ConsoleUI.ZobrazitChybu("Neplatná akce.");
                    ConsoleUI.ZobrazitPokracovat();
                    break;
            }
        }
    }
}
