using System;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.ZapytaniaOfertowe
{
    public class PozycjaZapytaniaOfertowego : ObiektBiznesowyBazowy
    {
        public int NumerLiniowy { get; set; }

        [Description("Opis pozycji")]
        
        [DataFormView]
        public string Nazwa { get; set; }

        [Description("Uwagi do pozycji")]
        
        [DataFormView]
        public string Uwagi { get; set; }

        [Description("Preferowany producent")]
        
        [DataFormView]
        public string Producent { get; set; }

        [Description("Jednostka")]
        
        [DataFormView]
        public EnumJednostka Jednostka { get; set; }

        [Description("Ilość zamówiona")]
        
        [DataFormView]
        public decimal Ilosc { get; set; }

        [Description("Cena jednostkow buudżetowa - widoczne tylko wewnętrznie")]
        
        [DataFormView]
        public decimal CenaJednostkowaMaterialuBudzet { get; set; }

        [Description("Wartość Budżet  materiału - widoczne tylko wewnętrznie")]
        [GridView(Aggregate = GridAggregateFunction.Sum)]
        public decimal WartoscMaterialuBudzet => Ilosc*CenaJednostkowaMaterialuBudzet;

        [Description("Id zapytania ofertowego")]
        [DataFormView(RepositoryType = typeof(ZapytanieOfertowe))]
        public Guid? ZapytanieOfertoweId { get; set; }
        
        public ZapytanieOfertowe ZapytanieOfertowe { get; set; }

        public Guid? PozycjaKosztorysuId { get; set; }
        public PozycjaKosztorysu PozycjaKosztorysu { get; set; }

        [Description("Kod pozycji")]
        
        [DataFormView]
        public string Kod { get; internal set; }

        #region Mapowanie 
        public static MappingConfiguration<PozycjaZapytaniaOfertowego> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<PozycjaZapytaniaOfertowego>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).WithInfiniteLength();
            customerMapping.HasProperty(x => x.WartoscMaterialuBudzet).AsTransient();

            customerMapping.HasAssociation(u => u.ZapytanieOfertowe)
                .WithOpposite(p => p.PozycjeZapytaniaOfertowego)
                .HasConstraint((u, p) => u.ZapytanieOfertoweId == p.Id);

            customerMapping.HasAssociation(u => u.PozycjaKosztorysu)
                .WithOpposite(p => p.PozycjeZapytaniaOfertowego)
                .HasConstraint((u, p) => u.PozycjaKosztorysuId == p.Id);

            return customerMapping;
        }

        #endregion
    }
}
