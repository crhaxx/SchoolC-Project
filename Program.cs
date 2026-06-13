using static System.Console;

class Projekt
{
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
                    SpustitHru();
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

    static void SpustitHru() {
        Clear();
        Nastaveni.DefaultniNastaveni();
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

        HracuvTah(hrac, protivnik);
    }

    static void HracuvTah(Trener Hrac, Trener Protivnik) {
        Random random = new Random();
        Trener hrac = Hrac;
        Trener protivnik = Protivnik;

        int akce = 0;
        bool nekdoUmrel = false;
        bool protivnikSeBrani = false;

        while(nekdoUmrel == false) {
            Clear();
            protivnikSeBrani = false;
            ConsoleUI.ZobrazitBojovyPrehled(hrac, protivnik);

            ConsoleUI.ZobrazitMenu("VAŠE AKCE", new[]
            {
                "1 - Útok",
                "2 - Obrana",
                "3 - Doplnění zdraví"
            });

            akce = ConsoleUI.CtiVolbu("Zvolte akci: ");
            bool hracSeBrani = false;
            bool hracUtoci = false;
            int indexUtokuHrace = 0;
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
                        hrac.VybratCichnamona(zvolenyCichnamon);
                        platnyCichnamon = true;
                    }

                    hracUtoci = true;
                    indexUtokuHrace = random.Next(2);
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
                        hrac.VybratCichnamona(zvolenyCichnamon);
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

                        int volba = ConsoleUI.CtiVolbu("Zvolte cichnamona: ");

                        if (volba == 0)
                        {
                            break;
                        }

                        int volbaCichnamona = volba - 1;

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

                bool hracUmrel = ProtivnikuvTah(protivnik, hrac, hracSeBrani, out protivnikSeBrani);
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

                if (hracUtoci && zvolenyCichnamon.Zdravi > 0 && protivnik.ZobrazitZijiciCichnamony().Count > 0)
                {
                    WriteLine();
                    ConsoleUI.ZobrazitNadpis("VÁŠ ÚTOK", ConsoleColor.Green);
                    ConsoleUI.ZobrazitOddelovac();

                    Cichnamon cilProtivnika = protivnik.ZiskatAktivnihoCichnamona()!;

                    if (protivnikSeBrani && random.Next(2) == 0)
                    {
                        ConsoleUI.ZobrazitObranu(cilProtivnika.Jmeno, true);
                    }
                    else
                    {
                        if (protivnikSeBrani)
                        {
                            ConsoleUI.ZobrazitNeuspesnouObranu(cilProtivnika.Jmeno, true);
                        }

                        if (indexUtokuHrace == 0)
                        {
                            zvolenyCichnamon.ZautocitZakladniUtok(cilProtivnika);
                        }
                        else
                        {
                            zvolenyCichnamon.ZautocitSpecialniUtok(cilProtivnika);
                        }
                    }

                    if (protivnik.ZobrazitZijiciCichnamony().Count == 0)
                    {
                        nekdoUmrel = true;
                        Clear();
                        ConsoleUI.ZobrazitLogo();
                        ConsoleUI.ZobrazitVysledek($"Protihráč {protivnik.Jmeno} byl poražen!", true);
                        ConsoleUI.ZobrazitKonecHry();
                        return;
                    }
                }

                ConsoleUI.ZobrazitPokracovat();
            }
        }
    }

    static bool ProtivnikuvTah(Trener protivnik, Trener hrac, bool hracSeBrani, out bool protivnikSeBrani) {
        Random random = new Random();
        int volbaAkce = random.Next(1, 4);
        protivnikSeBrani = false;

        List<Cichnamon> zijiciCichnamoni = protivnik.ZobrazitZijiciCichnamony();
        if (zijiciCichnamoni.Count == 0)
        {
            return false;
        }

        Cichnamon zvolenyProtivnikuvCichnamon = zijiciCichnamoni[random.Next(zijiciCichnamoni.Count)];
        protivnik.VybratCichnamona(zvolenyProtivnikuvCichnamon);
        ConsoleUI.ZobrazitAkci($"Protivník zvolil cichnamona: {zvolenyProtivnikuvCichnamon.Jmeno}");

        Cichnamon? cilHrace = hrac.ZiskatAktivnihoCichnamona();
        if (cilHrace == null)
        {
            return false;
        }

        switch (volbaAkce) {
            case 1:
                ConsoleUI.ZobrazitAkci("Protivník si zvolil útok!");
                WriteLine();

                if (hracSeBrani && random.Next(2) == 0)
                {
                    ConsoleUI.ZobrazitObranu(cilHrace.Jmeno);
                }
                else
                {
                    if (hracSeBrani)
                    {
                        ConsoleUI.ZobrazitNeuspesnouObranu(cilHrace.Jmeno);
                    }

                    int indexUtoku = random.Next(2);

                    if (indexUtoku == 0) {
                        zvolenyProtivnikuvCichnamon.ZautocitZakladniUtok(cilHrace);
                    }
                    else
                    {
                        zvolenyProtivnikuvCichnamon.ZautocitSpecialniUtok(cilHrace);
                    }
                }

                if (cilHrace.Zdravi <= 0)
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
                    return ProtivnikuvTah(protivnik, hrac, hracSeBrani, out protivnikSeBrani);
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
}
