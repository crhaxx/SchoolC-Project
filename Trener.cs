using static System.Console;

class Trener
{
    public string Jmeno { get; set; }
    public int Level { get; set; }
    public List<Cichnamon> Cichnamoni { get; set; }
    public Cichnamon VybranyCichnamon { get; set; }

    public Trener(string jmeno, List<Cichnamon> cichnamoni, Cichnamon vybranyCichnamon, int level = 0)
    {
        Jmeno = jmeno;
        Level = level;
        Cichnamoni = cichnamoni;
        VybranyCichnamon = vybranyCichnamon;
    }

    public void ZobrazitCichnamony()
    {
        int i = 0;
        foreach (Cichnamon cichnamon in Cichnamoni)
        {
            WriteLine($"{i + 1} - {cichnamon.Jmeno}, HP: {cichnamon.Zdravi}/{cichnamon.MaxZdravi}");
            i++;
        }
    }

    public List<Cichnamon> ZobrazitZijiciCichnamony()
    {
        List<Cichnamon> zijiciCichnamoni = new List<Cichnamon>();
        foreach (Cichnamon cichnamon in Cichnamoni)
        {
            if (cichnamon.Zdravi > 0)
            {
                zijiciCichnamoni.Add(cichnamon);
            }
        }
        return zijiciCichnamoni;
    }
}