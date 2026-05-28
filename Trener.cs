class Trener
{
    string Jmeno { get; set; }
    int Level { get; set; }
    List<Cichnamon> Cichnamoni { get; set; }
    Cichnamon VybranyCichnamon { get; set; }

    public Trener(string jmeno, List<Cichnamon> cichnamoni, Cichnamon vybranyCichnamon, int level = 0)
    {
        Jmeno = jmeno;
        Level = level;
        Cichnamoni = cichnamoni;
        VybranyCichnamon = vybranyCichnamon;
    }
}