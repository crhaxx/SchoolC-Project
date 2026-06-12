class Utok
{
    public string Nazev { get; set; }
    public int PoskozeniUtoku { get; set; }
    public string PopisUtoku { get; set; }

    public Utok(string nazev, int poskozeniUtoku, string popisUtoku)
    {
        Nazev = nazev;
        PoskozeniUtoku = poskozeniUtoku;
        PopisUtoku = popisUtoku;
    }

    public void VypisInfo()
    {
        Console.WriteLine(PopisUtoku);
    }

    public void VypisHodnotyPoskozeni()
    {
        Console.WriteLine(PoskozeniUtoku);
    }
}