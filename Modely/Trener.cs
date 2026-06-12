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
        ConsoleUI.ZobrazitCichnamonSeznam(Cichnamoni);
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

    public int VratitZivotnostCichnamona()
    {
        int zivotnost = 0;
        int maxZivotnost = 0;
        foreach (Cichnamon cichnamon in Cichnamoni)
        {
            zivotnost += cichnamon.Zdravi;
            maxZivotnost += cichnamon.MaxZdravi;
        }

        int zivotnostCichnamona = (int)Math.Round((double)zivotnost / maxZivotnost * 100);
        return zivotnostCichnamona;
    }
}