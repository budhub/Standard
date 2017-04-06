namespace BudHub.Standard.Wersje.Wersja0_8.Model.Systemowe.Komunikacja.Wiadomosci.EMail
{
    public class AdresEMail
    {
        public AdresEMail()
        { }

        public AdresEMail(string adresEmail)
        {
            Email = adresEmail;
        }

        public string Nazwa { get; set; }
        public string Email { get; set; }
        public string Render { get; set; }

        public override string ToString()
        {
            return Nazwa ?? Email;
        }
    }
}
