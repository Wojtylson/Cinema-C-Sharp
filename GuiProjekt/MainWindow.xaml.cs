using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
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
using MySql.Data.MySqlClient;

namespace GuiProjekt
{
    public interface IPrzejscie
    {
        void Powrot(object sender, RoutedEventArgs e);
        void Nastepne(object sender, RoutedEventArgs e);
    }
    public class PusteDane : Exception
    {
        public PusteDane() : base("Wprowadź wszystkie dane!") { }
    }
    public class ZleWprowadzoneDane : Exception
    {
        public ZleWprowadzoneDane():base("Wprowadzone dane są błędne, podaj proszę tylko litery") {  }
    }
    public  class ZlyNumer:Exception
    {
        public ZlyNumer():base("Wprowadzone dane są błędne, podaj proszę tylko cyfry") { }
    }
    public class NiepoprawnyFormatEmaila : Exception
    {
        public NiepoprawnyFormatEmaila():base("Wprowadzone dane są błędne, podad proszę poprawny adres email") { }
    }
    public class ZaznaczFormePlatnosci : Exception
    {
        public ZaznaczFormePlatnosci() : base("Wybierz formę płatności") { }
    }
    public class WybierzMiejsca : Exception
    {
        public WybierzMiejsca() : base("Wybierz przynajmniej jedno miejsce, aby przejść dalej") { }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }    
        private void OpisKleks(object sender, RoutedEventArgs e)
        {
            Opisy opisy = new Opisy(1);

            // Otwieranie nowej strony w oknie
            this.Content = opisy;
        }
        private void OpisWonka(object sender, RoutedEventArgs e)
        {
            Opisy opisy = new Opisy(2);

            // Otwieranie nowej strony w oknie
            this.Content = opisy;
        }
        private void OpisAquaman(object sender, RoutedEventArgs e)
        {
            Opisy opisy = new Opisy(3);

            // Otwieranie nowej strony w oknie
            this.Content = opisy;
        }
        private void OpisMickiewicz(object sender, RoutedEventArgs e)
        {
            Opisy opisy = new Opisy(4);

            // Otwieranie nowej strony w oknie
            this.Content = opisy;
        }
    }
}

