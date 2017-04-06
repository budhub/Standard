using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy
{
    public class DzialKosztorysu : ObiektBiznesowyBazowy
    {
        
        #region Podstawowe dane

        [Description("Nazwa działu")]
        public string Nazwa { get; set; }

        [Description("Skrót do działu. np. instalacja Centralnego Ogrzewania 'co'")]
        public string Kod { get; set; }

        [Description("Pełny skrót do działu. np. Jeśli dział jest w dziale Instalacje sanitarne o kodzie ins. pełny kod to 'ins.co'")]
        public string PelnyKod { get; set; }

        [Description("Opis działu")]
        public string Opis { get; set; }

        [Description("Id kosztorysu")]
        public Guid KosztorysId { get; set; }

        [Description("Kosztorys do którego należy dział")]
        public Kosztorys Kosztorys { get; set; }

        [Description("Dział nadrzędny Id - rodzic")]
        public Guid? RodzicId { get; set; }

        [Description("Dział nadrzędny - rodzic")]
        public DzialKosztorysu Rodzic { get; set; }

        [Description("Działy podrzędne - dzieci/potomkowie")]
        public IList<DzialKosztorysu> Potomkowie { get; set; }

        [Description("Pozycje działu")]
        public IList<PozycjaKosztorysu> Pozycje { get; set; }

        #region Porzadkowe

        [Description("Numer działu w dziele rodzica - po tym numerze są sortowane działy")]
        public int NumerLiniowyDzialuURodzica { get; set; }

        [Description("Numer dzialu w kosztorysie - po tym numerze są sortowane działy")]
        public int NumerLiniowyDzialu { get; set; }

        [Description("Pełny numer działu. Zawiera 'numer działu.numer poddzialu'")]
        public string Lp { get; set; }

        #endregion

        #region Wartosci obliczane dla działu

        [Description("Obliczana wartość działu (suma wartości wszystkich pozycji - po wartości)'")]
        public decimal WartoscDzialu { get; set; }

        [Description("Obliczana wartość kontraktu działu (suma wartości wszystkich pozycji - po wartości kontraktu)'")]
        public decimal WartoscDzialuWedlugKontraktu { get; set; }


        [Description("Obliczana ilość pozycji w dziale - wraz z działami i poddziałami'")]
        public int IloscPozycjiWDziale { get; set; }
        #endregion

        #endregion

        public override string ToString()
        {
            return Nazwa ?? base.ToString();
        }

        //#region Mapowanie 
        //public static MappingConfiguration<DzialKosztorysu> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<DzialKosztorysu>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);

        //    customerMapping.HasAssociation(u => u.Kosztorys)
        //        .WithOpposite(p => p.Dzialy)
        //        .HasConstraint((u, p) => u.KosztorysId == p.Id);

        //    customerMapping.HasAssociation(u => u.Rodzic)
        //        .WithOpposite(p => p.Potomkowie)
        //        .HasConstraint((u, p) => u.RodzicId == p.Id);

        //    return customerMapping;
        //}
        //#endregion

        #region Metody - akcje

        internal void PrzeliczDzial()
        {
            decimal wartosc = 0;
            decimal wartoscKontraktu = 0;
            int iloscPozycji = 1; //dział też liczymy jako pozycja
            if (Potomkowie != null)
            {
                foreach (var dzialKosztorysu in Potomkowie)
                {
                    dzialKosztorysu.PrzeliczDzial();
                    wartosc += dzialKosztorysu.WartoscDzialu;
                    wartoscKontraktu += dzialKosztorysu.WartoscDzialuWedlugKontraktu;
                    iloscPozycji += dzialKosztorysu.IloscPozycjiWDziale;
                }
            }

            if (Pozycje != null)
            {
                
                foreach (var pozycjaKosztorysu in Pozycje)
                {
                    pozycjaKosztorysu.PrzeliczPozycje();
                    wartosc += pozycjaKosztorysu.Wartosc;
                    wartoscKontraktu += pozycjaKosztorysu.WartoscWedlugKontraktu;
                    iloscPozycji++;
                }
            }

            IloscPozycjiWDziale = iloscPozycji;
            WartoscDzialu = wartosc;
            WartoscDzialuWedlugKontraktu = wartoscKontraktu;
        }

        internal DzialKosztorysu PobierzOstatniDzialPoziomu(int poziomSzukany, int aktualnyPoziom)
        {
            if (poziomSzukany == aktualnyPoziom)
            {
                return Potomkowie.Last();
            }
            foreach (var dzial in Potomkowie)
            {
                var d = dzial.PobierzOstatniDzialPoziomu(poziomSzukany, aktualnyPoziom + 1);
                if (d != null)
                {
                    return d;
                }
            }
            return null;
        }
        #endregion
    }
}
