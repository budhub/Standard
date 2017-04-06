using System;
using System.ComponentModel;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.Operacje
{

    [Description("Operacja gospodarcza - element opisujący jedno zdarzenie.")]
    public class OperacjaGospodarcza : ObiektBiznesowyBazowy
    {
        [Description("Tytuł operacji / nazwa")]
        public string Nazwa { get; set; }

        [Description("Opis tekstowy operacji gospodarczej")]
        public string Tresc { get; set; }

        public DateTime DataOperacji { get; set; }

        public DateTime DataKsiegowania { get; set; }

        public string NumerDowoduKsiegowego { get; set; }

        public string RodzajDowoduKsiegowego { get; set; }

        public Guid? KontoKsiegoweZ { get; set; }

        public Guid? KontoKsiegoweDo { get; set; }

        #region Mapowanie 
        public static MappingConfiguration<OperacjaGospodarcza> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<OperacjaGospodarcza>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
            customerMapping.HasProperty(x => x.Tresc).WithInfiniteLength();

            return customerMapping;
        }
        #endregion
    }
}
