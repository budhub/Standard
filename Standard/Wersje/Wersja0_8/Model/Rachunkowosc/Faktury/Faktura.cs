using System;
using System.Collections.Generic;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty;
using BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty.Kontrahenci;
using BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.Faktury.Klasy;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.Faktury
{
    public class Faktura : ObiektBiznesowyBazowy
    {
        [Description("Numer faktury/ numer obcy")]
        
        [DataFormView]
        public string Numer { get; set; }

        [Description("Opis faktury")]
        
        [DataFormView(Height = "100px")]
        public string Opis { get; set; }

        public Guid? JednostkaOrganizacyjnaId { get; set; }
        
        public string JednostkaOrganizacyjnaNazwa { get; set; }
        public JednostkaOrganizacyjna JednostkaOrganizacyjna { get; set; }



        #region Konrahent

        //Sprzedawca
        
        [DataFormView]
        public string SprzedawcaNazwa { get; set; }

        
        [DataFormView]
        public string SprzedawcaNip { get; set; }
        public string SprzedawcaAdres { get; set; }
        public string SprzedawcaMiasto { get; set; }
        public string SprzedawcaKodPocztowy { get; set; }
        [DataFormView(RepositoryType = typeof(Kontrahent))]
        public Guid? SprzedawcaId { get; set; }
        public Kontrahent Sprzedawca { get; set; }

        //Kupujacy
        
        [DataFormView]
        public string KupujacyNazwa { get; set; }

        
        [DataFormView]
        public string KupujacyNip { get; set; }
        public string KupujacyAdres { get; set; }
        public string KupujacyMiasto { get; set; }
        public string KupujacyKodPocztowy { get; set; }

        [DataFormView(RepositoryType = typeof(Kontrahent))]
        public Guid? KupujacyId { get; set; }
        public Kontrahent Kupujacy { get; set; }

        #endregion

        
        [DataFormView]
        public EnumRodzajFaktury RodzajFaktury { get; set; }

        [DataFormView]
        public DateTime DataWystawienia { get; set; }

        [GridView(FilterFunction = GridKnownFunction.GreaterThan)]
        [DataFormView]
        public DateTime DataOperacji { get; set; }

        [DataFormView]
        public DateTime DataWplywu { get; set; }

        [DataFormView]
        public DateTime DataVat { get; set; }

        [GridView(FilterFunction = GridKnownFunction.GreaterThan)]
        [DataFormView]
        public DateTime? TerminPlatnosci { get; set; }

        [DataFormView]
        public DateTime? TerminZwrotuKaucji { get; internal set; }

        #region Finansowe

        [GridView(FilterFunction = GridKnownFunction.GreaterThan, Aggregate = GridAggregateFunction.Sum,
            DataFormatString = GridViewAttribute.DataFormatStringDecimalCurrency)]
        [DataFormView(GroupName = "Finansowe")]
        public decimal KwotaNetto { get; set; }

        [GridView(FilterFunction = GridKnownFunction.GreaterThan, Aggregate = GridAggregateFunction.Sum,
            DataFormatString = GridViewAttribute.DataFormatStringDecimalCurrency)]
        [DataFormView(GroupName = "Finansowe")]
        public decimal KwotaVat { get; set; }

        [DataFormView(GroupName = "Finansowe")]
        public decimal KwotaBrutto { get; set; }

        [GridView(FilterFunction = GridKnownFunction.GreaterThan, Aggregate = GridAggregateFunction.Sum,
            DataFormatString = GridViewAttribute.DataFormatStringDecimalCurrency)]
        [DataFormView(GroupName = "Finansowe")]
        public decimal Zaplacono { get; set; }

        [GridView(FilterFunction = GridKnownFunction.GreaterThan, Aggregate = GridAggregateFunction.Sum,
            DataFormatString = GridViewAttribute.DataFormatStringDecimalCurrency)]
        [DataFormView(GroupName = "Finansowe")]
        public decimal DoZaplaty { get; set; }

        public int IloscDniPoTerminie
        {
            get
            {
                if (DoZaplaty > 0)
                {
                    return (DateTime.Now - TerminPlatnosci)?.Days ?? 0;
                }
                return 0;
            }
        }

        #endregion

        #region Zewnętrzne

        [Description("Pełny numer z zewnętrznego systemu")]
        public string PelnyNumer { get; set; }

        
        [DataFormView]
        public string Kategoria { get; set; }


        #endregion

        [Description("Pozycje faktury - bez podziałów na działy")]
        public IList<PozycjaFaktury> Pozycje { get; set; }

        [Description("Nowe faktury są w trybie roboczym")]
        public bool CzyWersjaRobocza { get; internal set; }

        [Description("Płatności faktury")]
        public IList<PlatnoscFaktury> Platnosci { get; set; }

        [Description("Unikalny identyfikator z zewnętrznego systemu")]
        public string UnikalnyIdentyfikatorZewnetrzny { get; internal set; }

        #region Mapowanie 
        public static MappingConfiguration<Faktura> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<Faktura>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Opis).WithInfiniteLength();
            customerMapping.HasProperty(x => x.IloscDniPoTerminie).AsTransient();

            customerMapping.HasAssociation(u => u.Kupujacy)
                .HasConstraint((u, p) => u.KupujacyId == p.Id);

            customerMapping.HasAssociation(u => u.Sprzedawca)
                .HasConstraint((u, p) => u.SprzedawcaId == p.Id);

            customerMapping.HasAssociation(u => u.JednostkaOrganizacyjna)
                .HasConstraint((u, p) => u.JednostkaOrganizacyjnaId == p.Id);

            return customerMapping;
        }
        #endregion
    }
}
