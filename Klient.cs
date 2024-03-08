using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Projekt
{
    [Serializable]
    public class Klient : Uzytkownik
    {
        string email;
        string nrTelefonu;

        public string Email { get => email; set => email = value; }
        public string NrTelefonu { get => nrTelefonu; set => nrTelefonu = value; }

        public Klient() : base()
        {

        }
        public Klient(string imie, string nazwisko, string email, string nrTelefonu) : base(imie, nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            NrTelefonu = nrTelefonu;
        }
        public void ZapisXML(string zapis)
        {
            using StreamWriter sw = new(zapis);
            XmlSerializer xs = new(typeof(Klient));
            xs.Serialize(sw, this);
        }
    }
}
