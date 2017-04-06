using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty
{
    [Description("Status projektu")]
    public enum EnumStatusProjektu
    {
        [Description("Sprawdzamy temat, czy nas interesuje, czy podejmujemy się wycen")]
        Rozpoznanie,

        [Description("Ofertujemy, przygotowujemy ofertę")]
        Ofertowanie,

        [Description("Wygraliśmy projekt i go realizujemy")]
        Realizacja,

        [Description("Projekt został zakończony i odebrany, teraz trwa jego okres serwisu gwarancyjnego")]
        SerwisGwarancyjny,

        [Description("Sa problemy z projektem i nie jest rozliczony finansowo")]
        WindykacjaSad,

        [Description("Temat zakończony sukcesem - po upływie gwarancji itp, wszystkie pieniądze rozliczone")]
        Zakonczony
    }
}
