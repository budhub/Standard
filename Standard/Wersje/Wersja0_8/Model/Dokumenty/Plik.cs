namespace BudHub.Standard.Wersje.Wersja0_8.Model.Dokumenty
{
    public class Plik : ObiektBiznesowyBazowy
    {
        public string Nazwa { get; set; }

        /// <summary>
        /// Opis pliku
        /// </summary>
        public string Opis { get; set; }        

        /// <summary>
        /// Zawartość pliku - jeśli wczytana podczas pobierania
        /// </summary>
        public byte[] Zawartosc { get; set; }

        /// <summary>
        /// cieżka do pliku 
        /// </summary>
        public string Sciezka { get; set; }
        

        //#region Mapowanie 
        //public static MappingConfiguration<Plik> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<Plik>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.Tresc).HasLength(RozmiarNazwy);
        //    customerMapping.HasProperty(x => x.TypObiektu).AsTransient();
        //    customerMapping.HasProperty(x => x.Lokalizacja).AsTransient();
            

        //    return customerMapping;
        //}

        //#endregion
        
    }
}
