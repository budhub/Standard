using System;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Sprzedane
{
    public class PozycjaProtokoluSprzedazy : ObiektBiznesowyBazowy
    {
        #region Podstawowe              

        [Description("Id protokołu sprzedaży")]
        public Guid? ProtokolSprzedazyId { get; set; }

        [Description("Protokół sprzedazy do którego należy pozycja")]
        public ProtokolSprzedazy ProtokolSprzedazy { get; set; }

        [Description("Opis pozycji")]
        public string Opis { get; set; }

        [Description("Jednostka")]
        public EnumJednostka Jednostka { get; set; }

        [Description("Jednostka zapisana słownie")]
        public string JednostkaNazwa { get; set; }

        [Description("Ilość Sprzedana")]
        public decimal Ilosc { get; set; }

        [Description("Uwagi do pozycji protokołu")]
        public string Uwagi { get; set; }

        [Description("Numer")]
        public int Numer { get; set; }

        #region Kosztorysy

        [Description("Id pozycji kosztorysu, której tyczy się dana pozycja wykonana")]
        public Guid? PozycjaKosztorysuId { get; set; }

        [Description("Zamówienie do którego należy pozycja")]
        public PozycjaKosztorysu PozycjaKosztorysu { get; set; }

        #endregion

        #endregion

        public override string ToString()
        {
            return Opis ?? base.ToString();
        }

        #region Mapowanie 
        public static MappingConfiguration<PozycjaProtokoluSprzedazy> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<PozycjaProtokoluSprzedazy>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);

            customerMapping.HasAssociation(u => u.PozycjaKosztorysu)
                .WithOpposite(p => p.PozycjeSprzedazy)
                .HasConstraint((u, p) => u.PozycjaKosztorysuId == p.Id);

            customerMapping.HasAssociation(u => u.ProtokolSprzedazy)
                .WithOpposite(p => p.Pozycje)
                .HasConstraint((u, p) => u.ProtokolSprzedazyId == p.Id);

            return customerMapping;
        }
        #endregion
    }
}
