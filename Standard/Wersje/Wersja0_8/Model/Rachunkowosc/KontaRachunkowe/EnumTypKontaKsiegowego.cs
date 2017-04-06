using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.KontaRachunkowe
{
    [Description("Typ konta księgowego")]
    public enum EnumTypKontaKsiegowego
    {
        [Description("Konto syntetyczne to główne konto w bilansie")]
        Syntetyczne,

        [Description("Konto analityczne to pod konto konta syntetycznego")]
        Analityczne,
        Dzial
    }
}
