using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zadania
{
    [Description("Stan w którym może znajdować się zadanie")]
    public enum EnumStatusZadania
    {
        [Description("")]
        Nieprzydzielone,

        [Description("Przydziolono użytkownikowi do wykonania")]
        Przydzielone,

        [Description("Użytkownik jest w trakcie wykonywania zadania")]
        Wykonywane,

        [Description("Wykonujący ma pytanie do zlecającego")]
        MamPytanie,

        [Description("Czekam na dane z zewnątrz. np. oferty, telefon itp")]
        CzekamNaDane,

        [Description("Zadanie wykonane, oczekuje na potwierdzenie przez zlecającego")]
        CzekamNaPotwierdzenie,

        [Description("Zadanie wykonane i potwierdzone")]
        Zamkniete,

        [Description("Odłożone na inny termin")]
        Odlozone,

        [Description("Odrzucone")]
        Odrzucone,

        [Description("Anulowane")]
        Anulowane,

        [Description("Zadanie nie priorytetowe, odłożone na kiedyś bez podawania konkretnej daty")]
        MozeKiedys
    }
}
