# Čichnamon Arena

Závěrečný projekt ukončující **2. ročník** studia na **Střední škole Čichnova**.

## O projektu

Jedná se o konzolovou hru **Čichnamon Arena**, v níž proti sobě bojují dvě malá stvoření zvaná **Čichnamoni**. Hráč si vybere svého Čichnamona, počítač dostane vlastního protivníka a následuje souboj v příkazové řádce.

Projekt je napsán v jazyce **C#** (.NET 10). Termín zpracování zadání byl **jeden měsíc**.

Při vývoji byl jako poradce a designer vzhledu využit editor **[Cursor](https://cursor.com/get-started)**.

## Zadání

> Vaším úkolem je vytvořit jednoduchou konzolovou hru Čichnamon Arena. Ve hře proti sobě bojují dvě malá stvoření zvaná Čichnamoni. Každý Čichnamon má jméno, zdraví, základní útok a speciální útok. *(Poznámka pro právníky a budoucí právníky: jakákoliv podobnost s jinými hrami o kapesních příšerkách je čistě náhodná.)* Hráč si vybere svého Čichnamona, počítač dostane vlastního Čichnamona a poté začne souboj.

## Požadavky

- [Git](https://git-scm.com/install/) — ke stažení projektu z repozitáře
- [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download) nebo novější — ke spuštění programu
- Terminál (Linux, macOS nebo Windows)

Ověření instalace:

```bash
git --version
dotnet --version
```

Měla by se zobrazit verze **10.0** nebo vyšší u .NET SDK.

## Spuštění programu

### 1. Stažení projektu

```bash
git clone https://github.com/crhaxx/SchoolC-Project.git
cd SchoolC-Project
```

### 2. Sestavení a spuštění

```bash
dotnet run
```

Alternativně lze nejdříve projekt sestavit a spustit zkompilovaný soubor:

```bash
dotnet build
dotnet bin/Debug/net10.0/Project
```

Na Windows spusťte místo toho soubor `Project.exe` ve stejné složce.

## Struktura projektu

```
SchoolC-Project/
├── Program.cs              # Hlavní logika hry a menu
├── Modely/
│   ├── Cichnamon.cs        # Třída Čichnamona (zdraví, útoky)
│   ├── Trener.cs           # Třída trenéra a jeho tým Čichnamonů
│   └── Utok.cs             # Základní a speciální útoky
├── Nastaveni/
│   └── Nastaveni.cs        # Výchozí data hry (Čichnamoni, trenéři)
└── UI/
    └── ConsoleUI.cs        # Vzhled a výstup v konzoli
```


## Hraní

Po spuštění programu se zobrazí hlavní menu:

1. **Spustit hru** — výběr trenéra a souboj proti počítači
2. **Zobrazit Čichnamony** — přehled dostupných postav, jejich HP a útoků
3. **Zobrazit Trenéry** — seznam trenérů a jejich týmů
4. **Ukončit program**

### Zahájení souboju

1. Vyber si **trenéra** (každý má 2 Čichnamony).
2. Počítač náhodně vybere **protivníka** (jiného trenéra).
3. Každá nová hra začíná s **plným HP** — data se resetují.

### Bojový přehled

V každém kole vidíš stav obou týmů včetně HP barů. Čichnamon na hřišti je označený **★** — jde o **aktivního** bojovníka daného trenéra.

### Průběh kola

Každé kolo probíhá v tomto pořadí:

1. **Tvoje volba** — zvolíš akci a (u útoku/obrany) Čichnamona
2. **Tah protivníka** — počítač náhodně útočí, brání se nebo se léčí
3. **Váš útok** — proběhne jen tehdy, pokud jsi v kroku 1 zvolil útok

### Tvoje akce

| Akce | Co dělá |
|------|---------|
| **1 – Útok** | Vybereš živého Čichnamona. Hra náhodně zvolí základní nebo speciální útok a útočí na **aktivního** protivníkova Čichnamona. |
| **2 – Obrana** | Vybereš Čichnamona, který se brání. Neútočíš. Pokud na tebe protivník v tomto kole zaútočí, je **50% šance**, že se ubráníš. |
| **3 – Doplnění zdraví** | Vyléčíš vybraného Čichnamona o **+10 HP** (max. do jeho maxima). Zadáním **0** akci zrušíš. Aktivní Čichnamon se nemění. |

Mrtvého Čichnamona (☠) nelze vybrat k útoku, obraně ani léčení.

### Tah protivníka

Počítač v každém kole náhodně:

1. Vybere **živého** Čichnamona ze svého týmu
2. Náhodně zvolí akci:

| Akce protivníka | Efekt |
|-----------------|-------|
| **Útok** | Náhodný základní nebo speciální útok na tvého **aktivního** Čichnamona. Respektuje tvou obranu (50% šance na blok). |
| **Obrana** | Protivník se brání. Pokud v tomto kole útočíš, je **50% šance**, že tvůj útok zablokuje. |
| **Léčení** | Protivník si doplní **+10 HP**. Pokud nikdo nepotřebuje léčit, zvolí místo toho jinou akci. |

### Obrana

- Obrana platí **jen ve stejném kole** — ne přenáší se do dalšího kola.
- Při úspěchu: `🛡 … se úspěšně ubránil!`
- Při neúspěchu: `✗ … se neubránil!` a útok proběhne

### Poškození a léčení

- Každý útok ubírá HP podle síly daného úderu.
- HP klesne na minimum **0** — Čichnamon je poražen, ale tým může bojovat dál, dokud má dalšího živého bojovníka.
- Léčení nefunguje na Čichnamona s plným HP.

### Konec hry

- **Výhra** — porazíš všechny protivníkovy Čichnamony
- **Prohra** — všechny tvoje Čichnamony mají 0 HP

Po skončení hry se vrátíš do hlavního menu.

## Autor

Nikola Crhák — Střední škola Čichnova, 2. ročník.