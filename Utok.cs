class Utok
{
    string Nazev { get; set; }
    int PoskozeniUtoku { get; set; }
    string PopisUtoku { get; set; }

    public Utok(string nazev, int poskozeniUtoku, string popisUtoku)
    {
        Nazev = nazev;
        PoskozeniUtoku = poskozeniUtoku;
        PopisUtoku = popisUtoku;
    }

    void VypisInfo()
    {
        Console.WriteLine(PopisUtoku);
    }

    void VypisHodnotyPoskozeni()
    {
        Console.WriteLine(PoskozeniUtoku);
    }
}