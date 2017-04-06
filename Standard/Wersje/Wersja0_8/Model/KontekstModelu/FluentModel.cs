using System.Linq;
using BudHub.Standard.Wersje.Wersja0_8.Model.Kadrowe.Pracownicy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.Faktury;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.KontekstModelu
{
    public partial class FluentModel : OpenAccessContext
    {
        //private static string connectionStringName = KontekstAplikacji.ConnectionString;

        //private static BackendConfiguration backend =
        //    KontekstAplikacji.GetBackendConfiguration();

        protected static MetadataSource metadataSource =
            new FluentModelMetadataSource();

        //public FluentModel()
        //    : this(connectionStringName, backend, metadataSource)
        //{ }

        public FluentModel(string connectionString, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
            :base(connectionString, backendConfiguration, metadataSource)
        { }

        public IQueryable<Pracownik> Pracownicy
        {
            get
            {
                return this.GetAll<Pracownik>();
            }
        }

        public IQueryable<PozycjaFaktury> PozycjeFaktury
        {
            get
            {
                return this.GetAll<PozycjaFaktury>();
            }
        }


        public static void UpdateDatabase()
        {
            
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}
