using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Controls;


namespace GuiProjekt
{
    public class Sala
    {
        public List<Button> przyciski;
        string godzina;
        string dzien;
        string film;
        public string NazwaSali { get;  set; }

        public string Adaptacja { get => film; set => film = value; }
        public string Godzina { get => godzina; set => godzina = value; }
        public string Dzien { get => dzien; set => dzien=value; }


        public Sala()
        {
            Dzien = string.Empty;
            Godzina = string.Empty;
            Adaptacja = string.Empty;
            przyciski=new List<Button>();
            GenerujNazweSali();
        }
        public Sala(string dzien, string godzina, string film)
        {
            Dzien=dzien;
            Godzina = godzina;
            Adaptacja = film;
            przyciski= new List<Button>();
            GenerujNazweSali();
        }
        private void GenerujNazweSali()
        {
            // Tworzymy nazwę sali łącząc pozostałe parametry
            NazwaSali = $"{Dzien}_{Godzina}_{Adaptacja}";
        }
    }
}

