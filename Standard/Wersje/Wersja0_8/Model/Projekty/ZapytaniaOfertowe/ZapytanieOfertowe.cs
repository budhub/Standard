using System;
using System.Collections.Generic;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.ZapytaniaOfertowe.Klasy;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.ZapytaniaOfertowe
{
    public class ZapytanieOfertowe : ObiektBiznesowyBazowy
    {
        #region Podstawowe

        [Description("Numer zapytania")]
        [GridView(FilterFunction = GridKnownFunction.EqualTo, Label = "Numer", Width = "20px")]
        [DataFormView]
        public int NumerLiniowyZapytania { get; set; }

        [Description("Nazwa zamówienia/ temat")]
        
        [DataFormView]
        public string Nazwa { get; set; }

        [Description("Opis zamówienia")]
        [GridView(Width = "50%")]
        [DataFormView]
        public string Tresc { get; set; }

        public string MaileId { get; set; }
        public string MaileNazwy { get; set; }

        [Description("Status zamówienia")]
        [GridView(ColumnType = GridColumnType.EnumColumn,
            ColumnDataType = typeof(EnumStatusZapytaniaOfertowego), Label = "Status")]
        [DataFormView]
        public EnumStatusZapytaniaOfertowego StatusZapytania { get; set; }

        [Description("Status zamówienia")]
        
        public DateTime? DataZapytania { get; set; }

        #region Kosztorys
        public Guid? KosztorysId { get; set; }

        public Kosztorys Kosztorys { get; set; }

        [GridView(Label = "Kosztorys")]
        [DataFormView]
        public string KosztorysNazwa { get; set; }

        #endregion

        #region Projekt
        public Guid? ProjektId { get; set; }

        public Kosztorys Projekt { get; set; }

        [GridView(Label = "Projekt")]
        [DataFormView]
        public string ProjektNazwa { get; set; }

        #endregion

        #region Odpowiedzialny

        public Guid? UzytkownikaZamawiajacyId { get; set; }
        public Guid? UzytkownikOdpowiedzialnyId { get; set; }

        #endregion

        #region Jednostka organizacyjna

        public Guid? JednostkaOrganizacyjanId { get; set; }
        public JednostkaOrganizacyjna JednostkaOrganizacyjna { get; set; }

        #endregion

        [Description("Szacowana kwota netto zapytania")]
        [GridView( Label = "Szacowana wartość netto")]
        public decimal SzacowanaKwotaNettoZapytania { get; set; }

        public IList<PozycjaZapytaniaOfertowego> PozycjeZapytaniaOfertowego { get; set; }

        #endregion

        #region Mapowanie 
        public static MappingConfiguration<ZapytanieOfertowe> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<ZapytanieOfertowe>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
            customerMapping.HasProperty(x => x.Tresc).WithInfiniteLength();

            customerMapping.HasAssociation(u => u.Kosztorys)
                .WithOpposite(p => p.ZapytaniaOfertowe)
                .HasConstraint((u, p) => u.KosztorysId == p.Id);

            customerMapping.HasAssociation(u => u.Projekt)
                .WithOpposite(p => p.ZapytaniaOfertowe)
                .HasConstraint((u, p) => u.ProjektId == p.Id);

            customerMapping.HasAssociation(u => u.JednostkaOrganizacyjna)
                .HasConstraint((u, p) => u.JednostkaOrganizacyjanId == p.Id);

            return customerMapping;
        }

        #endregion
    }
}
