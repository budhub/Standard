﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using BudHub.Standard.Wersje.Wersja0_8.Model.Kadrowe.Pracownicy.Umowy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Kadrowe.Pracownicy
{
    public class Pracownik : ObiektBiznesowyBazowy
    {
        #region Dane podstawowe 

        [Description("Imię pracownika")]
        [GridView(Aggregate = GridAggregateFunction.Count)]
        [DataFormView]
        public string Imie { get; set; }

        [Description("Nazwisko pracownika")]
        [GridView]
        [DataFormView]
        public string Nazwisko { get; set; }

        [Description("Telefon")]
        [GridView]
        [DataFormView]
        public string Telefon { get; set; }

        [Description("Miasto zamieszkania")]
        [GridView]
        [DataFormView]
        public string Miasto { get; set; }

        [Description("Adres zamieszkania")]
        [DataFormView]
        public string Adres { get; set; }

        [Description("Kod pocztowy zamieszkania")]
        [DataFormView]
        public string KodPocztowy { get; set; }

        [Description("Rodzaj pracownika")]
        [DataFormView]
        public EnumRodzajPracownika RodzajPracownika { get; set; }

        [Description("Czy posiada prawo jazdy")]
        [GridView(FilterFunction = GridKnownFunction.EqualTo)]
        [DataFormView]
        public bool CzyMaPrawoJazdy { get; set; }

        [Description("Czy aktualnie współpracuje/pracuje")]
        [DataFormView]
        [GridView(FilterFunction = GridKnownFunction.EqualTo, FilterDefaultValue = "True")]
        public bool Aktywny { get; set; }

        #endregion

        #region Dane kadrowe 

        [Description("Jednostka organizacyjna Id")]
        [DataFormView(RepositoryType = typeof(JednostkaOrganizacyjna), GroupName = "Kadrowe", TabName = "Kadrowe")]
        public Guid? JednostkaOrganizacyjnaId { get; set; }

        [Description("Jednostka organizacyjna do której należy pracownik")]
        public JednostkaOrganizacyjna JednostkaOrganizacyjna { get; set; }

        [GridView]
        public string JednostkaOrganizacyjnaNazwa { get; set; }

        [Description("Pesel pracownika")]
        [DataFormView(GroupName = "Kadrowe", TabName = "Kadrowe")]
        public string Pesel { get; set; }

        [Description("Seria i numer dowodu osobistego lub innego dokumentu tożsamości")]
        [DataFormView(GroupName = "Kadrowe", TabName = "Kadrowe")]
        public string SeriaINrDowodu { get; set; }

        [Description("Umowy pracownika w naszej firmie")]
        public IList<UmowaPracownika> UmowyPracownika { get; set; }

        [Description("Stanowisko pracownika")]
        [DataFormView(GroupName = "Kadrowe", TabName = "Kadrowe")]
        [GridView]
        public string Stanowisko { get; set; }

        [Description("Przełożony pracownika")]
        [DataFormView(RepositoryType = typeof(Pracownik), GroupName = "Kadrowe", TabName = "Kadrowe")]
        public Guid? PrzelozonyId { get; set; }

        [Description("Przełożony pracownika")]
        [XmlIgnore]
        [GridView]
        public Pracownik Przelozony { get; set; }

        [Description("Podwładni pracownika")]
        [XmlIgnore]
        public IList<Pracownik> Podwladni { get; set; }

        [DataFormView(GroupName = "Informacje", TabName = "Kadrowe")]
        public string NumerButa { get; set; }

        [DataFormView(GroupName = "Informacje", TabName = "Kadrowe")]
        public string Wzrost { get; set; }

        [DataFormView(GroupName = "Informacje", TabName = "Kadrowe")]
        public string RozmiarSpodni { get; set; }

        [DataFormView(GroupName = "Informacje", TabName = "Kadrowe")]
        public string RozmiarKasku { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        [GridView(Aggregate = GridAggregateFunction.Min)]
        public DateTime? DataWaznosciBadan { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        [GridView(Aggregate = GridAggregateFunction.Min)]
        public DateTime? DataWaznosciSzkoleniaBHP { get; set; }

        #endregion

        #region Finansowe

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal? StawkaGodzinowa { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public string WymiarEtatu { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal? KwotaNettoNaUmowie { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal? KwotaBruttoNaUmowie { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal StalaPremia { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public decimal StawkaGodzinowaKoszty { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public string StawkaNaOkresProbny { get; set; }

        //[DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public string StawkaDocelowa { get; set; }

        [DataFormView(GroupName = "Wynagrodzenie", TabName = "Finansowe")]
        public int IloscDniUrlopuWRoku { get; set; }


        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        public DateTime? DataZatrudnienia { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        [GridView(Aggregate = GridAggregateFunction.Min)]
        public DateTime? DoKiedyUmowa { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        public DateTime? DataZwolnienia { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        public DateTime? DataRozpoczeciaWspolpracy { get; set; }

        [DataFormView(GroupName = "Daty", TabName = "Finansowe")]
        public DateTime? DataZakonczeniaWspolpracy { get; set; }


        #endregion



        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Imie) && !string.IsNullOrEmpty(Nazwisko))
            {
                return Imie + " " + Nazwisko;
            } else if (!string.IsNullOrEmpty(Imie))
            {
                return Imie;
            }
            else if (!string.IsNullOrEmpty(Nazwisko))
            {
                return Nazwisko;
            }

            return null;
        }

        

        //#region Mapowanie 
        //public static MappingConfiguration<Pracownik> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<Pracownik>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Imie).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.Nazwisko).HasLength(RozmiarNazwy);

        //    customerMapping.HasAssociation(u => u.JednostkaOrganizacyjna)
        //        .HasConstraint((u, p) => u.JednostkaOrganizacyjnaId == p.Id);

        //    customerMapping.HasAssociation(u => u.Przelozony)
        //        .WithOpposite(p => p.Podwladni)
        //        .HasConstraint((u, p) => u.PrzelozonyId == p.Id);

        //    return customerMapping;
        //}
        //#endregion
    }

    #region Enumy
    [Description("Rodzaj pracownika")]
    public enum EnumRodzajPracownika
    {
        [Description("Pracownicy - produkujący. Pracownik produkcyjny jest odpowiedzialny za wytwarzanie towarów lub usług." +
                     " W odróżnieniu od pracowników biurowych, których zadaniem jest organizowanie produkcji")]
        Produkcyjny,
        [Description("Pracownik organizujący produkcję")]
        Biurowy,
        [Description("Pracownik organizujący produkcję")]
        Kierownik
    }
    #endregion
}
