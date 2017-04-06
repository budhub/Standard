using System;
using System.ComponentModel;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zadania
{
    public class Zadanie : ObiektBiznesowyBazowy
    {
        public Zadanie()
        {
        }

        [Description("Użytkownik odpowiedzialny za zadanie, jeśli puste to każdy widzi to zadanie")]
        public int? PrzydzieloneDoId { get; set; }

        [Description("Oryginalny użytkownik odpowiedzialny za zadanie, jeśli zadanie jest przepięte na inną osobę to pierwsza osoba jest pamiętana")]
        public int? OryginalnyPrzydzielonyDoId { get; set; }

        [Description("Użytkownik zlecający zadanie")]
        public int ZlecajacyId { get; set; }

        [Description("Data startu zadania")]
        public DateTime? DataStartu { get; set; }

        [Description("")]
        public DateTime DataKonca { get; set; }

        [Description("")]
        public int ProcentWykonania { get; set; }

        [Description("")]
        public Guid? ProjektId { get; set; }

        [Description("")]
        public string GrupaZadania { get; set; }

        [Description("")]
        public string NumerZadania { get; set; }

        [Description("Tytuł zadania / nazwa")]
        public string Nazwa { get; set; }

        [Description("Tresc tekstowa zadania")]
        public string Tresc { get; set; }

        [Description("Stan w którym znajduje się zadanie")]
        public EnumStatusZadania StatusZadania { get; set; }

        

        #region Mapowanie 
        public static MappingConfiguration<Zadanie> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<Zadanie>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);

            return customerMapping;
        }
        #endregion
    }
}
