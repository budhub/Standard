using System.Collections.Generic;

namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Komunikacja.Wiadomosci.EMail
{
    public class AdresyEmail
    {
        public AdresyEmail()
        {
            Adresy = new List<AdresEMail>();
        }

        public List<AdresEMail> Adresy { get; set; }

        public override string ToString()
        {
            var s = "";
            foreach (var adresEMail in Adresy)
            {
                s += adresEMail.ToString() + "; ";
            }
            return s;
        }

        public string ToStringEmail()
        {
            var l = new List<string>();
            foreach (var adresEMail in Adresy)
            {
                l.Add((adresEMail.Email ?? adresEMail.Render));
            }
            return string.Join(";", l);
        }

        public string ToStringNazwaEmail()
        {
            var l = new List<string>();
            foreach (var adresEMail in Adresy)
            {
                if (string.IsNullOrEmpty(adresEMail.Email) == false)
                {
                    l.Add(adresEMail.Nazwa + "<" + adresEMail.Email + ">");
                }
                else
                {
                    l.Add(adresEMail.Render);
                }
            }
            return string.Join(";", l);
        }

        public void Parsuj(string adresy)
        {
            Adresy.Clear();
            if (string.IsNullOrEmpty(adresy) == false)
            {
                var aa = adresy.Split(';');
                foreach (var a in aa)
                {
                    var adres = new AdresEMail();
                    adres.Email = a.Replace(">", "").Replace("<", "");
                    adres.Nazwa = a;
                    Adresy.Add(adres);
                }

            }
        }
        
    }
}
