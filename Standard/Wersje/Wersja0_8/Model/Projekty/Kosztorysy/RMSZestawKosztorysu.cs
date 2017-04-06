using System;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy
{
    public class RMSZestawKosztorysu : ObiektBiznesowyBazowy
    {

        #region Podstawowe dane

        public string Nazwa { get; set; }
        public string IdentyfikatorZestawu { get; set; }
        public string Jednostka { get; set; }
        public string NumerCeny { get; set; }
        public decimal Cena { get; set; }
        public double Ilosc { get; set; }
        public int Numer { get; set; }
        public int NumerJednostki { get; set; }
        //public EnumTypRMS TypRMS { get; set; }
        public Guid? KosztorysId { get; set; }
        public Kosztorys Kosztorys { get; set; }
        public string IdentyfikatorZestawu1 { get; set; }
        public string Ce0 { get; set; }
        public string Ce1 { get; set; }
        public string Waluta { get; set; }

        #endregion

        public override string ToString()
        {
            return Nazwa ?? base.ToString();
        }

        //#region Mapowanie 
        //public static MappingConfiguration<RMSZestawKosztorysu> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<RMSZestawKosztorysu>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);

        //    customerMapping.HasAssociation(u => u.Kosztorys)
        //        .WithOpposite(p => p.RMSZestawy)
        //        .HasConstraint((u, p) => u.KosztorysId == p.Id);            

        //    return customerMapping;
        //}
        //#endregion
        
    }
}
