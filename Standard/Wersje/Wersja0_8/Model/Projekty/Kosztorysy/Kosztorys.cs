using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zamowienia;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.ZapytaniaOfertowe;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy
{
    public class Kosztorys : ObiektBiznesowyBazowy
    {
        public Kosztorys()
        {
            CenaRoboczoGodziny = 15;
            KosztyPosrednieProcentowo = 65;
            KosztyZakupowProcentowo = 10;
            ZyksProcentowo = 15;
        }

        [Description("Nazwa kosztorysu")]
        
        [DataFormView]
        public string Nazwa { get; set; }

        [Description("Opis kosztorysu")]
        
        [DataFormView]
        public string Opis { get; set; }

        [Description("Data kosztorysu")]
        
        [DataFormView]
        public DateTime? DataKosztorysu { get; set; }

        [Description("Rodzaj kosztorysu - jednostkowy, oferta, bazowy...")]
        
        [DataFormView]
        public string Rodzaj { get; set; }

        public IList<DzialKosztorysu> Dzialy { get; set; }

        public IList<RMSZestawKosztorysu> RMSZestawy { get; set; }

        [Description("Id projektu")]
        [DataFormView(RepositoryType = typeof(Projekt))]
        public Guid? ProjektId { get; set; }

        [Description("Projekt do którego należy kosztorys")]
        public Projekt Projekt { get; set; }

        
        public string ProjektNazwa { get; set; }

        #region Oferty

        public IList<ZapytanieOfertowe> ZapytaniaOfertowe { get; set; }


        [DataFormView]
        public string NazwaOferenta1 { get; set; }

        [DataFormView]
        public string NazwaOferenta2 { get; set; }

        [DataFormView]
        public string NazwaOferenta3 { get; set; }

        [DataFormView]
        public string NazwaOferenta4 { get; set; }

        [DataFormView]
        public string NazwaOferenta5 { get; set; }

        [DataFormView]
        public string NazwaOferenta6 { get; set; }

        [DataFormView]
        public string NazwaOferenta7 { get; set; }

        [DataFormView]
        public string NazwaOferenta8 { get; set; }

        #endregion

        #region Zamówienia

        public IList<Zamowienie> Zamowienia { get; set; }

        #endregion

        #region Rozliczeniowe

        [Description("Cena roboczo godzinny - cenna netto")]
        public decimal CenaRoboczoGodziny { get; set; }

        [Description("Procentowo koszty pośrednie liczone od R")]
        public decimal KosztyPosrednieProcentowo { get; set; }

        [Description("Procentowo koszty zakupu materiału liczone od M+MP")]
        public decimal KosztyZakupowProcentowo { get; set; }

        [Description("Zysk procentowo - liczony od R")]
        public decimal ZyksProcentowo { get; set; }

        #endregion

        #region Wartosci obliczane dla kosztorysu

        [Description("Obliczana wartość (suma wartości wszystkich pozycji - po wartości)'")]
        public decimal WartoscKosztorysu { get; set; }

        [Description("Obliczana wartość kontraktu (suma wartości wszystkich pozycji - po wartości kontraktu)'")]
        public decimal WartoscKosztorysuWedlugKontraktu { get; set; }

        [Description("Obliczana ilość pozycji w kosztorysie - wraz z działami i poddziałami'")]
        public int IloscPozycjiWKosztorysie { get; set; }

        #endregion

        public IList<PozycjaKosztorysu> Pozycje { get; set; } 

        public override string ToString()
        {
            var sb = new StringBuilder(Nazwa);
            sb.Append(" wartość:");
            sb.Append(WartoscKosztorysu.ToString("C0"));

            sb.Append(" kontrakt:");
            sb.Append(WartoscKosztorysuWedlugKontraktu.ToString("C0"));

            sb.Append(" poz:");
            sb.Append(IloscPozycjiWKosztorysie);

            return sb.ToString();
        }

        //#region Mapowanie 
        //public static MappingConfiguration<Kosztorys> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<Kosztorys>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);

        //    customerMapping.HasAssociation(u => u.Projekt)
        //        .WithOpposite(p => p.Kosztorysy)
        //        .HasConstraint((u, p) => u.ProjektId == p.Id);

        //    return customerMapping;
        //}
        //#endregion

        #region Metody
        
        public void PrzepiszIlosciKontraktoweNaIlosci()
        {
            foreach (var dzialKosztorysu in Dzialy)
            {
                if (dzialKosztorysu.Potomkowie != null)
                {
                    foreach (var d in dzialKosztorysu.Potomkowie)
                    {
                        foreach (var p in d.Pozycje)
                        {
                            p.Ilosc = p.IloscWedlugKontraktu;
                        }
                    }
                }


                if (dzialKosztorysu.Pozycje != null)
                {
                    foreach (var p in dzialKosztorysu.Pozycje)
                    {
                        p.Ilosc = p.IloscWedlugKontraktu;
                    }
                }
            }
        }

        /// <summary>
        /// Oblicza kosztorys 
        /// jego wartości
        /// </summary>
        public void PrzeliczKosztorys()
        {
            decimal w = 0;
            decimal wk = 0;
            int iloscPozycji = 0;

            foreach (var dzialKosztorysu in Dzialy)
            {
                dzialKosztorysu.PrzeliczDzial();
                w += dzialKosztorysu.WartoscDzialu;
                wk += dzialKosztorysu.WartoscDzialuWedlugKontraktu;
                iloscPozycji += dzialKosztorysu.IloscPozycjiWDziale;
            }

            WartoscKosztorysu = w;
            WartoscKosztorysuWedlugKontraktu = wk;
            IloscPozycjiWKosztorysie = iloscPozycji;
        }

        /// <summary>
        /// Zwraca ostatni dział o poziomie 'poziom' (0 to pierwszy dział, 1 poddział...)
        /// </summary>
        /// <param name="poziom"></param>
        /// <returns></returns>
        internal DzialKosztorysu PobierzOstatniDzialPoziomu(int poziom)
        {
            if (poziom == 0)
            {
                return this.Dzialy.Last();
            }
            else
            {
                foreach (var dzial in Dzialy)
                {
                    var d = dzial.PobierzOstatniDzialPoziomu(poziom, 1);
                    if (d != null)
                    {
                        return d;
                    }
                }

                return null;
            }
        }

        #endregion
        
    }
}
