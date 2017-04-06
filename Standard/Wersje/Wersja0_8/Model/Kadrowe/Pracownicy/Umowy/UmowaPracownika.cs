using System;
using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Kadrowe.Pracownicy.Umowy
{
    public class UmowaPracownika : ObiektBiznesowyBazowy
    {
        [Description("Data zawarcia umowy")]
        public DateTime DataUmowy { get; set; }

        [Description("Data rozpoczęcia umowy")]
        public DateTime DataStart { get; set; }

        [Description("Data konca umowy - jeśli umowa na czas nie określony to puste pole")]
        public DateTime? DataKoniec { get; set; }

        [Description("Rodzaj umowy zawartej z pracownikiem")]
        public EnumRodzajUmowy RodzajUmowy { get; set; }

        [Description("Opis umowy")]
        public string Opis { get; set; }

        public Guid? PracownikId { get; set; }
        public Pracownicy.Pracownik Pracownik { get; set; }

        //#region Mapowanie 
        //public static MappingConfiguration<UmowaPracownika> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<UmowaPracownika>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Opis).HasLength(RozmiarNazwy);

        //    customerMapping.HasAssociation(u => u.Pracownik)
        //        .WithOpposite(p => p.UmowyPracownika)
        //        .HasConstraint((u, p) => u.PracownikId == p.Id);

        //    return customerMapping;
        //}
        //#endregion
    }

    #region Enumy
    [Description("Rodzaj umowy zawartej z pracownikiem")]
    public enum EnumRodzajUmowy
    {
        [Description("Umowa próbna")]
        UmowaProbna,

        [Description("Umowa zlecenie")]
        UmowaZlecenie,

        [Description("Umowa o dzieło")]
        UmowaODzielo,

        [Description("Umowa o pracę")]
        UmowaOPrace
    }
    #endregion
}
