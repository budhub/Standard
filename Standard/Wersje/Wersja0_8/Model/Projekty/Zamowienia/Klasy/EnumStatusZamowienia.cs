using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zamowienia.Klasy
{
    [Description("Stany w jakich może znajdować się zamówienie")]
    public enum EnumStatusZamowienia
    {
        [Description("Początkowy stan - zamówienie jest przygotowywane - tworzone")]
        Roboczy,

        [Description("Wysyłamy zapytania ofertowe")]
        Ofertowanie,

        [Description("Zamówienie anulowano")]
        Anulowany,

        [Description("Zamówienie jest realizowane - zostało wysłane zamówienie i czekamy na materiał")]
        Zamowiony,

        [Description("Jest problem z zamówieniem")]
        Reklamacja,

        [Description("Zamówienie jest wykonane - zrealizowane")]
        Wykonany        
    }
}
