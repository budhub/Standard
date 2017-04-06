using System;
using System.Collections.Generic;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy.Klasy;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Sprzedane;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Wykonane;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Zamowienia;
using BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.ZapytaniaOfertowe;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy
{
    public class PozycjaKosztorysu : ObiektBiznesowyBazowy
    {
        #region Podstawowe

        [Description("Numer pozycji w kosztorysie - modyfikowany tylko przy eksporcie")]
        public int LiczbaPorzadkowa { get; set; }

        [Description("Numer pozycji w danym dziale")]
        public int LiczbaPorzadkowaWDziale { get; set; }

        [Description("Koloro pozycji w formacie html (hex)")]
        public string Kolor { get; set; }

        #region Podstawa

        [Description("Podstawa kosztorysu  wpisywana ręcznie - nie z ATH np. wodkan.ros20")]
        public string PodstawaInna { get; set; }

        [Description("Podstawa kosztorysu np. KNR-W 4-02 0129-02")]
        public string Podstawa
        {
            get
            {
                if (string.IsNullOrEmpty(PodstawaInna))
                {
                    return KnrKatalog + " " + KnrKatalogNumer + " " + KnrNumerPozycji;
                }
                else
                {
                    return PodstawaInna;
                }
            }

            set
            {
                PodstawaInna = value;
            }
        }

        

        [Description("Wydawnictwo np. WACETOB wyd.I 1998")]
        public string KnrWydawnictwo { get; set; }

        [Description("Katalog normy np. KNR, KNR-W")]
        public string KnrKatalog { get; set; }

        [Description("Pełny numer np. 2-15 0106-01")]
        public string KnrPelnyNumer { get; set; }

        [Description("Numer katalogu np. 2-15")]
        public string KnrKatalogNumer { get; set; }

        [Description("Numer pozycji w katalogu np. 0106-01")]
        public string KnrNumerPozycji { get; set; }

        [Description("Pozycja z ATH")]
        public int? KnrOstatni0 { get; set; }

        [Description("Pozycja z ATH")]
        public int? KnrOstatni1 { get; set; }

        #endregion

        [Description("Skrót do pozycji. np. Montaż zaworu dn 100 ma kod 'z100'")]
        public string Kod { get; set; }

        [Description("Pełny skrót do pozycji. np. Montaż zaworu w instalacji wodnej dn 100 ma kod pełny 'wod.z100'")]
        public string PelnyKod { get; set; }

        [Description("Identyfikator pozycji bazowej na podstawie której wyceniamy pozycję. Może to być kod, lub podstawa kosztorysowa lub identyfikator pozycji. " +
                     "Podstawa możę tyczyć się samej robocizny lub całej wartości pozycji")]
        public string PodstawaWyceny { get; set; }

        
        [Description("Nazwa pozycji / opis")]
        public string Nazwa { get; set; }

        [Description("Uwagi do pozycji - widoczne tylko wewnętrznie")]
        public string Uwagi { get; set; }

        [Description("Preferowany producent lub producent z dokumentacji")]
        public string Producent { get; set; }

        #region Jednostka

        [Description("Jednostka")]
        public EnumJednostka Jednostka { get; set; }

        [Description("Jednostka tekstowo - do edycji")]
        public string JednostkaTekstowo
        {
            get
            {
                return Jednostka.ToString();
            }
            set
            {
                JednostkaNazwa = value;
                EnumJednostka jedn = EnumJednostka.szt;
                if (Enum.TryParse(value.Replace(".", ""), out jedn))
                {
                    Jednostka = jedn;
                }
                else
                {
                    Jednostka = EnumJednostka.inna;
                }
            }
        }
        
        [Description("Jednostka zapisana słownie")]
        public string JednostkaNazwa { get; set; }

        #endregion

        [Description("Rodzaj pozycji kosztorysu")]
        public EnumRodzajPozycji RodzajPozycji { get; set; }

        [Description("Id kosztorysu")]
        public Guid? KosztorysId { get; set; }

        [Description("Kosztorys zawierający pozycję")]
        public Kosztorys Kosztorys { get; set; }

        [Description("Id działu")]
        public Guid? DzialId { get; set; }

        [Description("Dział do którego należy pozycja")]
        public DzialKosztorysu Dzial { get; set; }

        public IList<RMSKosztorysu> RMSy { get; set; }

        #region Porzadkowe

        [Description("Numer działu - po tym numerze są sortowane działy")]
        public int NumerLiniowyDzialu { get; set; }

        [Description("Numer liniowy pozycji w dziale - numer pozycji w dziale")]
        public int NumerLiniowyPozycjiWDziale { get; set; }

        [Description("Numer liniowy pozycji w kosztorysie - numer pozycji w kosztorysie")]
        public int NumerLiniowyPozycjiWKosztorysie { get; set; }

        [Description("Pełna nazwa pozycji elementu kosztorysu. Zawiera 'numer działu.numer pozycji'")]
        public string Lp { get; set; }

        #endregion

        #endregion

        #region Obmiar - ilość

        [Description("Tryb wyliczania ilości z pozycji")]
        public EnumTrybIlosciPozycji TrybWyliczaniaIlosci { get; set; }

        [Description("Ilość z przedmiaru")]
        public decimal IloscZPrzedmiaru { get; set; }

        [Description("Ilość obliczona z dokumentacji lub z natury")]
        public decimal IloscZObmiaru { get; set; }

        [Description("Ilość ustalona w kontrakcie")]
        public decimal IloscWedlugKontraktu { get; set; }

        [Description("Procent naddatku do ilości - na straty materiałowe")]
        public decimal ProcentNaddatkuIlosci { get; set; }

        [Description("Wartosc naddatku do ilości - na straty materiałowe")]
        public decimal NaddatekIlosci { get; set; }

        [Description("Ilość, która jest pobierana do obliczeń, może zawierać naddatek, może być albo ilością przedmiaru albo obmiaru fizycznego")]
        public decimal Ilosc
        {
            get
            {
                switch (TrybWyliczaniaIlosci)
                {
                    case EnumTrybIlosciPozycji.Przedmiar:
                        return IloscZPrzedmiaru + NaddatekIlosci + IloscZPrzedmiaru * ProcentNaddatkuIlosci / new decimal(100);
                    case EnumTrybIlosciPozycji.Obmiar:
                        return IloscZObmiaru + NaddatekIlosci + IloscZObmiaru * ProcentNaddatkuIlosci / new decimal(100);
                }
                return IloscZPrzedmiaru;
            }
            set
            {
                switch (TrybWyliczaniaIlosci)
                {
                    case EnumTrybIlosciPozycji.Przedmiar:
                        IloscZPrzedmiaru = value;
                        break;
                    case EnumTrybIlosciPozycji.Obmiar:
                        IloscZObmiaru = value;
                        break;
                }
            }
        }

        #endregion

        #region Ceny jednostkowe

        /////////////////
        //Materiały

        //Katalogowe
        [Description("Cena katalogowa jednostkowa materialu - wyrażona w zł")]
        public decimal CenaJednostkowaMaterialKatalogowa { get; set; }

        //Zakupowa
        [Description("Cena jednostkowa materialu - ceny zakupowe/wynegocjowane - wyrażona w zł")]
        public decimal CenaJednostkowaMaterialuZakupowa { get; set; }

        [Description("Cena jednostkowa materialu pomocniczego - wyrażona w zł")]
        public decimal CenaJednostkowaMaterialuPomocniczego { get; set; }

        [Description("Procentowo materiał pomocniczy - w procentach do CenaJednostkowaMaterialZakupowa")]
        public decimal CenaJednostkowaMaterialuPomocniczegoProcentowo { get; set; }

        [Description("Nazwa dostawcy materiału lub jego Id. np. Bims, Hydro, lub 37c0a97f-0db8-4fe9-a99e-26c93fa6796b - Id Hydrosolar")]
        public string DostawcaMaterialu { get; set; }

        [Description("Cena jednostkowa materiału." +
            "Wyliczana: CenaJednostkowaMaterialZakupowa + CenaJednostkowaMaterialuPomocniczego + CenaJednostkowaMaterialZakupowa * CenaJednostkowaMaterialuPomocniczego / new decimal(100.0)")]
        public decimal CenaJednostkowaMaterialu
        {
            get { return CenaJednostkowaMaterialuZakupowa + CenaJednostkowaMaterialuPomocniczego + CenaJednostkowaMaterialuZakupowa * CenaJednostkowaMaterialuPomocniczegoProcentowo / new decimal(100.0); }
        }


        /////////////////
        //Robocizna
        [Description("Cena jednostkowa robocizny - wpisana ręcznie - podana kwota")]
        public decimal CenaJednostkowaRobociznaKwota { get; set; }

        [Description("Cena jednostkowa procent w stosunku do materiału")]
        public decimal CenaJednostkowaRobociznaProcentowo { get; set; }

        [Description("Wyliczana cena jednostkowa robocizny. " +
            "Wyliczana z: CenaJednostkowaRobociznaKwota + CenaJednostkowaMaterialZakupowa * CenaJednostkowaRobociznaProcentowo / 100.0 ")]
        public decimal CenaJednostkowaRobocizna
        {
            get { return CenaJednostkowaRobociznaKwota + CenaJednostkowaMaterialuZakupowa * CenaJednostkowaRobociznaProcentowo / new decimal(100.0); }
        }

        /////////////////
        //Sprzet  
        [Description("Cena jednostkowa sprzętu - wpisana ręcznie - podana kwota")]
        public decimal CenaJednostkowaSprzetKwota { get; set; }

        [Description("Cena jednostkowa procent w stosunku do materiału")]
        public decimal CenaJednostkowaSprzetProcentowo { get; set; }

        [Description("Wyliczana cena jednostkowa sprzętu. " +
            "Wyliczana z: CenaJednostkowaRobociznaKwota + CenaJednostkowaMaterialZakupowa * CenaJednostkowaSprzetProcentowo / 100.0 ")]
        public decimal CenaJednostkowaSprzet
        {
            get { return CenaJednostkowaSprzetKwota + CenaJednostkowaMaterialuZakupowa * CenaJednostkowaSprzetProcentowo / new decimal(100.0); }
        }


        [Description("Cena jednostkowa kwota - jeśli mamy samą cenę jednotkową to ustawiamy ją jako cena bazowa. Inne elementy są dodawane do tej ceny. (zobacz CenaJednostkowa)")]
        public decimal CenaJednostkowaKwota { get; set; }

        [Description("Cena jednostkowa. Wyliczana : " +
            "CenaJednostkowaKwota + CenaJednostkowaMaterialu + CenaJednostkowaRobocizna + CenaJednostkowaSprzet")]
        public decimal CenaJednostkowa
        {
            get
            {
                return CenaJednostkowaKwota + CenaJednostkowaMaterialu + CenaJednostkowaRobocizna + CenaJednostkowaSprzet;
            }

            //Seter jednak nie powinien być używany, bo jeśli jest to grid edytując jedną zmienną nadpisuje wszystkie
            //i tym samym kasune stare dane
            // 
            ////Seter jest używany podczas edcyji UI w Gridzie i powinien oznaczać Kwotę
            //set
            //{
            //    //jeśli edytuję cenę jednostkwą to raczej chodzi mi o edytowanie kwoty 
            //    CenaJednostkowaKwota = value;
            //    // a całą resztę zeruje
            //    CenaJednostkowaMaterialuZakupowa = 0;
            //    CenaJednostkowaMaterialuPomocniczego = 0;
            //    CenaJednostkowaRobociznaKwota = 0;
            //    CenaJednostkowaSprzetKwota = 0;

            //}
        }



        #endregion

        #region Wartosci

        [Description("Wartość katalogowa materialu - wyrażona w zł. Wyliczana z wzoru:  CenaJednostkowaMaterialKatalogowa * Ilosc")]
        public decimal WartoscMaterialKatalogowa { get { return CenaJednostkowaMaterialKatalogowa * Ilosc; } }

        [Description("Wyliczana wartość wartości zakupu. Wyliczana z wzoru:  CenaJednostkowaMaterialZakupowa * Ilosc")]
        public decimal WartoscMaterialZakupowy { get { return CenaJednostkowaMaterialuZakupowa * Ilosc; } }

        [Description("Wartość robocizny. Wyliczana z wzoru: CenaJednostkowaRobocizna * Ilosc")]
        public decimal WartoscRobocizny { get { return CenaJednostkowaRobocizna * Ilosc; } }

        [Description("Wartość pozycji. Wyliczana z wzoru: CenaJednostkowa * Ilosc")]
        public decimal Wartosc { get { return CenaJednostkowa * Ilosc; } }

        [Description("Wartość pozycji według kontraktu - ilości kontraktowych. Wyliczana z wzoru: CenaJednostkowa * IloscWedlugKontraktu")]
        public decimal WartoscWedlugKontraktu { get { return CenaJednostkowa * IloscWedlugKontraktu; } }

        #endregion

        #region Roboczo godziny        

        [Description("Ilość roboczo godzin potrzebnych na wykonanie jednostki")]
        public decimal IloscRoboczoGodzinJednostkowo { get; set; }


        #endregion

        #region Ofertowanie

        [Description("Ilość materiału głównego do ofertowania.")]
        public decimal IlosciDoOfertowania { get; set; }

        [Description("Uwagi do pozycji ofertowania - widoczne w wysłanym zapytaniu ofertowym")]
        public string UwagiDoZapytaniaOfertowego { get; set; }

        [Description("Ilość zapytań ofertowych, które zostały wysłane dla tej pozycji")]
        public int IloscWyslanychZapytanOfertowych { get; set; }

        public IList<PozycjaZapytaniaOfertowego> PozycjeZapytaniaOfertowego { get; set; }

        public decimal CenaJednostkowaOferta1 { get; set; }
        public decimal WartoscOferta1 => Ilosc * CenaJednostkowaOferta1;

        public decimal CenaJednostkowaOferta2 { get; set; }
        public decimal WartoscOferta2 => Ilosc * CenaJednostkowaOferta2;

        public decimal CenaJednostkowaOferta3 { get; set; }
        public decimal WartoscOferta3 => Ilosc * CenaJednostkowaOferta3;

        public decimal CenaJednostkowaOferta4 { get; set; }
        public decimal WartoscOferta4 => Ilosc * CenaJednostkowaOferta4;

        public decimal CenaJednostkowaOferta5 { get; set; }
        public decimal WartoscOferta5 => Ilosc * CenaJednostkowaOferta5;

        public decimal CenaJednostkowaOferta6 { get; set; }
        public decimal WartoscOferta6 => Ilosc * CenaJednostkowaOferta6;

        public decimal CenaJednostkowaOferta7 { get; set; }
        public decimal WartoscOferta7 => Ilosc * CenaJednostkowaOferta7;

        public decimal CenaJednostkowaOferta8 { get; set; }
        public decimal WartoscOferta8 => Ilosc * CenaJednostkowaOferta8;


        #endregion


        #region Zamówienia

        [Description("Ilość materiału głównego zamówionego od początku")]
        public decimal IlosciZamowioneOdPoczatku { get; set; }

        [Description("Ilość procentowa materiału głównego zamówionego od początk w stosunku do ilości")]
        public decimal IlosciZamowioneOdPoczatkuProcentowo
        {
            get
            {
                if (Ilosc == 0) return 0;
                return IlosciZamowioneOdPoczatku / Ilosc;
            }
        }

        [Description("Ilość materiału głównego do zamówienia. "
            + "Zamówienie można przygotować")]
        public decimal IlosciDoZamowienia { get; set; }

        [Description("Pozycje zamówienia, które tyczą się danej pozycji kosztorysowej")]
        public IList<PozycjaZamowienia> PozycjeZamowienia { get; set; }


        [Description("Wybrany producent")]
        public string WybranyProducent { get; set; }

        [Description("Wybrany dostawca")]
        public string WybranyDostawca { get; set; }

        #endregion

        #region Protokół wykonania

        [Description("Ilość wykonanych prac od początku")]
        public decimal IlosciWykonanaOdPoczatku { get; set; }

        [Description("Ilość procentowa wykonanych prac od początk w stosunku do ilości")]
        public decimal IlosciWykonanychPracOdPoczatkuProcentowo
        {
            get
            {
                if (Ilosc == 0) return 0;
                return IlosciWykonanaOdPoczatku / Ilosc;
            }
        }

        [Description("Ilość do rozliczenia w okresie rozliczeniowym - do wykonania "
            + "Do przygotowania protokołu wykonania dla pracowników lub podwykonawców")]
        public decimal IloscDoRozliczeniaWykonania { get; set; }

        [Description("Pozycje zamówienia, które tyczą się danej pozycji kosztorysowej")]
        public IList<PozycjaProtokoluWykonania> PozycjeWykonania { get; set; }

        #endregion

        #region Protokół sprzedaży

        [Description("Ilość sprzedanych prac od początku")]
        public decimal IlosciSprzedanaOdPoczatku { get; set; }

        [Description("Ilość procentowa sprzddanych prac od początk w stosunku do ilości")]
        public decimal IlosciSprzedanychPracOdPoczatkuProcentowo
        {
            get
            {
                if (Ilosc == 0) return 0;
                return IlosciSprzedanaOdPoczatku / Ilosc;
            }
        }

        [Description("Ilość do rozliczenia w okresie rozliczeniowym - do sprzedania "
            + "Do przygotowania protokołu wykonania dla pracowników lub podwykonawców")]
        public decimal IloscDoRozliczeniaSprzedazy { get; set; }

        public decimal WartoscRozliczeniaSprzedazy => CenaJednostkowa*IloscDoRozliczeniaSprzedazy;

        [Description("Pozycje sprzedaży, które tyczą się danej pozycji kosztorysowej")]
        public IList<PozycjaProtokoluSprzedazy> PozycjeSprzedazy { get; set; }

        #endregion

        
        #region Pomocnicze

        [Description("Czy dana pozycja jest zaznaczona - np. do sprawdzenia lub do generowania nowego kosztorysu")]
        public bool CzyZaznaczona { get; set; }

        [Description("Ostatni błąd dla danej pozycji podczas wykonywania ostatniej operacji")]
        public string OstatniBladPozycji { get; set; }

        #endregion

        public override string ToString()
        {
            return Nazwa + " ilość:" + Ilosc + " wartość:"+Wartosc;
        }
        
        //#region Mapowanie 
        //public static MappingConfiguration<PozycjaKosztorysu> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<PozycjaKosztorysu>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.OstatniBladPozycji).WithInfiniteLength();
        //    customerMapping.HasProperty(x => x.CenaJednostkowaMaterialu).AsTransient();
        //    customerMapping.HasProperty(x => x.CenaJednostkowaRobocizna).AsTransient();
        //    customerMapping.HasProperty(x => x.CenaJednostkowaSprzet).AsTransient();
        //    customerMapping.HasProperty(x => x.CenaJednostkowa).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscMaterialKatalogowa).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscMaterialZakupowy).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscRobocizny).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscWedlugKontraktu).AsTransient();
        //    customerMapping.HasProperty(x => x.Wartosc).AsTransient();
        //    customerMapping.HasProperty(x => x.Ilosc).AsTransient();
        //    customerMapping.HasProperty(x => x.Podstawa).AsTransient();
        //    customerMapping.HasProperty(x => x.JednostkaTekstowo).AsTransient();
        //    customerMapping.HasProperty(x => x.IlosciZamowioneOdPoczatkuProcentowo).AsTransient();
        //    customerMapping.HasProperty(x => x.IlosciSprzedanychPracOdPoczatkuProcentowo).AsTransient();//
        //    customerMapping.HasProperty(x => x.IlosciWykonanychPracOdPoczatkuProcentowo).AsTransient();
        //    customerMapping.HasAssociation(u => u.Dzial)
        //        .WithOpposite(p => p.Pozycje)
        //        .HasConstraint((u, p) => u.DzialId == p.Id);

        //    customerMapping.HasProperty(x => x.WartoscOferta1).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscOferta2).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscOferta3).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscOferta4).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscOferta5).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscOferta6).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscOferta7).AsTransient();
        //    customerMapping.HasProperty(x => x.WartoscOferta8).AsTransient();

        //    customerMapping.HasProperty(x => x.WartoscRozliczeniaSprzedazy).AsTransient();

        //    customerMapping.HasAssociation(u => u.Kosztorys)
        //        .WithOpposite(p => p.Pozycje)
        //        .HasConstraint((u, p) => u.KosztorysId == p.Id);

        //    return customerMapping;
        //}
        //#endregion

        #region Metody - akcje

        public void PrzeliczPozycje()
        {
            
        }

        #endregion
    }
}
