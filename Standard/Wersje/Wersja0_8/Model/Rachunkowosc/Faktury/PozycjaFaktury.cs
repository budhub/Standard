using System;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.Faktury
{
    public class PozycjaFaktury : ObiektBiznesowyBazowy
    {
        #region Podstawowe

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

        [Description("Ilość kupiona")]
        public decimal Ilosc { get; set; }

        [Description("Cena zakupu")]
        public decimal CenaZakupuNetto { get; set; }

        [Description("Cena zakupu brutto")]
        public decimal CenaZakupuBrutto { get; set; }

        [Description("Cena katalogowa")]
        public decimal CenaKatologowaNetto { get; set; }

        [Description("Id faktury")]
        public Guid? FakturaId { get; set; }

        [Description("Faktura do której należy pozycja")]
        public Faktura Faktura { get; set; }

        [Description("Czy wersja robocza - nowe pozycje są w wersji roboczej")]
        public bool CzyWersjaRobocza { get; set; }

        #endregion

        #region Mapowanie 
        public static MappingConfiguration<PozycjaFaktury> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<PozycjaFaktury>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            
            customerMapping.HasAssociation(u => u.Faktura)
                .WithOpposite(p => p.Pozycje)
                .HasConstraint((u, p) => u.FakturaId == p.Id);

            return customerMapping;
        }
        #endregion
    }
}
