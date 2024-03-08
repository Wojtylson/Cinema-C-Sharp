using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public abstract class Uzytkownik
    {
        string imie;
        string nazwisko;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }

        public Uzytkownik()
        {

        }
        public Uzytkownik(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }  
    }
}
