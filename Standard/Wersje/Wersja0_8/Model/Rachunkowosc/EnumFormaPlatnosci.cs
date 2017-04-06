using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc
{
    public enum EnumFormaPlatnosci
    {
        [Description("Płatność gotówką")]
        Gotowka,
        [Description("Płatność przelewem")]
        Przelew
    }
}
