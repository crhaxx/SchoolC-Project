using static System.Console;

class Projekt
{
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
                    WriteLine();
                    WriteLine("Hra spuštěna!");
                    WriteLine();
                    WriteLine();

                    Trener zvolenyTrener;

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
                        zvolenyTrener = nastaveni.Treners[volbaTrenera];
                        WriteLine($"Zvolil jste trenéra: {zvolenyTrener.Jmeno}");
                    }
                    else
                    {
                        WriteLine("Neplatná volba trenéra.");
                    }

                    WriteLine();

                    Random random = new Random();
                    int indexProtihrace = random.Next(nastaveni.Treners.Count);
                    WriteLine($"Protivník si zvolil trenéra: {nastaveni.Treners[indexProtihrace].Jmeno}");
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