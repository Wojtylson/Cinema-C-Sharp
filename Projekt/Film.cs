using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Film : Uzytkownik
    {
        string tytul;
        string gatunek;
        string opis;
        string produkcja;
        string czasTrwania;

        public string Tytul { get => tytul; set => tytul = value; }
        public string Gatunek { get => gatunek; set => gatunek = value; }
        public string Opis { get => opis; set => opis = value; }
        public string CzasTrwania { get => czasTrwania; set => czasTrwania = value; }
        public string Produkcja { get => produkcja; set => produkcja = value; }

        public Film(string imie, string nazwisko, string tytul, string gatunek, string produkcja, string opis, string czasTrwania) : base(imie, nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko; 
            Tytul = tytul; 
            Gatunek = gatunek;
            Produkcja = produkcja;
            Opis = opis;
            CzasTrwania = czasTrwania;
        }
    }
}
