using System;
using System.Collections.Generic;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zamowienia.Klasy;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zamowienia
{
    public class Zamowienie : ObiektBiznesowyBazowy
    {
        #region Podstawowe

        [Description("Numer liniowy zamówienia")]
        [GridView(FilterFunction = GridKnownFunction.EqualTo,Label = "Numer", Width = "20px")]
        [DataFormView]
        public int NumerLiniowyZamowienia { get; set; }
        
        [Description("Nazwa zamówienia")]
        
        [DataFormView]
        public string Nazwa { get; set; }

        [Description("Opis zamówienia")]
        [GridView( Width = "50%")]
        [DataFormView]
        public string Tresc { get; set; }

        
        [Description("Status zamówienia")]
        [GridView(ColumnType = GridColumnType.EnumColumn,
            ColumnDataType = typeof(EnumStatusZamowienia), Label = "Status")]
        [DataFormView]
        public EnumStatusZamowienia StatusZamowienia { get; set; }

        [Description("Data zamówienia")]
        [GridView(Label ="Data zam.")]
        [DataFormView]
        public DateTime? DataZamowienia { get; set; }

        [Description("Przewidywana data dostawy")]
        [GridView(Label = "Data dost.")]
        [DataFormView]
        public DateTime? DataDostawy { get; set; }

        [Description("Pozycje zamówienia - bez podziałów na działy")]
        public IList<PozycjaZamowienia> Pozycje { get; set; }

        [Description("Nazwa projektu/budowy")]
        public string NazwaProjektu { get; set; }

        public Guid? KosztorysId { get; set; }

        public Kosztorys Kosztorys { get; set; }

        
        [DataFormView]
        public string KosztorysNazwa { get; set; }

        [Description("Szacowana kwota netto zamówienia")]
        [GridView(Label = "Szacowana wartość netto")]
        public decimal SzacowanaKwotaNettoZamowienia { get; set; }

        public string MaileId { get; set; }
        public string MaileNazwy { get; set; }

        #endregion

        #region Projekt
        public Guid? ProjektId { get; set; }

        public Kosztorys Projekt { get; set; }

        [GridView(Label = "Projekt")]
        [DataFormView]
        public string ProjektNazwa { get; set; }

        #endregion

        public override string ToString()
        {
            return NumerLiniowyZamowienia.ToString();
        }

        #region Mapowanie 
        public static MappingConfiguration<Zamowienie> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<Zamowienie>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
            customerMapping.HasProperty(x => x.Tresc).WithInfiniteLength();

            customerMapping.HasAssociation(u => u.Kosztorys)
                .WithOpposite(p => p.Zamowienia)
                .HasConstraint((u, p) => u.KosztorysId == p.Id);

            customerMapping.HasAssociation(u => u.Projekt)
                .WithOpposite(p => p.Zamowienia)
                .HasConstraint((u, p) => u.ProjektId == p.Id);

            return customerMapping;
        }
        
        #endregion
    }
}
