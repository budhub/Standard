using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Komunikacja.Wiadomosci.EMail
{
    public class EMail : ObiektBiznesowyBazowy
    {
        public EMail()
        {
            CzyWersjaRobocza = true;
        }

        [Description("Adresy do kogo jest wysłany mail")]
        public string AdresatDo { get; set; }

        [Description("Adresy do których został wysłany mail w postaci xml'a")]
        public string AdresatDoXML { get; set; }

        

        [Description("Adresy od kogo jest wysłany mail")]
        public string AdresatOd { get; set; }

        [Description("Adresy od kogo jest wysłany w postaci xml'a")]
        public string AdresatOdXML { get; set; }

        

        [Description("Adresy do kogo jest wysłany mail")]
        public string AdresatDW { get; set; }

        [Description("Adresy do kogo jest wysłany w postaci xml'a")]
        public string AdresatDWXML { get; set; }

        

        [Description("Adresy do kogo jest wysłany mail")]
        public string AdresatUDW { get; set; }

        [Description("Adresy do kogo jest wysłany w postaci xml'a")]
        public string AdresatUDWXML { get; set; }

        [Description("Temat maila")]
        public string Nazwa { get; set; }

        [Description("Treść tekstowa maila")]
        public string Tresc { get; set; }        

        [Description("Treść HTML maila")]
        public string TrescHTML { get; set; }

        [Description("Identyfikator maila")]
        public string IdentyfikatorWiadomosci { get; set; }

        [Description("Czy wysłany czy odebrany mail")]
        public EnumKierunekEMaila RodzajMaila { get; set; }

        [Description("Priorytet maila")]
        public EnumPriorytetEMaila Priorytet { get; set; }

        [Description("Czy zawiera załączniki")]
        public bool CzyZawieraZalaczniki { get; set; }        

        [Description("Czy mail jest wersją roboczą - nowy mail jest w wersji roboczej, po wysłaniu przestaje być roboczy")]
        public bool CzyWersjaRobocza { get; set; }

        public Guid? EMailKontoId { get; set; }

        public EMailKonto EMailKonto { get; set; }

        [Description("Rodzic Id maila - jeśli np. dany mail jest odpowiedzią na innego maila")]
        public Guid? RodzicId { get; set; }

        [Description("Rodzic maila - jeśli np. dany mail jest odpowiedzią na innego maila")]
        public EMail Rodzic { get; set; }

        [Description("Rodzic maila - jeśli np. dany mail jest odpowiedzią na innego maila")]
        public IList<EMail> Potomkowie { get; set; }

        [Description("Rodzic maila - jeśli np. dany mail jest odpowiedzią na innego maila")]
        public bool CzyPubliczny { get; set; }

        [Description("Projekt Id do którego należy mail")]
        public Guid? ProjektId { get; set; }

        [Description("Projekt do którego należy mail")]
        public Projekty.Projekt Projekt { get; set; }

        [Description("Folder użytkownika Id do którego przypisany jest mail")]
        public Guid? FolderUzytkownikaId { get; set; }

        [Description("Data wysłania maila")]
        public DateTime? DataWyslania { get; set; }

        [Description("Id użytkownika odpowiedzialnego za mail")]
        public Guid? UzytkownikOdpowiedzialnyId { get; set; }

        [Description("Użytkownik odpowiedzialnego za mail")]
        public Uzytkownicy.Uzytkownik UzytkownikOdpowiedzialny { get; set; }

        [Description("Status maila")]
        public EnumStatusEMaila StatusEMaila { get; set; }

        public string OstatniBlad { get; internal set; }

        [Description("Czy skrót/pasek/obiekt został otwarty - nowe obiekty są wyrurznione")]
        public bool CzyNowy { get; set; }

        

        public override string ToString()
        {
            return Nazwa ?? "";
        }

        //#region Mapowanie 
        //public static MappingConfiguration<EMail> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<EMail>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.Tresc).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.AdresatDo).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.AdresatDoXML).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.AdresatOd).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.AdresatOdXML).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.AdresatDW).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.AdresatDWXML).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.AdresatUDW).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.AdresatUDWXML).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.OstatniBlad).WithInfiniteLength();

        //    customerMapping.HasProperty(x => x.TrescHTML).WithInfiniteLength();
            
        //    customerMapping.HasAssociation(u => u.EMailKonto)
        //        .WithOpposite(p => p.Maile)
        //        .HasConstraint((u, p) => u.EMailKontoId == p.Id);

        //    customerMapping.HasAssociation(u => u.Rodzic)
        //        .WithOpposite(p => p.Potomkowie)
        //        .HasConstraint((u, p) => u.RodzicId == p.Id);

        //    customerMapping.HasAssociation(u => u.Projekt)
        //        .WithOpposite(p => p.Maile)
        //        .HasConstraint((u, p) => u.ProjektId == p.Id);

        //    customerMapping.HasAssociation(u => u.UzytkownikOdpowiedzialny)
        //        .WithOpposite(p => p.MaileUzytkownika)
        //        .HasConstraint((u, p) => u.UzytkownikOdpowiedzialnyId == p.Id);

        //    return customerMapping;
        //}
        //#endregion
    }
}