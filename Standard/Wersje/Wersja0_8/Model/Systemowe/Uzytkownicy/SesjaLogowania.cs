using System;
using System.ComponentModel;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Uzytkownicy
{
    public class SesjaLogowania : ObiektBiznesowyBazowy
    {
        public SesjaLogowania()
        {            
        }
                

        /// <summary>
        /// Id użytkownika
        /// </summary>
        [Description("Identyfikator użytkownika")]
        public Guid UzytkownikId { get; set; }

        public string Login { get; set; }

        public string KontekstWykonaniaMiedzySystemowyXML { get; set; }

        public override string ToString()
        {
            return Login;
        }


        #region Mapowanie 
        public static MappingConfiguration<SesjaLogowania> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<SesjaLogowania>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(p => p.KontekstWykonaniaMiedzySystemowyXML).WithInfiniteLength();
            return customerMapping;
        }
        #endregion
    }
}
