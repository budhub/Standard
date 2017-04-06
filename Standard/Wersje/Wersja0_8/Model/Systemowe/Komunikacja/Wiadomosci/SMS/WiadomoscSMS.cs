using System;
using System.ComponentModel;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Komunikacja.Wiadomosci.SMS
{
    public enum EnumStatusWiadomosciSms
    {
        DoWyslania,
        Wyslany,
        Odebrany,
        BladWysylania
    }

    public class WiadomoscSms : ObiektBiznesowyBazowy
    {
        public string Tresc { get; set; }
        public string TelefonNadawcy { get; set; }
        public string TelefonOdbiorcy { get; set; }
        public EnumStatusWiadomosciSms Status { get; set; }
        public string StatusTekstowy { get; set; }
        public bool CzyPrzetworzony { get; set; }
        public string IdWiadomosci { get; set; }

        public Guid? SmsKontoId { get; set; }

        public SmsKonto SmsKonto { get; set; }

        public bool CzyZawieraZalaczniki
        {
            get; set;
        }        

        public string Nazwa
        {
            get; set;
        }

        [Description("Czy wysłany czy odebrany sms")]
        public EnumKierunekWiadomosciSms RodzajSmsa { get; set; }

        #region Mapowanie 
        public static MappingConfiguration<WiadomoscSms> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<WiadomoscSms>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Tresc).HasLength(RozmiarNazwy);
            customerMapping.HasProperty(x => x.StatusTekstowy).WithInfiniteLength();
            
            customerMapping.HasAssociation(u => u.SmsKonto)
                .WithOpposite(p => p.Wiadomosci)
                .HasConstraint((u, p) => u.SmsKontoId == p.Id);


            return customerMapping;
        }
        #endregion
    }
}