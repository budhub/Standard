using System.ComponentModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty.Kontrahenci
{
    public class OsobaKontaktowa : ObiektBiznesowyBazowy
    {
        public OsobaKontaktowa()
        {
            PozycjaWysweitlania = 10;
        }

        public OsobaKontaktowa(string nazwa, string email)
            :this()
        {
            Nazwa = nazwa;
            EMail = email;
        }

        #region Podstawowe

        [Description(@"Nazwa osoby lub (Imie i Nazwisko)")]
        [GridView]
        [DataFormView]
        public string Nazwa { get; set; }

        [Description(@"Nazwa osoby lub (Imie i Nazwisko)")]
        [GridView]
        [DataFormView]
        public string Telefon { get; set; }

        [Description(@"Nazwa osoby lub (Imie i Nazwisko)")]
        [GridView]
        [DataFormView]
        public string EMail { get; set; }

        [Description(@"Im większa liczba, tym 'wyżej' wyświetla się kontakt podczas wyszukiwania")]
        [DataFormView]
        public int PozycjaWysweitlania { get; set; }

        [Description(@"Firma w której pracuje")]
        [GridView]
        [DataFormView]
        public string Firma { get; set; }

        [GridView]
        [DataFormView]
        public string Stanowisko { get; set; }
        #endregion

        public override string ToString()
        {
            return Nazwa + " " + Telefon + " " + EMail + " " + Firma;
        }

        //#region Mapowanie 
        //public static MappingConfiguration<OsobaKontaktowa> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<OsobaKontaktowa>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.EMail).HasLength(RozmiarNazwy);

        //    return customerMapping;
        //}
        //#endregion
    }
}
