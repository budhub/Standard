using System.Collections.Generic;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Klasy
{
    public class Zestawienie
    {
        public Zestawienie()
        {

        }

        public List<ElementZestawienia> Grupowane { get; set; }
        public List<ElementZestawienia> Elementy { get; set; }
        public string Nazwa { get; internal set; }
    }
}
