using System;
using System.Collections.Generic;
using System.ComponentModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Rachunkowosc.KontaRachunkowe
{
    [Description("Konto księgowe jest to podstawowe urządzenie służące do rejestracji zdarzeń gospodarczych.")]
    public class KontoKsiegowe : ObiektBiznesowyBazowy
    {
        #region Podstawowe dane

        [Description("Nazwa konta. np. Rozrachunki z odbiorcami")]
        
        [DataFormView]
        public string Nazwa { get; set; }

        [Description("Kod konta. np. 200")]
        
        [DataFormView]
        public string Kod { get; set; }

        [Description("Lewa strona - Debet. Operacje nazywane 'obciążeniem konta'")]
        
        [DataFormView]
        public decimal Winien { get; set; }

        [Description("Prawa strona - Credit. Operacje nazywane 'uznaniem konta'")]
        
        [DataFormView]
        public decimal Ma { get; set; }

        
        // Saldo konta
        private decimal saldo;
        [Description("Wartość konta - Saldo")]
        
        public decimal Saldo
        {
            get { saldo = Winien - Ma; return saldo; }
            set { saldo = value; }
        }

        [Description("Konto nadrzędne Id - rodzic")]
        [DataFormView(RepositoryType = typeof(KontoKsiegowe))]
        public Guid? RodzicId { get; set; }

        [Description("Konto nadrzędne - rodzic")]
        public KontoKsiegowe Rodzic { get; set; }

        [Description("Konta podrzędne - dzieci/potomkowie")]
        public IList<KontoKsiegowe> Potomkowie { get; set; }

        #endregion

        //public void Zwieksz(decimal wartosc)
        //{
        //    if(Rodzaj == EnumRodzajKontaKsiegowego.Aktywa)
        //    {
        //        Winien += wartosc;
        //    } else
        //    {
        //        Ma += wartosc;
        //    }
        //}

        //public void Zmniejsz(decimal wartosc)
        //{
        //    if (Rodzaj == EnumRodzajKontaKsiegowego.Aktywa)
        //    {
        //        Ma += wartosc;
        //    }
        //    else
        //    {
        //        Winien += wartosc;
        //    }
        //}

        #region Mapowanie 
        public static MappingConfiguration<KontoKsiegowe> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<KontoKsiegowe>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
            
            customerMapping.HasAssociation(u => u.Rodzic)
                .WithOpposite(p => p.Potomkowie)
                .HasConstraint((u, p) => u.RodzicId == p.Id);

            return customerMapping;
        }
        #endregion

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Kod))
            {
                return Kod + " - " + Nazwa;
            }
            else
            {
                return Nazwa;
            }
        }
    }
}
