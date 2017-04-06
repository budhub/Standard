using System.Collections.Generic;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Komunikacja.Wiadomosci.SMS
{
    public class SmsKonto : ObiektBiznesowyBazowy
    {
        public string Nazwa { get; set; }
        public string Telefon { get; set; }
        public string UzytkownicyId { get; set; }
        public string UzytkownicyNazwa { get; set; }
        public IList<WiadomoscSms> Wiadomosci { get; set; }

        #region Mapowanie 
        public static MappingConfiguration<SmsKonto> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<SmsKonto>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            
            return customerMapping;
        }
        #endregion
    }
}
