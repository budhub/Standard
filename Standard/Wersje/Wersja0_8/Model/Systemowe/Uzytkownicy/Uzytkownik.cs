using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Komunikacja.Wiadomosci.EMail;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Artificial;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Uzytkownicy
{
    public class Uzytkownik : ObiektBiznesowyBazowy
    {
        public Uzytkownik()
        {
            
        }

        public string Nazwa
        {
            get
            {
                var nazwa = this.Imie + " " + this.Nazwisko;
                if (string.IsNullOrEmpty(nazwa.Trim()))
                {
                    nazwa = this.Login;
                }
                return nazwa;
            }
        }

        /// <summary>
        /// Id użytkownika
        /// </summary>
        [Description("Identyfikator użytkownika - unikalny w całym systemie. Wykorzystuje go moduł uprawnień")]
        [DataFormView]
        public int IdentyfikatorUzytkownika { get; set; }

        [Description("Login użytkownika")]
        
        [DataFormView]
        public string Login { get; set; }

        [Description("Hasło użytkownika")]
        [DataFormView]
        public string Haslo { get; set; }

        [Description("Imię")]
        
        [DataFormView]
        public string Imie { get; set; }

        [Description("Nazwisko")]
        
        [DataFormView]
        public string Nazwisko { get; set; }

        [Description("Stanowisko użytkownika")]
        [DataFormView]
        public string Stanowisko { get; set; }

        [Description("Telefon do użytkownika, na ten numer będzie wysyłane hasło i inne komunikaty")]
        [DataFormView]
        public string Telefon { get; set; }

        [Description("Email do użytkownika")]
        [DataFormView]
        public string Email { get; set; }

        [Description(" Id grup w których znajduje się uzytkownik. Oddzielone ';'")]
        [DataFormView]
        public string GrupyUzytkownika { get; set; }

        [Description("Id podmiotu gospodarczego")]
        public Guid? AktywnyPodmiotDospodarczyId { get; set; }       
        
        [Description("Maile użytkownika")]
        [XmlIgnore]
        public IList<EMail> MaileUzytkownika { get; set; }

        

        public IEnumerable<int> PobierzIdGrupUzytkownikow()
        {
            var grupy = this.GrupyUzytkownika.Split(';').Select(gg => int.Parse(gg));
            return grupy;
        }

        public void UstawIdGrupUzytkownikow(List<int> listaGrup)
        {
            this.GrupyUzytkownika = string.Join(";", listaGrup);
        }


        #region Mapowanie 
        public static MappingConfiguration<Uzytkownik> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<Uzytkownik>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasArtificialStringProperty("Nazwa");
            return customerMapping;
        }        
        #endregion
    }
}
