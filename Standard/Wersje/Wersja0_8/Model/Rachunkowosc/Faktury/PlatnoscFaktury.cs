using System;
using System.ComponentModel;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.Faktury
{
    public class PlatnoscFaktury : ObiektBiznesowyBazowy
    {
        [Description("Id faktury")]
        public Guid? FakturaId { get; set; }

        [Description("Faktura do której należy pozycja")]
        public Faktura Faktura { get; set; }

        public string Opis { get; set; }

        public decimal Kwota { get; set; }

        public DateTime DataPlatnosci { get; set; }

        #region Mapowanie 
        public static MappingConfiguration<PlatnoscFaktury> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<PlatnoscFaktury>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Opis).WithInfiniteLength();

            customerMapping.HasAssociation(u => u.Faktura)
                .WithOpposite(p => p.Platnosci)
                .HasConstraint((u, p) => u.FakturaId == p.Id);

            return customerMapping;
        }
        #endregion
    }
}
