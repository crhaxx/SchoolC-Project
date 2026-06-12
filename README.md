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


| Soubor         | Popis                                  |
| -------------- | -------------------------------------- |
| `Program.cs`   | Hlavní logika hry a menu               |
| `Cichnamon.cs` | Třída Čichnamona (zdraví, útoky)       |
| `Trener.cs`    | Třída trenéra a jeho tým Čichnamonů    |
| `Utok.cs`      | Základní a speciální útoky             |
| `ConsoleUI.cs` | Vzhled a výstup v konzoli              |
| `Nastaveni.cs` | Výchozí data hry (Čichnamoni, trenéři) |


## Hraní

Po spuštění programu se zobrazí hlavní menu:

1. **Spustit hru** — výběr trenéra a souboj proti počítači
2. **Zobrazit Čichnamony** — přehled dostupných postav
3. **Zobrazit Trenéry** — seznam trenérů
4. **Ukončit program**

Ve hře volíte akci (útok, obrana, doplnění zdraví), vybíráte Čichnamona a střídáte se s protivníkem, dokud jeden z týmů neprohraje.

## Autor

Nikola Crhák — Střední škola Čichnova, 2. ročník.