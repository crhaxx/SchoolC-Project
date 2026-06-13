using static System.Console;

static class ConsoleUI
{
    const int Sirka = 52;
    const int VnitrniSirkaTabulky = 46;

    public static void ZobrazitLogo()
    {
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine();
        WriteLine("  ╔════════════════════════════════════════════╗");
        WriteLine("  ║                                            ║");
        WriteLine("  ║        ⚔  CICHNAMON BATTLE ARENA  ⚔        ║");
        WriteLine("  ║                                            ║");
        WriteLine("  ╚════════════════════════════════════════════╝");
        ResetColor();
        WriteLine();
    }

    public static void ZobrazitNadpis(string text, ConsoleColor barva = ConsoleColor.Yellow)
    {
        string obsah = $" {text} ";
        int padding = Math.Max(0, Sirka - obsah.Length - 2);
        int leva = padding / 2;
        int prava = padding - leva;

        ForegroundColor = barva;
        Write("  ╔");
        Write(new string('═', Sirka - 2));
        WriteLine("╗");

        Write("  ║");
        Write(new string(' ', leva));
        Write(obsah);
        Write(new string(' ', prava));
        WriteLine("║");

        Write("  ╚");
        Write(new string('═', Sirka - 2));
        WriteLine("╝");
        ResetColor();
        WriteLine();
    }

    public static void ZobrazitMenu(string nadpis, IEnumerable<string> polozky)
    {
        ZobrazitNadpis(nadpis, ConsoleColor.Magenta);

        ForegroundColor = ConsoleColor.White;
        WriteLine("  ┌────────────────────────────────────────────┐");
        foreach (string polozka in polozky)
        {
            Write("  │  ");
            Write(polozka.PadRight(40));
            WriteLine("  │");
        }
        WriteLine("  └────────────────────────────────────────────┘");
        ResetColor();
        WriteLine();
    }

    public static void ZobrazitOddelovac()
    {
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine($"  {new string('─', Sirka - 4)}");
        ResetColor();
    }

    public static void ZobrazitInfo(string text)
    {
        ForegroundColor = ConsoleColor.Gray;
        WriteLine($"  ℹ  {text}");
        ResetColor();
    }

    public static void ZobrazitUspech(string text)
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"  ✓  {text}");
        ResetColor();
    }

    public static void ZobrazitVarovani(string text)
    {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"  ⚠  {text}");
        ResetColor();
    }

    public static void ZobrazitChybu(string text)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"  ✗  {text}");
        ResetColor();
    }

    public static void ZobrazitAkci(string text)
    {
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine($"  »  {text}");
        ResetColor();
    }

    public static void ZobrazitVysledek(string text, bool vyhra)
    {
        WriteLine();
        ForegroundColor = vyhra ? ConsoleColor.Green : ConsoleColor.Red;
        string symbol = vyhra ? "★" : "☠";
        WriteLine($"  {symbol}  {text}  {symbol}");
        ResetColor();
        WriteLine();
    }

    public static void ZobrazitKonecHry()
    {
        ZobrazitOddelovac();
        ForegroundColor = ConsoleColor.DarkCyan;
        WriteLine("  Hra ukončena. Stiskněte Enter pro návrat do menu...");
        ResetColor();
        ReadLine();
    }

    public static void ZobrazitPokracovat()
    {
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine();
        Write("  Stiskněte Enter pro pokračování...");
        ResetColor();
        ReadLine();
    }

    public static string VytvoritHPBar(int aktualni, int max, int delka = 16)
    {
        if (max <= 0)
        {
            return new string('░', delka);
        }

        int plne = (int)Math.Round((double)aktualni / max * delka);
        plne = Math.Clamp(plne, 0, delka);
        return new string('█', plne) + new string('░', delka - plne);
    }

    public static ConsoleColor BarvaHP(int aktualni, int max)
    {
        if (max <= 0)
        {
            return ConsoleColor.DarkGray;
        }

        double procento = (double)aktualni / max * 100;
        if (procento > 50)
        {
            return ConsoleColor.Green;
        }

        if (procento > 25)
        {
            return ConsoleColor.Yellow;
        }

        return ConsoleColor.Red;
    }

    public static void ZobrazitHP(string jmeno, int aktualni, int max, bool jeMrtvy = false)
    {
        if (jeMrtvy)
        {
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine($"     {jmeno,-12} ☠ Mrtvý");
            ResetColor();
            return;
        }

        Write($"     {jmeno,-12} ");
        ForegroundColor = BarvaHP(aktualni, max);
        Write(VytvoritHPBar(aktualni, max));
        ResetColor();
        WriteLine($" {aktualni,3}/{max,-3}");
    }

    public static void ZobrazitTym(string nadpis, Trener trener, ConsoleColor barvaNadpisu)
    {
        ForegroundColor = barvaNadpisu;
        WriteLine($"  {nadpis}: {trener.Jmeno}  (celkové HP: {trener.VratitZivotnostCichnamona()} %)");
        ResetColor();

        foreach (Cichnamon cichnamon in trener.Cichnamoni)
        {
            bool jeAktivni = trener.VybranyCichnamon == cichnamon && cichnamon.Zdravi > 0;
            string jmeno = jeAktivni ? $"{cichnamon.Jmeno} ★" : cichnamon.Jmeno;
            ZobrazitHP(jmeno, cichnamon.Zdravi, cichnamon.MaxZdravi, cichnamon.Zdravi <= 0);
        }
    }

    public static void ZobrazitBojovyPrehled(Trener hrac, Trener protivnik)
    {
        ZobrazitNadpis("STAV BOJE", ConsoleColor.Red);
        ZobrazitTym("Vy", hrac, ConsoleColor.Green);
        WriteLine();
        ZobrazitTym("Protivník", protivnik, ConsoleColor.Red);
        ZobrazitOddelovac();
        WriteLine();
    }

    public static void ZobrazitUtok(string utocnik, Utok utok, string obrance, int poskozeni)
    {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"  ⚡ {utocnik} použil {utok.Nazev} (ubral {poskozeni} HP) proti {obrance}!");
        ResetColor();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"     \"{utok.PopisUtoku}\"");
        ResetColor();
    }

    public static void ZobrazitObranu(string jmeno, bool jeProtivnik = false)
    {
        ForegroundColor = ConsoleColor.Blue;
        string text = jeProtivnik
            ? $"Protivník ({jmeno}) se úspěšně ubránil!"
            : $"{jmeno} se úspěšně ubránil!";
        WriteLine($"  🛡  {text}");
        ResetColor();
    }

    public static void ZobrazitNeuspesnouObranu(string jmeno, bool jeProtivnik = false)
    {
        ForegroundColor = ConsoleColor.DarkYellow;
        string text = jeProtivnik
            ? $"Protivník ({jmeno}) se neubránil!"
            : $"{jmeno} se neubránil!";
        WriteLine($"  ✗  {text}");
        ResetColor();
    }

    public static void ZobrazitUzdraveni(string jmeno, int hodnota, bool hrac)
    {
        string kdo = hrac ? "Uzdravil jste" : "Protivník uzdravil";
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"  ♥  {kdo} {jmeno} o {hodnota} HP!");
        ResetColor();
    }

    static string VytvoritHorniOkrajTabulky()
    {
        return "  ┌" + new string('─', VnitrniSirkaTabulky + 4) + "┐";
    }

    static string VytvoritSpodniOkrajTabulky()
    {
        return "  └" + new string('─', VnitrniSirkaTabulky + 4) + "┘";
    }

    static void ZobrazitPrazdnyRadekTabulky()
    {
        ForegroundColor = ConsoleColor.White;
        WriteLine($"  │  {new string(' ', VnitrniSirkaTabulky)}  │");
    }

    static void ZobrazitRadekTabulky(string obsah)
    {
        ForegroundColor = ConsoleColor.White;
        WriteLine($"  │  {obsah.PadRight(VnitrniSirkaTabulky)}  │");
    }

    static void ZobrazitRadekHP(string jmeno, int zdravi, int maxZdravi, string prefix = "", int delkaBaru = 12)
    {
        string hpText = $" {zdravi,3}/{maxZdravi,-3}";
        int delkaObsahu = prefix.Length + 12 + 1 + delkaBaru + hpText.Length;
        int padding = VnitrniSirkaTabulky - delkaObsahu;

        Write("  │  ");
        ForegroundColor = ConsoleColor.White;
        if (prefix.Length > 0)
        {
            Write(prefix);
        }

        Write($"{jmeno,-12} ");
        ForegroundColor = BarvaHP(zdravi, maxZdravi);
        Write(VytvoritHPBar(zdravi, maxZdravi, delkaBaru));
        ResetColor();
        ForegroundColor = ConsoleColor.White;
        Write(hpText);
        Write(new string(' ', Math.Max(0, padding)));
        WriteLine("  │");
    }

    static string VytvoritTextUtoku(Cichnamon cichnamon)
    {
        return $"    Útoky: {cichnamon.ZakladniUtok.Nazev} ({cichnamon.ZakladniUtok.PoskozeniUtoku}), {cichnamon.SpecialniUtok.Nazev} ({cichnamon.SpecialniUtok.PoskozeniUtoku})";
    }

    public static void ZobrazitCichnamonSeznam(IEnumerable<Cichnamon> cichnamoni)
    {
        ForegroundColor = ConsoleColor.White;
        WriteLine(VytvoritHorniOkrajTabulky());

        int i = 1;
        bool prvni = true;
        foreach (Cichnamon cichnamon in cichnamoni)
        {
            if (!prvni)
            {
                ZobrazitPrazdnyRadekTabulky();
            }

            prvni = false;
            string prefix = $"{i,2}. ";

            if (cichnamon.Zdravi <= 0)
            {
                ZobrazitRadekTabulky($"{prefix}{cichnamon.Jmeno,-12} ☠ Mrtvý");
            }
            else
            {
                ZobrazitRadekHP(cichnamon.Jmeno, cichnamon.Zdravi, cichnamon.MaxZdravi, prefix);
            }

            i++;
        }

        ResetColor();
        WriteLine(VytvoritSpodniOkrajTabulky());
        ResetColor();
    }

    public static void ZobrazitTrenery()
    {
        List<Trener> treneri = Nastaveni.Treners;
        ZobrazitNadpis("DOSTUPNÍ TRENÉŘI", ConsoleColor.Cyan);

        ForegroundColor = ConsoleColor.White;
        WriteLine("  ┌────────────────────────────────────────────┐");

        int i = 1;
        foreach (Trener trener in treneri)
        {
            WriteLine($"  │  {i,2}. {trener.Jmeno,-38}  │");
            WriteLine($"  │      Cichnamoni: {string.Join(", ", trener.Cichnamoni.Select(c => c.Jmeno)),-24}  │");
            i++;
        }

        WriteLine("  └────────────────────────────────────────────┘");
        ResetColor();
        WriteLine();
    }

    public static void ZobrazitVsechnyCichnamony()
    {
        List<Cichnamon> cichnamoni = Nastaveni.Cichnamons;
        ZobrazitNadpis("DOSTUPNÍ CICHNAMONI", ConsoleColor.Cyan);

        ForegroundColor = ConsoleColor.White;
        WriteLine(VytvoritHorniOkrajTabulky());

        bool prvni = true;
        foreach (Cichnamon cichnamon in cichnamoni)
        {
            if (!prvni)
            {
                ZobrazitPrazdnyRadekTabulky();
            }

            prvni = false;
            ZobrazitRadekHP(cichnamon.Jmeno, cichnamon.Zdravi, cichnamon.MaxZdravi);
            ZobrazitRadekTabulky(VytvoritTextUtoku(cichnamon));
        }

        WriteLine(VytvoritSpodniOkrajTabulky());
        ResetColor();
        WriteLine();
    }

    public static int CtiVolbu(string vyzva)
    {
        while (true)
        {
            ForegroundColor = ConsoleColor.White;
            Write($"  {vyzva}");
            ResetColor();

            string? vstup = ReadLine();
            if (int.TryParse(vstup, out int volba))
            {
                return volba;
            }

            ZobrazitChybu("Zadejte platné celé číslo.");
        }
    }
}
