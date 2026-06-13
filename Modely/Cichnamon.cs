class Cichnamon
{
    public string Jmeno { get; set; }
    public int Zdravi { get; set; }
    public int MaxZdravi { get; set; }
    public Utok ZakladniUtok { get; set; }
    public Utok SpecialniUtok { get; set; }


    public Cichnamon(string jmeno, int zdravi, int maxZdravi, Utok zakladniUtok, Utok specialniUtok)
    {
        Jmeno = jmeno;
        Zdravi = zdravi;
        MaxZdravi = maxZdravi;
        ZakladniUtok = zakladniUtok;
        SpecialniUtok = specialniUtok;
    }

    public void ZautocitZakladniUtok(Cichnamon protivnikuvCichnamon)
    {
        int poskozeni = ZakladniUtok.PoskozeniUtoku;
        protivnikuvCichnamon.SnizitZdravi(poskozeni);
        ConsoleUI.ZobrazitUtok(Jmeno, ZakladniUtok, protivnikuvCichnamon.Jmeno, poskozeni);
    }

    public void ZautocitSpecialniUtok(Cichnamon protivnikuvCichnamon)
    {
        int poskozeni = SpecialniUtok.PoskozeniUtoku;
        protivnikuvCichnamon.SnizitZdravi(poskozeni);
        ConsoleUI.ZobrazitUtok(Jmeno, SpecialniUtok, protivnikuvCichnamon.Jmeno, poskozeni);
    }

    public void SnizitZdravi(int hodnota)
    {
        Zdravi -= hodnota;
        if (Zdravi < 0)
        {
            Zdravi = 0;
        }
    }

    public bool Uzdravit(int hodnota)
    {
        if (Zdravi >= MaxZdravi)
        {
            return false;
        }
        

        Zdravi += hodnota;

        if (Zdravi > MaxZdravi)
        {
            Zdravi = MaxZdravi;
        }

        return true;
    }
}