using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Komunikacja.Wiadomosci.EMail
{
    public class EMailKonto : ObiektBiznesowyBazowy
    {
        public EMailKonto()
        {
            AdresSerweraPobierania = "poczta.webio.pl";
            AdresSerweraWysylania = "poczta.webio.pl";
            PortSerweraPobierania = "993";
            PortSerweraWysylania = "465";

            Przywitanie = "<p style=\"margin: 0px; padding: 0px; \">Dzień dobry,</p>" +
           "<p style = \"margin:0px; padding:0px;\" > &nbsp;</p>";

            Stopka = @"<p style='margin:0px; padding:0px;'>Pozdrawiam,</p>
<table style='font-size: 9pt;'>
    <tbody>
        <tr>
            <td>
            <p style='margin:0px; padding:0px;'><strong>Pole_ImieNazwisko</strong></p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>Pole_Stanowisko</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>tel: +48 Pole_Telefon</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>email: Pole_Email</p>
            </td>
            <td style='padding-left: 20px;'>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>Siedziba firmy</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'><strong>UNITERM Sp. z o.o.</strong></p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>ul. Gen. Władysława Sikorskiego 71</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>32-540 Trzebinia</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>NIP: 628-226-60-53</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>tel. 790 877 611</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>uniterm@uniterm24.pl</p>
            </td>
            <td style='padding-left: 20px;'>
            <p style='font-size: 9pt; margin:0px; padding:0px;'><strong>Biuro projektowo-Techniczne</strong></p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>ul. Mechanik&oacute;w 9A</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>44-109 Gliwice</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>tel. 533 966 411</p>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>projekty@uniterm24.pl</p>
            </td>
        </tr>
        <tr>
            <td colspan='3'>
            <a href='http://uniterm24.pl/'>
            <p style='font-size: 9pt; margin:0px; padding:0px;'>www.uniterm24.pl</p>
            </a>
            <p style='font-size: 8pt; margin:0px; padding:0px;'>Pole_IdObiektu</p>
            </td>
        </tr>
    </tbody>
</table>".Replace("'","\"");

        }

        [Description("Nazwa skrzynki")]
        [Display]
        [ScaffoldColumn(true)]
        public string Nazwa { get; set; }

        [Display]
        public string AdresSerweraWysylania { get; set; }

        [Display]
        public string PortSerweraWysylania { get; set; }

        [Display]
        public string AdresSerweraPobierania { get; set; }

        [Display]
        public string PortSerweraPobierania { get; set; }

        [Description("Login do skrzynki")]
        [Display]
        [ScaffoldColumn(true)]
        public string Login { get; set; }

        [Display]
        public string Haslo { get; set; }

        public string UzytkownicyId { get; set; }

        [ScaffoldColumn(true)]
        public string UzytkownicyNazwa { get; set; }

        [Display]
        public string EMail { get; set; }

        [Description("Treść przywitania w wiadomości (np. Dzień dobry)")]
        public string Przywitanie { get; set; }

        [Description("Treść stopki wiadomości (np. dane użytkownika, stopka firmy, odziału itp)")]
        public string Stopka { get; set; }

        [Display]
        public bool CzyPersonalne { get; set; }

        [XmlIgnore]
        public IList<EMail> Maile { get; set; }

        #region Mapowanie 
        public static MappingConfiguration<EMailKonto> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<EMailKonto>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);            
            customerMapping.HasProperty(x => x.Przywitanie).WithInfiniteLength();
            customerMapping.HasProperty(x => x.Stopka).WithInfiniteLength();

            return customerMapping;
        }

        #endregion

       
        public override string ToString()
        {
            return Nazwa;
        }
    }
}
