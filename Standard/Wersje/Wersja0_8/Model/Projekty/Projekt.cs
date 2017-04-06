using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty.Kontrahenci;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zamowienia;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.ZapytaniaOfertowe;
using BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Komunikacja.Wiadomosci.EMail;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty
{
    public class Projekt : ObiektBiznesowyBazowy
    {
        #region Podstawowe
        [Description("Nazwa skrócona projektu")]
        
        [DataFormView]
        public string Nazwa { get; set; }

        [Description("Pełna nazwa projektu")]
        [DataFormView]
        public string PelnaNazwa { get; set; }

        [Description("Opis projektu")]
        
        [DataFormView(Height = "100px")]
        public string Opis { get; set; }

        [Description("Zleceniodawca Id - Kontrahent zlecający projekt - płatnik")]
        [DataFormView(RepositoryType = typeof(Kontrahent))]
        public Guid? ZleceniodawcaId { get; set; }

        [Description("Kontrahent dla którego jest wykonywany projekt - płatnik, np. generalny wykonawca")]
        [XmlIgnore]
        public Kontrahent Zleceniodawca { get; set; }

        [Description("Inwestor Id - Kontrahent, który jest Inwestorem projekt")]
        [DataFormView(RepositoryType = typeof(Kontrahent))]
        public Guid? InwestorId { get; set; }

        [Description("Kontrahent który jest Inwestorem projekt")]
        [XmlIgnore]
        public Kontrahent Inwestor { get; set; }

        [Description("Czy aktualnie współpracuje/pracuje")]
        [DataFormView]
        
        public bool Aktywny { get; set; }

        [Description("Status w jakim znajduje się projekt")]
        [GridView(ColumnType = GridColumnType.EnumColumn, ColumnDataType = typeof(EnumStatusProjektu), Label = "Status")]
        [DataFormView]
        public EnumStatusProjektu StatusProjektu { get; set; }

        [Description("Maile projektu")]
        [XmlIgnore]
        public IList<EMail> Maile { get; set; }

        
        #endregion



        #region Finansowe i daty

        #region Daty projektu i gwarancje

        [Description("Data do kiedy mamy złożyć ofertę")]
        [GridView(Label = "Data złożenia oferty")]
        [DataFormView(GroupName = "Daty")]
        public DateTime? DataZlozeniaOferty { get; set; }

        [Description("Data od kiedy startujemy z projektem/budową")]
        [GridView(Label = "Data rozpoczęcia prac")]
        [DataFormView(GroupName = "Daty")]
        public DateTime? DataRozpoczeciaProjektu { get; set; }

        [Description("Data do kiedy mamy wykonać projekt/budowę")]
        [GridView(Label = "Data końca prac")]
        [DataFormView(GroupName = "Daty")]
        public DateTime? DataZakonczeniaProjektu { get; set; }

        [XmlIgnore]
        public IList<Kosztorys> Kosztorysy { get; set; }

        #endregion

        #region Daty i terminy

        [Description("Data odbioru końcowego. Od tej daty rozpoczyna się czas gwarancji")]
        [DataFormView(GroupName = "Daty")]
        public DateTime? DataOdbioruKoncowego { get; set; }

        [Description("")]
        [DataFormView(GroupName = "Daty")]
        public DateTime? DataKoncaGwarancji { get; set; }

        [Description("Termin płatności wystawionych faktur")]
        [DataFormView(TabName = "Finansowe")]
        public decimal IloscDniTerminPlatnosci { get; set; }

        [Description("Ilość miesięcy gwarancji projektu")]
        [DataFormView(TabName = "Finansowe")]
        public decimal IloscMiesiecyGwarancjiIRejkojmi { get; set; }

        #endregion
        
        [Description("Umowna wartość kontraktu w zł netto")]
        [DataFormView(TabName = "Finansowe")]
        public decimal WartoscKontraktuNetto { get; set; }

        [Description("Umowna wartość kontraktu w zł brutto")]
        [DataFormView(TabName = "Finansowe")]
        public decimal WartoscKontraktuBrutto { get; set; }

        [Description("Koszt budowy wyrażony w kwocie")]
        [DataFormView(TabName = "Finansowe")]
        public decimal PartycypacjaWKosztachBudowyKwota { get; set; }

        [Description("Procentowy koszt budowy w stosunku do WartoscKontraktuNetto. Przeważnie 0,1% - 1%. idealnie dla nas 0")]
        [DataFormView(TabName = "Finansowe")]
        public decimal PartycypacjaWKosztachBudowyProcentowo { get; set; }

        [Description("Koszt w ubezpieczeniu budowy wyrażony kwotą")]
        [DataFormView(TabName = "Finansowe")]
        public decimal PartycypacjaWKosztachUbezpieczeniaKwota { get; set; }

        [Description("Procentowy koszt ubezpieczenia w stosunku do WartoscKontraktuNetto. Przeważnie 0% - 0,1%")]
        [DataFormView(TabName = "Finansowe")]
        public decimal PartycypacjaWKosztachUbezpieczeniaProcentowo { get; set; }

        [Description("Czyli do ilu możemy fakturować przed odbiorem końcowym. Przeważnie 90%, 95% idelnie dla nas to 100%")]
        [DataFormView(TabName = "Finansowe")]
        public decimal ProcentMaksymalnegoFakturowaniaCzesciowego { get; set; }

        [Description("Zabezpieczenie należytego wykonania - kaucja gwarancyjna - umowy w stosunku do WartoscKontraktuNetto. Czyli procent zatrzymywanych pieniędzy przy każdej fakturze (lub nie dofakturowany). Przeważnie 5%, 10%")]
        [DataFormView(TabName = "Finansowe")]
        public decimal ZabezpieczenieNalezytegoWykonaniaProcentowo { get; set; }

        [Description("Taki procent kaucji należytego wykonania zostanie zwrócony po odbiorze końcowym")]
        [DataFormView(TabName = "Finansowe")]
        public decimal ProcentZatrzymanychKaucjiPrzedOdbioremKoncowym { get; set; }

        [Description("Taki procent kaucji należytego wykonania zostanie zwrócony po upływie całej gwarancji")]
        [DataFormView(TabName = "Finansowe")]
        public decimal ProcentZatrzymanychKaucjiPoOdbioremKoncowym { get; set; }

        [Description("Wartość zatrzymanej gwarancji")]
        [DataFormView(TabName = "Finansowe")]
        public decimal? KwotaZatrzymanejGwarancji { get; set; }
        #endregion

        #region Foldery

        [Description("Folder projektu w MD (dysk sieciowy Z)")]
        [DataFormView]
        [GridView(Label = "Folder projektu")]
        public string FolderProjektu { get; set; }

        [Description("Folder dokumentacji w MD (dysk sieciowy Z)")]
        public string FolderDokumentacji { get; set; }

        #endregion

        #region Przetargi

        [Description("Nasza cena netoo minimalna z kosztorysu minimalnego")]
        [DataFormView(TabName = "Przetargi")]
        public decimal CenaNettoMinimalnWewnetrzna { get; set; }

        [Description("Cena naszej oferty wysłana do GW/Inwestora")]
        [DataFormView(TabName = "Przetargi")]
        public decimal CenaNettoWyslanaPubliczna { get; set; }

        [Description("Cena naszej oferty wysłana do GW/Inwestora")]
        [DataFormView(TabName = "Przetargi", Height = "400px")]
        public string UwagiDoPrzetargu { get; set; }

        #endregion

        #region Pozostałe

        
        #endregion

        #region Oferty

        public IList<ZapytanieOfertowe> ZapytaniaOfertowe { get; set; }

        #endregion

        #region Zamówienia

        public IList<Zamowienie> Zamowienia { get; set; }

        #endregion

        public override string ToString()
        {
            return Nazwa ?? base.ToString();
        }

        //#region Mapowanie 
        //public static MappingConfiguration<Projekt> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<Projekt>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.TypObiektu).AsTransient();

        //    customerMapping.HasAssociation(u => u.Zleceniodawca)
        //        .WithOpposite(p => p.Projekty)
        //        .HasConstraint((u, p) => u.ZleceniodawcaId == p.Id);

        //    customerMapping.HasAssociation(u => u.Inwestor)
        //        .WithOpposite(p => p.Inwestycje)
        //        .HasConstraint((u, p) => u.InwestorId == p.Id);

        //    return customerMapping;
        //}
        //#endregion
    }
}
