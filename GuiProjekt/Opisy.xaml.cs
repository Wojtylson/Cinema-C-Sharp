using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuiProjekt
{
    /// <summary>
    /// Logika interakcji dla klasy Opisy.xaml
    /// </summary>

    public partial class Opisy : Page, IPrzejscie
    {
        public Opisy(int opcja)
        {
            InitializeComponent();
            
            WyswietlFilm(opcja);
        }
        private void WyswietlFilm(int x)
        {
            switch (x)
            {
                case 1:
                    Kleks.Visibility = Visibility.Visible;
                    string opis1 = "Akademia pana Kleksa to uwspółcześniona wersja klasycznej bajki Brzechwy, przemawiająca swoją treścią i formą do najmłodszych," + 
                                  " ale i wchodząca w dialog ze starszymi widzami, którzy wciąż pamiętają kultową ekranizację z lat 80." + 
                                  " Film przedstawia historię pozornie zwykłej dziewczynki - Ady Niezgódki - która trafia do tytułowej Akademii, żeby poznać świat bajek, wyobraźni i kreatywności." + 
                                  " Przy pomocy wybitnego i szalonego pedagoga profesora Ambrożego Kleksa rozwija swoje niesamowite umiejętności," + 
                                  " a także wpada na ślad, który pomoże jej rozwikłać największą rodzinną tajemnicę…";
                    Film kleks = new Film("Maciej", "Kawulski", "Akademia pana Kleksa", "Fantasy", "Polska", opis1, "125 minut");
                    Tytul.Content = kleks.Tytul;
                    Rezyser.Content = "Reżyseria: " + kleks.Imie + " " + kleks.Nazwisko;
                    GatunekFilmu.Content = "Gatunek: " + kleks.Gatunek;
                    KrajProdukcji.Content = "Produkcja: " + kleks.Produkcja;
                    DlugoscFilmu.Content = "Czas trwania: " + kleks.CzasTrwania;
                    OpisFilmu.Text = kleks.Opis; 
                    break;
                case 2:
                    Wonka.Visibility = Visibility.Visible;
                    string opis2 = "Film opowiada o tym, jak największy na świecie wynalazca, magik i producent czekolady w nieprawdopodobny sposób stał się ukochanym Willy Wonką, którego znamy dzisiaj." +                                  
                                  " To niezaprzeczalnie żywiołowe i pomysłowe wielkoekranowe widowisko z Timothée Chalametem w roli tytułowej pokazuje widzom młodego Willy'ego Wonkę," + 
                                  " pełnego pomysłów i zdeterminowanego, by zmienić świat dzięki swoim smakowitym wynalazkom. Udowadnia zarazem, że to, co najlepsze w życiu," + 
                                  " zaczyna się od marzenia. A jeśli przy łucie szczęścia spotka się Willy'ego Wonkę, wszystko jest możliwe.";
                    Film wonka = new Film("Paul", "King", "Wonka", "Fantasy, Komedia, Musical, Przygodowy", "USA, Kanada, Wielka Brytania", opis2, "113 minut");
                    Tytul.Content = wonka.Tytul;
                    Rezyser.Content = "Reżyseria: " + wonka.Imie + " " + wonka.Nazwisko;
                    GatunekFilmu.Content = "Gatunek: " + wonka.Gatunek;
                    KrajProdukcji.Content = "Produkcja: " + wonka.Produkcja;
                    DlugoscFilmu.Content = "Czas trwania: " + wonka.CzasTrwania;
                    OpisFilmu.Text = wonka.Opis;
                    break;
                case 3:
                    Aquaman.Visibility = Visibility.Visible;
                    string opis3 = "Poprzednio Czarna Manta nie zdołał pokonać Aquamana. Wciąż jednak pragnie pomścić śmierć ojca i dlatego nie cofnie się przed niczym," + 
                                   " żeby rozprawić się z Aquamanem raz na zawsze. Tym razem Czarna Manta jest potężniejszy niż dotąd." + 
                                   " Posiadł moc mitycznego Czarnego Trójzęba, który kryje w sobie starożytną i złowrogą siłę. Żeby go pokonać," + 
                                   " Aquaman nieoczekiwanie prosi o pomoc Orma, swojego uwięzionego brata i poprzedniego króla Atlantydy." + 
                                   " Obaj muszą zapomnieć o różnicach, żeby ochronić królestwo oraz ocalić rodzinę Aquamana i cały świat przed nieodwracalnym zniszczeniem.";
                    Film aquaman = new Film("James", "Wan", "Aquaman i Zaginione Królestwo", "Akcja, Science-Fiction", "USA", opis3, "124 minuty");
                    Tytul.Content = aquaman.Tytul;
                    Rezyser.Content = "Reżyseria: " + aquaman.Imie + " " + aquaman.Nazwisko;
                    GatunekFilmu.Content = "Gatunek: " + aquaman.Gatunek;
                    KrajProdukcji.Content = "Produkcja: " + aquaman.Produkcja;
                    DlugoscFilmu.Content = "Czas trwania: " + aquaman.CzasTrwania;
                    OpisFilmu.Text = aquaman.Opis;
                    break;
                case 4:
                    Mickiewicz.Visibility = Visibility.Visible;
                    string opis4 = "Wyrzucony z uczelni pisarz i wykładowca Jan Sienkiewicz zatrudnia się w warszawskim liceum." + 
                                   " Pod jego opiekę trafia słynna na całą szkołę klasa zbuntowanych i odpornych na wiedzę wyrzutków." + 
                                   " IIB to uczniowie z piekła rodem, a ich przyszłość wydaje się przesądzona. Ale Sienkiewicz, uzbrojony w literaturę," + 
                                   " entuzjazm i masę niekonwencjonalnych pomysłów, rzuci wyzwanie skazanej na wykluczenie grupie." + 
                                   " Czy uda mu się ją okiełznać i ocalić? Opowieść o przyjaźni, miłości, szkolnych szaleństwach" + 
                                   " i o tym, że każdy zasługuje na jeszcze jedną szansę.";
                    Film mickiewicz = new Film("Sara", "Bustamante-Drozdek", "Pieprz*ć Mickiewicza", "Obyczajowy", "Polska", opis4, "102 minuty");
                    Tytul.Content = mickiewicz.Tytul;
                    Rezyser.Content = "Reżyseria: " + mickiewicz.Imie + " " + mickiewicz.Nazwisko;
                    GatunekFilmu.Content = "Gatunek: " + mickiewicz.Gatunek;
                    KrajProdukcji.Content = "Produkcja: " + mickiewicz.Produkcja;
                    DlugoscFilmu.Content = "Czas trwania: " + mickiewicz.CzasTrwania;
                    OpisFilmu.Text = mickiewicz.Opis;
                    break;
                default:
                    break;
            }
        }

        public void Powrot(object sender, RoutedEventArgs e)
        {
            MainWindow glowne = new MainWindow();
            glowne.Show();
            Window.GetWindow(this).Close();
        }

        public void Nastepne(object sender, RoutedEventArgs e)
        {   Sala sala = new Sala(string.Empty,string.Empty,string.Empty);
            Menu menu = new Menu(sala, sala.przyciski);
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Content = menu;
            }
        }
    }
}
