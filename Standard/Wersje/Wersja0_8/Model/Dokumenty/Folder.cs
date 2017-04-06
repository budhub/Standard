using System.Collections.Generic;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Dokumenty
{
    public class Folder : ObiektBiznesowyBazowy
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Sciezka { get; set; }
        
        public IList<Folder> Foldery { get; set; }
        public IList<Plik> Pliki { get; set; }

        

        //#region Mapowanie 
        //public static MappingConfiguration<Folder> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<Folder>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.Tresc).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.OpisObiektu).AsTransient();
        //    customerMapping.HasProperty(x => x.LokalizacjaObiektu).AsTransient();
        //    customerMapping.HasProperty(x => x.TypObiektu).AsTransient();

        //    return customerMapping;
        //}
        //#endregion
        }
}
