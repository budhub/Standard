using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy
{
    [Description("Jednostki")]
    public enum EnumJednostka
    {
        [Description("sztuki")]
        szt,

        [Description("komplet")]
        kpl,

        [Description("układ")]
        ukl,

        [Description("metry")]
        m,

        [Description("metry bieżące")]
        mb,

        [Description("metry kwadratowe")]
        m2,

        [Description("metry sześcienne")]
        m3,

        [Description("kilogramy")]
        kg,

        [Description("tony")]
        t,

        [Description("roboczo godziny")]
        r_g,

        [Description("maszyno godziny")]
        m_g,

        [Description("Inna jednostka - opis polu JednostkaNazwa")]
        inna
    }
}
