using System.Collections.Generic;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model
{
    public partial class FluentModelMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            var configurations =
                new List<MappingConfiguration>();

            configurations.Add(PobierzMapping());
            //configurations.Add(Pracownik.PobierzMapping());

            return configurations;
        }

        private MappingConfiguration<ObiektBiznesowyBazowy> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<ObiektBiznesowyBazowy>();
            customerMapping.MapType().Inheritance(Telerik.OpenAccess.InheritanceStrategy.Horizontal);
            customerMapping.HasProperty(c => c.Id).IsIdentity();
            return customerMapping;
        }

    }
}
