class Cichnamon
{
    public string Jmeno { get; set; }
    public int Zdravi { get; set; }
    public int MaxZdravi { get; set; }
    public int BonusSilaUtoku { get; set; }
    public Utok ZakladniUtok { get; set; }
    public Utok SpecialniUtok { get; set; }


    public Cichnamon(string jmeno, int zdravi, int maxZdravi, int bonusSilaUtoku, Utok zakladniUtok, Utok specialniUtok)
    {
        Jmeno = jmeno;
        Zdravi = zdravi;
        MaxZdravi = maxZdravi;
        BonusSilaUtoku = bonusSilaUtoku;
        ZakladniUtok = zakladniUtok;
        SpecialniUtok = specialniUtok;
    }

    public void ZautocitZakladniUtok(Cichnamon protivnikuvCichnamon)
    {
        protivnikuvCichnamon.SnizitZdravi(ZakladniUtok.PoskozeniUtoku);
    }

    public void ZautocitSpecialniUtok(Cichnamon protivnikuvCichnamon)
    {
        protivnikuvCichnamon.SnizitZdravi(SpecialniUtok.PoskozeniUtoku);
    }

    public void SnizitZdravi(int hodnota)
    {
        Zdravi -= hodnota;
        if (Zdravi < 0)
        {
            Zdravi = 0;
        }
    }

    public void Uzdravit(int hodnota)
    {
        Zdravi += hodnota;
        if (Zdravi > MaxZdravi)
        {
            Zdravi = MaxZdravi;
        }
    }
}