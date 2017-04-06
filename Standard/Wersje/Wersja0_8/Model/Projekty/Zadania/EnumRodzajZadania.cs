using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zadania
{
    [Description("Zadanie może być różnego rodzaju")]
    public enum EnumRodzajZadania
    {
        [Description("Zwykłe zadanie")]
        Zadanie,
        [Description("Spotkanie, wyświetla się w kalendarzu")]
        Spotkanie,
        [Description("Element harmonogramu wyświetlany w harmonogramach")]
        Harmonogram
    }
}
