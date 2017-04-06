using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Projekty.Klasy
{
    /// <summary>
    /// Klasa opisująca kod - czyli skrót z parametrami
    /// przykłady kodów z różną liczbą parametrów
    /// g
    /// spiro150
    /// kanal400x500
    /// g900x600_934
    /// g900x600_934_Inox
    /// g_cosmo
    /// g900x600_934_cosmo
    /// g900x600_934_Inox_cosmo
    /// ...
    /// </summary>
    public class Kod
    {
        public Kod()
        {            
        }

        public string Podstawa { get; set; }

        public string[] Parametry { get; set; }

        public override string ToString()
        {
            if(Parametry == null || Parametry.Length == 0)
            {
                return Podstawa;
            }
            if(Parametry.Length ==1)
            {
                return Podstawa + Parametry[0];
            }
            if(Parametry.Length == 2)
            {
                return Podstawa + Parametry[0] + "x" + Parametry[1];
            }
            if (Parametry.Length > 2)
            {
                var kod = Podstawa + Parametry[0] + "x" + Parametry[1];
                for (int i = 2; i < Parametry.Length; i++)
                {
                    kod += "_" + Parametry[i];
                }
                return kod;
            }

            return Podstawa;
        }
               
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kod"></param>
        /// <returns></returns>
        public static Kod Parse(string kod)
        {
            var k = new Kod();

            if (string.IsNullOrEmpty(kod)==false)
            {

                var t = Regex.Matches(kod, @"[a-zA-Z]+|\d+")
                     .Cast<Match>()
                     .Select(m => m.Value)
                     .ToArray();
                var lista = new List<string>();

                k.Podstawa = t[0];

                var listaParametro = new List<string>();
                int i = 0;
                foreach (var item in t)
                {
                    i++;
                    if (i == 1 || item == "x")
                    {
                        continue;
                    }
                    listaParametro.Add(item);
                }
                k.Parametry = listaParametro.ToArray();
            } else
            {
                k.Parametry = new string[0];
            }
            return k;
        }
    }
}
