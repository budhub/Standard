using System;
using System.Collections.Generic;
using System.ComponentModel;
using BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty.Kontrahenci;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Podmioty
{
    public class JednostkaOrganizacyjna : ObiektBiznesowyBazowy
    {
        [Description("Nazwa podmiotu")]
        
        [DataFormView]
        public string Nazwa { get; set; }

        [Description("Kontrahent Id")]
        [DataFormView(RepositoryType = typeof(Kontrahent))]
        public Guid? KontrahentId { get; set; }

        [Description("Kontrahent")]
        
        public Kontrahent Kontrahent { get; set; }

        [Description("Element nadrzędny Id - rodzic")]
        public Guid? RodzicId { get; set; }        

        [Description("Element nadrzędny - rodzic")]
        public JednostkaOrganizacyjna Rodzic { get; set; }

        [Description("Elementy podrzędne - dzieci/potomkowie")]
        public IList<JednostkaOrganizacyjna> Potomkowie { get; set; }

        [Description("Średnia cena roboczo godziny dla danej jednostki organizacyjnej")]
        [DataFormView]
        public decimal SredniaCenaSamejRoboczoGodziny { get; set; }

        public override string ToString()
        {
            return Nazwa;
        }

        //#region Mapowanie 
        //public static MappingConfiguration<JednostkaOrganizacyjna> PobierzMapping()
        //{
        //    var customerMapping = new MappingConfiguration<JednostkaOrganizacyjna>();
        //    customerMapping.MapType();
        //    MapujPropercjeBazowe(customerMapping);
        //    customerMapping.HasProperty(x => x.Nazwa).HasLength(RozmiarNazwy);

        //    customerMapping.HasAssociation(u => u.Kontrahent)
        //        .HasConstraint((u, p) => u.KontrahentId == p.Id);

        //    customerMapping.HasAssociation(u => u.Rodzic)
        //        .WithOpposite(p => p.Potomkowie)
        //        .HasConstraint((u, p) => u.RodzicId == p.Id);

        //    return customerMapping;
        //}
        //#endregion
    }
}
