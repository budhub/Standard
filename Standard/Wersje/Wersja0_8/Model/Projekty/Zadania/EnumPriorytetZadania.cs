using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zadania
{
    [Description("Priorytet zadania")]
    public enum EnumPriorytetZadania
    {
        [Description("Wykonać w wolnym czasie")]
        Niski,
        [Description("Należy wykonać w najbliższym czasie")]
        Normalny,

        [Description("Bardzo ważne zadanie, które trzeba szybko wykonać")]
        Wysoki,

        [Description("Krytyczne zadanie - należy odłożyć inne czynności i wykonać to zadanie. Bloker oznacza, że blokuje innych pracowników")]
        Bloker
    }
}
