using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;
using Telerik.OpenAccess.Metadata.Fluent;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Uzytkownicy
{
    public class GrupaUzytkownikow : ObiektBiznesowyBazowy
    {
        
        [DataFormView]
        public int IdGrupy { get; set; }
        
        /// <summary>
        /// Id grupy nadrzędnej
        /// </summary>
        public int? RodzicId { get; set; }

        
        [DataFormView]
        public string Nazwa { get; set; }

        
        [DataFormView]
        public string Opis { get; set; }

        public override string ToString()
        {
            return Nazwa;
        }

        #region Mapowanie 
        public static MappingConfiguration<GrupaUzytkownikow> PobierzMapping()
        {
            var customerMapping = new MappingConfiguration<GrupaUzytkownikow>();
            customerMapping.MapType();
            MapujPropercjeBazowe(customerMapping);
            customerMapping.HasProperty(x => x.Nazwa).HasLength(ObiektBiznesowyBazowy.RozmiarNazwy);
            customerMapping.HasProperty(x => x.Opis).HasLength(ObiektBiznesowyBazowy.RozmiarNazwy);

            return customerMapping;
        }
        #endregion
    }
}
