using System;
using System.Collections.Generic;
using System.ComponentModel;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Sprzedane
{
    public class ProtokolSprzedazy : ObiektBiznesowyBazowy
    {
        #region Podstawowe

        [Description("Numer protokołu")]
        public string NumerProtokolu { get; set; }

        [Description("Numer liniowy protokołu")]
        public int NumerLiniowyProtokolu { get; set; }

        [Description("Data protokołu")]
        public DateTime? DataProtokolu { get; set; }

        [Description("Nazwa protokołu")]
        public string Nazwa { get; set; }

        [Description("Opis protokołu")]
        public string Opis { get; set; }

        [Description("Id użytkownika odpowiedzialnego za zamówienie")]
        public int OdpowiedzialnyId { get; set; }


        [Description("Pozycje sprzedane - bez podziałów na działy")]
        public IList<PozycjaProtokoluSprzedazy> Pozycje { get; set; }
        

        #endregion

        public override string ToString()
        {
            return NumerProtokolu ?? base.ToString();
        }

        #region Mapowanie 
        public static MappingConfiguration<ProtokolSprzedazy> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<ProtokolSprzedazy>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
            customerMapping.HasProperty(x => x.Opis).WithInfiniteLength();

            return customerMapping;
        }
        #endregion
    }
}
