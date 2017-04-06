using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.KontaRachunkowe
{
    [Description("Rodzaj konta księgowego")]
    public enum EnumRodzajKontaKsiegowego
    {
        [Description("W języku księgowym, zasoby majątkowe nazywane są aktywami. Dokładnie definiuje się je jako zasoby o wiarygodnie określonej wartości, powstałe w wyniku przeszłych zdarzeń i mające spowodować w przyszłości wpływ do jednostki korzyści ekonomicznych")]
        Aktywa,

        [Description("Źródła finansowania w języku księgowym nazywane są pasywami. Ich podstawowy podział to podział na własne źródła finansowania - kapitał własny oraz obce źródła finansowania - zobowiązania (kapitał obcy).")]
        Pasywa
    }
}
