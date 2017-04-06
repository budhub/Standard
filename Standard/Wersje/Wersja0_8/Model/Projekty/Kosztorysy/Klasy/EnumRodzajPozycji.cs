using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy
{
    [Description("Rodzaj pozycji kosztorysu")]
    public enum EnumRodzajPozycji
    {
        [Description("Pozycja zawierająca wszystkie dane")]
        PozycjaPelna,

        [Description("Pusta pozycja - np. podczas importu z Excela importuje wiersze z opisem działu lub uwagam." +
                     " Używana w celu zachowania zgodności wierszowej z oryginalnym kosztorysem w Excelu")]
        PustaPozycja
    }
}
