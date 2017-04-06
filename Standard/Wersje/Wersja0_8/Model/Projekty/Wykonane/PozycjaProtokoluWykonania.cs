using System;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Wykonane
{
    public class PozycjaProtokoluWykonania : ObiektBiznesowyBazowy
    {
        #region Podstawowe              

        [Description("Id protokołu wykonania")]
        public Guid? ProdokolWykonaniaId { get; set; }

        [Description("Protokół wykonania do którego należy pozycja")]
        public ProtokolWykonania ProtokolWykonania { get; set; }              

        [Description("Opis pozycji")]
        public string Opis { get; set; }       

        [Description("Jednostka")]
        public EnumJednostka Jednostka { get; set; }

        [Description("Jednostka zapisana słownie")]
        public string JednostkaNazwa { get; set; }

        [Description("Ilość zamówiona")]
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
        public static MappingConfiguration<PozycjaProtokoluWykonania> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<PozycjaProtokoluWykonania>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            
            customerMapping.HasAssociation(u => u.PozycjaKosztorysu)
                .WithOpposite(p => p.PozycjeWykonania)
                .HasConstraint((u, p) => u.PozycjaKosztorysuId == p.Id);

            customerMapping.HasAssociation(u => u.ProtokolWykonania)
                .WithOpposite(p => p.Pozycje)
                .HasConstraint((u, p) => u.ProdokolWykonaniaId == p.Id);

            return customerMapping;
        }
        #endregion
    }
}
