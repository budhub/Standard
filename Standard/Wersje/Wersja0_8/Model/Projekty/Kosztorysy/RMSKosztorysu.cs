using System;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Kosztorysy
{
    public class RMSKosztorysu : ObiektBiznesowyBazowy
    {


        #region Podstawowe dane

        public int Numer { get; set; }
        public decimal WartoscBezNarzutow { get; set; }
        public decimal WartoscZNarzutami { get; set; }
        public double Naklad { get; set; }
        

        public decimal NakladJednostkowy { get; set; }

        public Guid? PozycjaId { get; set; }
        public PozycjaKosztorysu Pozycja { get; set; }

        public Guid RMSZestawId { get;  set; }
        public RMSZestawKosztorysu RmsZestaw { get; set; }
        #endregion

        public override string ToString()
        {
            return Numer.ToString();
        }

        //#region Mapowanie 
        //public static MappingConfiguration<RMSKosztorysu> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<RMSKosztorysu>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    //customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);

        //    customerMapping.HasAssociation(u => u.Pozycja)
        //        .WithOpposite(p => p.RMSy)
        //        .HasConstraint((u, p) => u.PozycjaId == p.Id);

        //    customerMapping.HasAssociation(u => u.RmsZestaw)
        //        .HasConstraint((u, p) => u.RMSZestawId == p.Id);

        //    return customerMapping;
        //}
        //#endregion
    }
}
