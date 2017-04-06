using System.ComponentModel;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.Bankowe
{
    public class KontoBankowe : ObiektBiznesowyBazowy
    {
        [Description("Nazwa konta numer / nazwa")]
        public string Nazwa { get; set; }

        public string Bank { get; set; }
        public string Numer { get; set; }

        public decimal Saldo { get; set; }

        #region Mapowanie 
        public static MappingConfiguration<KontoBankowe> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<KontoBankowe>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);

            return customerMapping;
        }
        #endregion
    }
}
