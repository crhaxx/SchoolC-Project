using static System.Console;

class Projekt
{
    static void Main()
    {
        Clear();
        Nastaveni.DefaultniNastaveni();
        HlavniMenu();
    }

    static void HlavniMenu()
    {
        while (true)
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

            int volba = ConsoleUI.CtiVolbu("Zadej číslo akce: ");
            WriteLine();

            if (volba == 4)
            {
                Clear();
                ConsoleUI.ZobrazitLogo();
                ConsoleUI.ZobrazitInfo("Program ukončen. Na shledanou!");
                return;
            }

            ZpracovatHlavniMenuVolbu(volba);
        }
    }

    static void ZpracovatHlavniMenuVolbu(int volba)
    {
        switch (volba)
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
            default:
                ConsoleUI.ZobrazitChybu("Neplatná akce.");
                ConsoleUI.ZobrazitPokracovat();
                break;
        }
    }

    static void SpustitHru()
    {
        Clear();
        Nastaveni.DefaultniNastaveni();
        ConsoleUI.ZobrazitLogo();
        ConsoleUI.ZobrazitNadpis("NOVÁ HRA", ConsoleColor.Green);

        int indexHrace = VybratIndexTrenera();
        if (indexHrace < 0)
        {
            return;
        }

        Trener hrac = Nastaveni.Treners[indexHrace];
        Trener protivnik = VybratNahodnehoProtivnika(indexHrace);
        BojovaSmycka(hrac, protivnik);
    }

    static int VybratIndexTrenera()
    {
        ConsoleUI.ZobrazitNadpis("VÝBĚR TRENÉRA", ConsoleColor.Cyan);

        List<string> treneriMenu = new List<string>();
        for (int i = 0; i < Nastaveni.Treners.Count; i++)
        {
            treneriMenu.Add($"{i + 1} - {Nastaveni.Treners[i].Jmeno}");
        }
        ConsoleUI.ZobrazitMenu("Zvolte svého trenéra", treneriMenu);

        int indexHrace = ConsoleUI.CtiVolbu("Zadej číslo trenéra: ") - 1;
        WriteLine();

        if (indexHrace < 0 || indexHrace >= Nastaveni.Treners.Count)
        {
            ConsoleUI.ZobrazitChybu("Neplatná volba trenéra.");
            ConsoleUI.ZobrazitPokracovat();
            return -1;
        }

        Trener hrac = Nastaveni.Treners[indexHrace];
        ConsoleUI.ZobrazitUspech($"Zvolil jste trenéra: {hrac.Jmeno}");
        WriteLine();
        return indexHrace;
    }

    static Trener VybratNahodnehoProtivnika(int indexHrace)
    {
        Random random = new Random();
        int indexProtihrace;

        do
        {
            indexProtihrace = random.Next(Nastaveni.Treners.Count);
        } while (Nastaveni.Treners.Count > 1 && indexProtihrace == indexHrace);

        Trener protivnik = Nastaveni.Treners[indexProtihrace];
        ConsoleUI.ZobrazitInfo($"Protivník si zvolil trenéra: {protivnik.Jmeno}");
        ConsoleUI.ZobrazitPokracovat();
        return protivnik;
    }

    static void BojovaSmycka(Trener hrac, Trener protivnik)
    {
        Random random = new Random();
        bool protivnikSeBrani = false;

        while (true)
        {
            Clear();
            ConsoleUI.ZobrazitBojovyPrehled(hrac, protivnik);
            ZobrazitAkceMenu();

            int akce = ConsoleUI.CtiVolbu("Zvolte akci: ");
            bool hracSeBrani = false;
            bool pokracovatProtivnikem = false;
            Cichnamon zvolenyCichnamon = null;

            switch (akce)
            {
                case 1:
                    zvolenyCichnamon = VybratZijicihoCichnamona(hrac, "Zvolil jste útok!");
                    bool protivnikPorazen = HracUtoci(zvolenyCichnamon, protivnik, protivnikSeBrani, random);
                    protivnikSeBrani = false;

                    if (protivnikPorazen)
                    {
                        UkoncitHru($"Protihráč {protivnik.Jmeno} byl poražen!", true);
                        return;
                    }

                    pokracovatProtivnikem = true;
                    break;
                case 2:
                    hracSeBrani = true;
                    zvolenyCichnamon = VybratZijicihoCichnamona(hrac, "Zvolil jste obranu!");
                    pokracovatProtivnikem = true;
                    break;
                case 3:
                    zvolenyCichnamon = ProvestHracovoUzdraveni(hrac);
                    if (zvolenyCichnamon != null)
                    {
                        pokracovatProtivnikem = true;
                    }
                    break;
                default:
                    ConsoleUI.ZobrazitChybu("Neplatná akce.");
                    break;
            }

            if (pokracovatProtivnikem)
            {
                int vysledekTahu = ProvestTahProtivnika(hrac, protivnik, zvolenyCichnamon, hracSeBrani, random);

                if (vysledekTahu == 2)
                {
                    return;
                }

                if (vysledekTahu == 1)
                {
                    protivnikSeBrani = true;
                }
                else
                {
                    protivnikSeBrani = false;
                }
            }
        }
    }

    static void ZobrazitAkceMenu()
    {
        ConsoleUI.ZobrazitMenu("VAŠE AKCE", new[]
        {
            "1 - Útok",
            "2 - Obrana",
            "3 - Doplnění zdraví"
        });
    }

    static Cichnamon VybratZijicihoCichnamona(Trener hrac, string uvodniZprava)
    {
        ConsoleUI.ZobrazitAkci(uvodniZprava);
        WriteLine();

        while (true)
        {
            ConsoleUI.ZobrazitNadpis("VÝBĚR CICHNAMONA", ConsoleColor.Yellow);
            hrac.ZobrazitCichnamony();
            WriteLine();

            int volbaCichnamona = ConsoleUI.CtiVolbu("Zvolte cichnamona: ") - 1;

            if (volbaCichnamona < 0 || volbaCichnamona >= hrac.Cichnamoni.Count || hrac.Cichnamoni[volbaCichnamona].Zdravi <= 0)
            {
                ConsoleUI.ZobrazitChybu("Neplatná volba cichnamona.");
                continue;
            }

            Cichnamon zvolenyCichnamon = hrac.Cichnamoni[volbaCichnamona];
            ConsoleUI.ZobrazitUspech($"Zvolil jste cichnamona: {zvolenyCichnamon.Jmeno}");
            return zvolenyCichnamon;
        }
    }

    static bool HracUtoci(Cichnamon zvolenyCichnamon, Trener protivnik, bool protivnikSeBrani, Random random)
    {
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

        return protivnik.ZobrazitZijiciCichnamony().Count == 0;
    }

    static Cichnamon ProvestHracovoUzdraveni(Trener hrac)
    {
        ConsoleUI.ZobrazitAkci("Zvolil jste doplnění zdraví!");
        WriteLine();

        while (true)
        {
            ConsoleUI.ZobrazitNadpis("UZDRAVENÍ", ConsoleColor.Green);
            ConsoleUI.ZobrazitInfo("Pro změnu zvolte číslo 0");
            WriteLine();
            hrac.ZobrazitCichnamony();
            WriteLine();

            int volba = ConsoleUI.CtiVolbu("Zvolte cichnamona: ");

            if (volba == 0)
            {
                return null;
            }

            int volbaCichnamona = volba - 1;

            if (volbaCichnamona < 0 || volbaCichnamona >= hrac.Cichnamoni.Count || hrac.Cichnamoni[volbaCichnamona].Zdravi <= 0)
            {
                ConsoleUI.ZobrazitChybu("Neplatná volba cichnamona.");
                continue;
            }

            Cichnamon zvolenyCichnamon = hrac.Cichnamoni[volbaCichnamona];
            bool bylUzdrav = zvolenyCichnamon.Uzdravit(10);

            if (bylUzdrav)
            {
                ConsoleUI.ZobrazitUzdraveni(zvolenyCichnamon.Jmeno, 10, true);
                return zvolenyCichnamon;
            }

            ConsoleUI.ZobrazitVarovani($"Vybraný cichnamon {zvolenyCichnamon.Jmeno} již má maximální zdraví!");
        }
    }

    // 0 = hra pokračuje, protivník nebrání
    // 1 = hra pokračuje, protivník se brání
    // 2 = hráč prohrál
    static int ProvestTahProtivnika(Trener hrac, Trener protivnik, Cichnamon zvolenyCichnamon, bool hracSeBrani, Random random)
    {
        WriteLine();
        ConsoleUI.ZobrazitNadpis("TAH PROTIVNÍKA", ConsoleColor.Red);
        ConsoleUI.ZobrazitOddelovac();

        int stavProtivnika = ProtivnikuvTah(protivnik, zvolenyCichnamon, hracSeBrani, random);

        if (stavProtivnika == 3 && hrac.ZobrazitZijiciCichnamony().Count == 0)
        {
            UkoncitHru($"Vy ({hrac.Jmeno}) jste poraženi!", false);
            return 2;
        }

        ConsoleUI.ZobrazitPokracovat();

        if (stavProtivnika == 1)
        {
            return 1;
        }

        return 0;
    }

    static void UkoncitHru(string zprava, bool vyhra)
    {
        Clear();
        ConsoleUI.ZobrazitLogo();
        ConsoleUI.ZobrazitVysledek(zprava, vyhra);
        ConsoleUI.ZobrazitKonecHry();
    }

    // 0 = nic se nestalo, 1 = protivník se brání, 3 = hráčův cichnamon zemřel
    static int ProtivnikuvTah(Trener protivnik, Cichnamon zvolenyCichnamon, bool hracSeBrani, Random random)
    {
        int volbaAkce = random.Next(1, 4);

        List<Cichnamon> zijiciCichnamoni = protivnik.ZobrazitZijiciCichnamony();
        if (zijiciCichnamoni.Count == 0)
        {
            return 0;
        }

        Cichnamon zvolenyProtivnikuvCichnamon = zijiciCichnamoni[random.Next(zijiciCichnamoni.Count)];
        ConsoleUI.ZobrazitAkci($"Protivník zvolil cichnamona: {zvolenyProtivnikuvCichnamon.Jmeno}");

        switch (volbaAkce)
        {
            case 1:
                if (ProtivnikUtoci(zvolenyProtivnikuvCichnamon, zvolenyCichnamon, hracSeBrani, random))
                {
                    return 3;
                }
                return 0;
            case 2:
                ConsoleUI.ZobrazitAkci("Protivník si zvolil obranu!");
                return 1;
            case 3:
                return ProtivnikUzdravi(protivnik, zvolenyProtivnikuvCichnamon, zvolenyCichnamon, hracSeBrani, random);
            default:
                return 0;
        }
    }

    static bool ProtivnikUtoci(Cichnamon utocnik, Cichnamon obrance, bool hracSeBrani, Random random)
    {
        ConsoleUI.ZobrazitAkci("Protivník si zvolil útok!");
        WriteLine();

        if (hracSeBrani && random.Next(2) == 0)
        {
            ConsoleUI.ZobrazitObranu(obrance.Jmeno);
        }
        else if (random.Next(2) == 0)
        {
            utocnik.ZautocitZakladniUtok(obrance);
        }
        else
        {
            utocnik.ZautocitSpecialniUtok(obrance);
        }

        return obrance.Zdravi <= 0;
    }

    static int ProtivnikUzdravi(Trener protivnik, Cichnamon zvolenyProtivnikuvCichnamon, Cichnamon zvolenyCichnamon, bool hracSeBrani, Random random)
    {
        ConsoleUI.ZobrazitAkci("Protivník si zvolil doplnění zdraví!");

        List<Cichnamon> potrebujiUzdraveni = NajitCichnamonyPotrebujiciUzdraveni(protivnik);

        if (potrebujiUzdraveni.Count == 0)
        {
            if (random.Next(1, 3) == 1)
            {
                if (ProtivnikUtoci(zvolenyProtivnikuvCichnamon, zvolenyCichnamon, hracSeBrani, random))
                {
                    return 3;
                }
                return 0;
            }

            ConsoleUI.ZobrazitAkci("Protivník si zvolil obranu!");
            return 1;
        }

        if (zvolenyProtivnikuvCichnamon.Zdravi >= zvolenyProtivnikuvCichnamon.MaxZdravi)
        {
            zvolenyProtivnikuvCichnamon = potrebujiUzdraveni[random.Next(potrebujiUzdraveni.Count)];
            ConsoleUI.ZobrazitVarovani("Cichnamon již má maximální zdraví!");
            ConsoleUI.ZobrazitAkci($"Protivník zvolil jiného cichnamona: {zvolenyProtivnikuvCichnamon.Jmeno}");
        }

        if (zvolenyProtivnikuvCichnamon.Uzdravit(10))
        {
            ConsoleUI.ZobrazitUzdraveni(zvolenyProtivnikuvCichnamon.Jmeno, 10, false);
        }

        return 0;
    }

    static List<Cichnamon> NajitCichnamonyPotrebujiciUzdraveni(Trener trener)
    {
        List<Cichnamon> potrebujiUzdraveni = new List<Cichnamon>();

        foreach (Cichnamon cichnamon in trener.Cichnamoni)
        {
            if (cichnamon.Zdravi > 0 && cichnamon.Zdravi < cichnamon.MaxZdravi)
            {
                potrebujiUzdraveni.Add(cichnamon);
            }
        }

        return potrebujiUzdraveni;
    }
}
