using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class DaneKupujacego : Page, IPrzejscie
    {
        public Sala sala;
        public string imie;
        public string nazwisko;
        public string email;
        public string nrTelefonu;
        public List<Klient> listaklientow;
        public List<Button> miejsca;
        public int bilety = 0;
        private delegate void CzyszczenieDanych(object sender, RoutedEventArgs e);
        public List<Button> wybraneMiejsca;
        private CzyszczenieDanych czyszczenie;
      

        public DaneKupujacego(int a,Sala sala,List<Button>miejsca)
        {
            listaklientow = new List<Klient>();
            bilety = a;
            InitializeComponent();
            this.sala = sala;
            Zliczanie.Text = bilety.ToString();
            Comboboxy();
            czyszczenie = UsuwanieZawartosci;
            this.miejsca=miejsca;
 
        }
        private void UsuwanieZawartosci(object sender, RoutedEventArgs e)
        {
            Imie.Text = string.Empty;
            Nazwisko.Text = string.Empty;
            Email.Text = string.Empty;
            NrTelefonu.Text = string.Empty;
            blik.IsChecked = false;
            przelew.IsChecked = false;
            paypal.IsChecked = false;
        }

        public void Nastepne(object sender, RoutedEventArgs e)
        {
            imie = Imie.Text;
            nazwisko = Nazwisko.Text;
            email = Email.Text;
            nrTelefonu = NrTelefonu.Text;
            if (string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nrTelefonu))
            {
                try
                {
                    throw new PusteDane();
                }
                catch (PusteDane ex)
                {
                    MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            if (!(blik.IsChecked == true || przelew.IsChecked == true || paypal.IsChecked == true))
            {
                try
                {
                    throw new ZaznaczFormePlatnosci();
                }
                catch (ZaznaczFormePlatnosci ex)
                {
                    MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }


            Klient klient = new Klient(imie, nazwisko, email, nrTelefonu);
            listaklientow.Add(klient);
            int b = KwotaDoZaplaty();
            int c = NormalneSuma();
            int d = UlgoweSuma();
            Podsumowanie podsumowanie = new Podsumowanie(klient, b, c, d,sala,sala.przyciski);
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Content = podsumowanie;
            }

        }

        private void Imie_TextChanged(object sender, TextChangedEventArgs e)
        {
            int caretIndex = 0;
            if (sender is TextBox textBox)
            {
                if (!string.IsNullOrEmpty(textBox.Text) && (textBox.Text.Any(char.IsDigit) || textBox.Text.Any(c => !char.IsLetter(c))))
                {

                    try
                    {
                        throw new ZleWprowadzoneDane();
                    }
                    catch (ZleWprowadzoneDane ex)
                    {

                        textBox.Text = string.Empty;
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    caretIndex = textBox.CaretIndex;
                    string originalText = textBox.Text;

                    textBox.Text = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1).ToLower();

                    textBox.CaretIndex = caretIndex + textBox.Text.Length - originalText.Length;
                }
            }
        }

        private void Nazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {
            int caretIndex = 0;
            if (sender is TextBox textBox)
            {
                if (!string.IsNullOrEmpty(textBox.Text) && (textBox.Text.Any(char.IsDigit) || textBox.Text.Any(c => !char.IsLetter(c))))
                {

                    try
                    {
                        throw new ZleWprowadzoneDane();
                    }
                    catch (ZleWprowadzoneDane ex)
                    {

                        textBox.Text = string.Empty;
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    caretIndex = textBox.CaretIndex;
                    string originalText = textBox.Text;

                    textBox.Text = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1).ToLower();

                    textBox.CaretIndex = caretIndex + textBox.Text.Length - originalText.Length;
                }
            }
        }
        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string wprowadzonyTekst = textBox.Text;

                // Sprawdź, czy tekst NIE zawiera innych znaków niż @, kropka, litery i cyfry
                if (!Regex.IsMatch(wprowadzonyTekst, @"^[a-zA-Z0-9]+([.-]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(\.[a-zA-Z]{2,})+$"))
                {
                    textBox.Text = string.Empty;
                    MessageBox.Show("Niepoprawny format emaila. Wprowadź poprawny adres email.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void NrTelefonu_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!textBox.Text.All(char.IsDigit))
                {
                    try
                    {
                        throw new ZlyNumer();
                    }
                    catch (ZlyNumer ex)
                    {
                        textBox.Text = string.Empty;
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (textBox.Text.Length > 9)
                {
                    textBox.Text = textBox.Text.Substring(0, 9);
                    textBox.CaretIndex = textBox.Text.Length;
                }


            }
        }

        private void Comboboxy()
        {
            for (int i = 0; i <= bilety; i++)
            {
                Ulgowe.Items.Add(i);
            }

            for (int i = 0; i <= bilety; i++)
            {
                Normalne.Items.Add(i);
            }
            Ulgowe.SelectedItem = 0;
            Normalne.SelectedItem = bilety;

            //OPARTE NA MECHANIZMIE DELEGATOW - przekazujemy metodę do delegata obsługi zdarzeń. 
            Ulgowe.SelectionChanged += Ulgowe_obsluga;
            // Dodanie obsługi zdarzeń po zmianie zaznaczenia
            Normalne.SelectionChanged += Normalne_obsluga;
            SumaBiletow.Text = KwotaDoZaplaty().ToString() + " zł";
        }
        private void Ulgowe_obsluga(object sender, SelectionChangedEventArgs e)
        {
            if (Ulgowe.SelectedItem != null)
            {
                int wybrana = (int)Ulgowe.SelectedItem;

                Normalne.SelectedItem = bilety - wybrana;
            }
            SumaBiletow.Text = KwotaDoZaplaty().ToString() + " zł";
        }
        private void Normalne_obsluga(object sender, SelectionChangedEventArgs e)
        {
            if (Normalne.SelectedItem != null)
            {
                int wybrana = (int)Normalne.SelectedItem;

                Ulgowe.SelectedItem = bilety - wybrana;
            }
            SumaBiletow.Text = KwotaDoZaplaty().ToString() + " zł";
        }

        private int UlgoweSuma()
        {
            if (Ulgowe.SelectedItem != null)
            {
                int wybrana = (int)Ulgowe.SelectedItem;
                return wybrana;
            }
            return -1;
        }
        private int NormalneSuma()
        {
            if (Normalne.SelectedItem != null)
            {
                int wybrana = (int)Normalne.SelectedItem;
                return wybrana;
            }
            return -1;
        }
        private int KwotaDoZaplaty()
        {
            int biletynormalne = NormalneSuma();
            int biletyulgowe = UlgoweSuma();
            return (biletynormalne*(int)EnumBilety.biletnormalny+biletyulgowe*(int)EnumBilety.biletuglowy);
        }

        public void Powrot(object sender, RoutedEventArgs e)
        {
            miejsca.Clear();
            Miejsca miejsc = new Miejsca(sala,miejsca);
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    parentWindow.Content = miejsc;
                }
            }
        }
    }