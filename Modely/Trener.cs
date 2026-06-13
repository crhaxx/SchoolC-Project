class Trener
{
    public string Jmeno { get; set; }
    public List<Cichnamon> Cichnamoni { get; set; }
    public Cichnamon VybranyCichnamon { get; set; }

    public Trener(string jmeno, List<Cichnamon> cichnamoni, Cichnamon vybranyCichnamon)
    {
        Jmeno = jmeno;
        Cichnamoni = cichnamoni;
        VybranyCichnamon = vybranyCichnamon;
    }

    public void VybratCichnamona(Cichnamon cichnamon)
    {
        VybranyCichnamon = cichnamon;
    }

    public Cichnamon? ZiskatAktivnihoCichnamona()
    {
        if (VybranyCichnamon != null && VybranyCichnamon.Zdravi > 0)
        {
            return VybranyCichnamon;
        }

        List<Cichnamon> zijiciCichnamoni = ZobrazitZijiciCichnamony();
        if (zijiciCichnamoni.Count == 0)
        {
            return null;
        }

        VybranyCichnamon = zijiciCichnamoni[0];
        return VybranyCichnamon;
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