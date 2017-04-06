using System;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zamowienia
{
    public class PozycjaZamowienia : ObiektBiznesowyBazowy
    {
        #region Podstawowe              

        [Description("Id zamówienia")]
        public Guid? ZamowienieId { get; set; }

        [Description("Zamówienie do którego należy pozycja")]
        public Zamowienie Zamowienie { get; set; }
        
        [Description("Kod pozycji")]
        public string Kod { get; set; }

        [Description("Opis pozycji")]
        public string Opis { get; set; }

        [Description("Preferowany producent")]
        public string Producent { get; set; }

        [Description("Jednostka")]
        public EnumJednostka Jednostka { get; set; }

        [Description("Jednostka zapisana słownie")]
        public string JednostkaNazwa { get; set; }

        [Description("Ilość zamówiona")]
        public decimal Ilosc { get; set; }

        [Description("Cena jednostkow buudżetowa - widoczne tylko wewnętrznie")]
        
        [DataFormView]
        public decimal CenaJednostkowaMaterialuBudzet { get; set; }

        [Description("Wartość Budżet  materiału - widoczne tylko wewnętrznie")]
        [GridView(Aggregate = GridAggregateFunction.Sum)]
        public decimal WartoscMaterialuBudzet => Ilosc * CenaJednostkowaMaterialuBudzet;

        #region Kosztorysy

        [Description("Id pozycji kosztorysu, której tyczy się dane zamówienie")]
        public Guid? PozycjaKosztorysuId { get; set; }

        [Description("Zamówienie do którego należy pozycja")]
        public PozycjaKosztorysu PozycjaKosztorysu { get; set; }
        public int NumerLiniowy { get; set; }
        public string Uwagi { get; set; }

        #endregion

        #endregion

        public override string ToString()
        {
            return Opis ?? base.ToString();
        }

        #region Mapowanie 
        public static MappingConfiguration<PozycjaZamowienia> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<PozycjaZamowienia>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(u => u.WartoscMaterialuBudzet).AsTransient();

            customerMapping.HasAssociation(u => u.PozycjaKosztorysu)
                .WithOpposite(p => p.PozycjeZamowienia)
                .HasConstraint((u, p) => u.PozycjaKosztorysuId == p.Id);

            customerMapping.HasAssociation(u => u.Zamowienie)
                .WithOpposite(p => p.Pozycje)
                .HasConstraint((u, p) => u.ZamowienieId == p.Id);

            return customerMapping;
        }
        #endregion
    }
}
