using System;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model
{
    public class ObiektBiznesowyBazowy
    {
        public static int RozmiarNazwy => 500;

        public Guid Id { get; set; }

        public static void MapujPropercjeBazowe<T>(MappingConfiguration<T> customerMapping)
            where T : ObiektBiznesowyBazowy
        {
            customerMapping.HasProperty(x => x.Id).IsIdentity();
        }

    }
}
