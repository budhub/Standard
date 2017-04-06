using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy
{
    [Description("Opisuje sposób wyliczania ilości pozycji kosztorysu. "
        +"W zależności od trybu pole Ilosc pozycji kosztorysowej przyjmuje różne wartości")]
    public enum EnumTrybIlosciPozycji
    {
        [Description("Ilość z przedmiaru")]
        Przedmiar,
        [Description("Ilość z obmiaru - zliczona z dokumentacji lub z obmiaru")]
        Obmiar,
    }
}
