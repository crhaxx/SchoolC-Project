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
}