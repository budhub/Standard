using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty.Kontrahenci
{
    [Description("Obiekt opisujący firm/kontrahentów")]
    public class Kontrahent : ObiektBiznesowyBazowy
    {
        public Kontrahent()
        {
        }

        #region Podstawowe
        [Description(@"Skrócona nazwa kontrahenta - np. 'Uniterm' zamiast 'Uniterm Michał Feliksik'.
Pełna nazwa znajduje się w polu 'PelnaNazwa'. Nazwa będzie widoczna w numeracji umów, zleceń oraz w dysku sieciowym")]
        [DataFormView(GroupName = "Nazwa")]
        [GridView(FilterFunction = GridKnownFunction.Contains)]
        public string Kod { get; set; }

        [Description("Pełna nazwa kontrahenta")]
        [DataFormView(GroupName = "Nazwa")]
        public string PelnaNazwa { get; set; }

        [Description("Wewnętrzna nazwa kontrahenta - np. Waldi, Szwajkowscy, Piotrek itp..")]
        [DataFormView(GroupName = "Nazwa")]
        public string PotocznaNazwa { get; set; }

        //[Description("Typ kontrahenta")]
        //[DataFormView(GroupName = "Nazwa")]
        //public EnumTypKontrahenta TypKontrahenta { get; set; }

        #region Identyfikacja

        private string nIP;
        [Description("NIP kontrahenta")]
        [DataFormView(GroupName = "Identyfikacja")]
        public string NIP
        {
            get { return nIP; }
            set {
                nIP = value;
                if(nIP != null)
                {
                    NIPBezZnakow = nIP.Replace(" ", "").Replace("-", "");
                }
            }
        }

        [Description("NIP bez spacji, pauz")]
        [GridView]
        public string NIPBezZnakow { get; set; }

        [Description("Regon kontrahenta")]
        [DataFormView(GroupName = "Identyfikacja")]
        [GridView]
        public string Regon { get; set; }

        [Description("Pesel kontrahenta")]
        [DataFormView(GroupName = "Identyfikacja")]
        public string Pesel { get; set; }

        [Description("KRS kontrahenta")]
        [DataFormView(GroupName = "Identyfikacja")]
        public string KRS { get; set; }

        [Description("Sąd prowadzący kontrahenta z wpisu KRS. np.'Sąd Rejonowy Katowice Wschód w Katowicach'")]
        [DataFormView(GroupName = "Identyfikacja")]
        public string SadProwadzacy { get; set; }

        [Description("Wydział sądu z wpisu KRS. np. 'Wydział VIII Gospodarczy'")]
        [DataFormView(GroupName = "Identyfikacja")]
        public string WydzialSadu { get; set; }

        [Description("Imię i Nazwisko osoby reprezentującej kontehenta")]
        [DataFormView(GroupName = "Identyfikacja")]
        public string OsobaReprezentujaca { get; set; }

        [Description("Stanowisko osoby reprezentującej kontehenta. np. Prezes")]
        [DataFormView(GroupName = "Identyfikacja")]
        public string OsobaReprezentujacaStanowisko { get; set; }

        #endregion

        #endregion

        #region Dane tele adresowe

        [Description("Kraj kontrahenta")]
        [DataFormView(GroupName = "Dane adresowe")]
        public string Kraj { get; set; }

        [Description("Wojewodztwo kontrahenta")]
        [DataFormView(GroupName = "Dane adresowe")]
        public string Wojewodztwo { get; set; }

        [Description("Miasto kontrahenta")]
        [DataFormView(GroupName = "Dane adresowe")]
        [GridView]
        public string Miasto { get; set; }

        [Description("Kod pocztowy kontrahenta")]
        [DataFormView(GroupName = "Dane adresowe")]
        public string KodPocztowy { get; set; }

        [Description("Poczta kontrahenta")]
        [DataFormView(GroupName = "Dane adresowe")]
        public string Poczta { get; set; }

        [Description("Adres kontrahenta. np. 'ul. 1000-lecia 41', 'os. wolności 41/2' ")]
        [DataFormView(GroupName = "Dane adresowe")]
        public string Adres { get; set; }

        [Description("Adres email kontaktowy")]
        [DataFormView(GroupName = "Dane adresowe")]
        public string EMailKontaktowy { get; set; }

        [Description("Telefon kontaktowy kontrahenta")]
        [DataFormView(GroupName = "Dane adresowe")]
        public string TelefonKontaktowy { get; set; }

        #endregion

        #region Dokumenty

        [Description("Pełna ścieżka do folderu kontrahenta")]
        [Display]
        public string FolderKontrahenta { get; set; }

        #endregion

        #region Finansowe

        [Description("Ilość dni kalendarzowych dla płatności przelewowych")]
        [DataFormView(TabName = "Finansowe")]
        public string PodstawowyTerminPlatnosciWDniach { get; set; }

        [Description("Forma płatności")]
        [DataFormView(TabName = "Finansowe")]
        public EnumFormaPlatnosci PodstawowaFormaPlatnosci { get; set; }

        [Description("Przyznany limit w zł - jeśli to dostawca - to limit jaki nam udzielił")]
        [DataFormView(TabName = "Finansowe")]
        public decimal PrzyznanyLimit { get; set; }


        #endregion

        #region Projekty

        public IList<Projekty.Projekt> Projekty { get; set; }

        public IList<Projekty.Projekt> Inwestycje { get; set; }

        #endregion

        #region Umowy

        

        #endregion

        
        //#region Mapowanie 
        //public static MappingConfiguration<Kontrahent> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<Kontrahent>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Kod).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.PelnaNazwa).HasLength(RozmiarNazwy);

        //    return customerMapping;
        //}
        //#endregion
    }
}
