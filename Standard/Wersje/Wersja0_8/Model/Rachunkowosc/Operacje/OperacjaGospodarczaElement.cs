using System;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Kadrowe.Pracownicy;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.Operacje
{
    [Description("Element operacji gospodarczej - jeśli operacja ma wiele elementów, każdy jest opisany przez ten obiekt")]
    public class OperacjaGospodarczaElement : ObiektBiznesowyBazowy
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


        #region Konta Analityczne

        public Guid? ProjektId { get; set; }

        public Projekty.Projekt Projekt { get; set; }

        public Guid? PracownikId { get; set; }

        public Pracownik Pracownik { get; set; }

        #endregion

        #region Mapowanie 
        public static MappingConfiguration<OperacjaGospodarczaElement> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<OperacjaGospodarczaElement>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
            customerMapping.HasProperty(x => x.Tresc).WithInfiniteLength();

            return customerMapping;
        }
        #endregion
    }
}
