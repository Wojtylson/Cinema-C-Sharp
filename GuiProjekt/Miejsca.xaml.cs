using MySql.Data.MySqlClient;
using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
{/// <summary>
/// 
/// </summary>
    public partial class Miejsca : Page, IPrzejscie
    {
        public string connectionString = "Server=localhost;port=3006;Database=kino;User Id=root;Password=cinemaok;";
        public List<Button> miejsca;
        private Sala sala;
        public static int Licznik = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sala"></param>
        /// <param name="miejsca"></param>
        public Miejsca(Sala sala, List<Button> miejsca)
        {
            InitializeComponent();
            Licznik = 0;
            Zliczanie.Text = Licznik.ToString();
            miejsca.Clear();
            this.sala = sala;
            this.miejsca=sala.przyciski;
            Licznik = miejsca.Count();
            PrzygotujIModyfikujPrzyciski();
        }
        /// <summary>
        /// 
        /// </summary>
        private void PrzygotujIModyfikujPrzyciski()
        {
            List<string> zajeteMiejscaZBazy = PobierzZajeteMiejscaZBazy();

            for (int i = 1; i <= 51; i++)
            {
                Button przycisk = FindName($"Przycisk{i}") as Button;
                przycisk.Click += Kolorowanie;

                string nazwaPrzycisku = $"Przycisk{i}";

                if (zajeteMiejscaZBazy.Contains(nazwaPrzycisku))
                {
                    przycisk.Background = new SolidColorBrush(Colors.Red);
                    przycisk.IsEnabled = false; 
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<string> PobierzZajeteMiejscaZBazy()
        {
            List<string> zajeteMiejscaZBazy = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Sale WHERE NazwaSali = @NazwaSali AND Dzien = @Dzien AND Godzina = @Godzina AND Film = @Film;";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@NazwaSali", sala.NazwaSali);
                    checkCommand.Parameters.AddWithValue("@Dzien", sala.Dzien);
                    checkCommand.Parameters.AddWithValue("@Godzina", sala.Godzina);
                    checkCommand.Parameters.AddWithValue("@Film", sala.Adaptacja);
                    int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingCount > 0)
                    {
                        string selectQuery = "SELECT MiejscaZajete FROM Sale WHERE NazwaSali = @NazwaSali AND Dzien = @Dzien AND Godzina = @Godzina AND Film = @Film;";
                        MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                        selectCommand.Parameters.AddWithValue("@NazwaSali", sala.NazwaSali);
                        selectCommand.Parameters.AddWithValue("@Dzien", sala.Dzien);
                        selectCommand.Parameters.AddWithValue("@Godzina", sala.Godzina);
                        selectCommand.Parameters.AddWithValue("@Film", sala.Adaptacja);
                        using (MySqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["MiejscaZajete"] != DBNull.Value)
                                {
                                    string zajeteMiejscaString = reader.GetString("MiejscaZajete");

                                    if (!string.IsNullOrEmpty(zajeteMiejscaString))
                                    {
                                        zajeteMiejscaZBazy = zajeteMiejscaString.Split(',').ToList();
                                    }
                                    else
                                    {
                                        zajeteMiejscaZBazy.Add("Przycisk51");
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas pobierania zajętych miejsc z bazy danych: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return zajeteMiejscaZBazy;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Kolorowanie(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                SolidColorBrush buttonBackground = clickedButton.Background as SolidColorBrush;

                if (buttonBackground != null)
                {
                    if (buttonBackground.Color == Colors.Red)
                    {
                        MessageBox.Show("Nie możesz wybrać zajetych miejsc", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (buttonBackground.Color == Colors.DarkGray)
                    {
                        clickedButton.Background = new SolidColorBrush(Colors.Green);
                        Licznik++;
                        Zliczanie.Text = Licznik.ToString();
                        sala.przyciski.Add(clickedButton);

                    }
                    else if (buttonBackground.Color == Colors.Green)
                    {
                        clickedButton.Background = new SolidColorBrush(Colors.DarkGray);
                        Licznik--;
                        Zliczanie.Text = Licznik.ToString();
                        sala.przyciski.Remove(clickedButton);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Nastepne(object sender, RoutedEventArgs e)
        {
            if (Licznik == 0)
            {
                try
                {
                    throw new WybierzMiejsca();
                }
                catch (WybierzMiejsca ex)
                {
                    MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            foreach(Button b in miejsca)
            {
                b.Background=new SolidColorBrush(Colors.Red);
            }
           
            DaneKupujacego danekupujacego = new DaneKupujacego(Licznik, sala,miejsca);
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Content = danekupujacego;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Powrot(object sender, RoutedEventArgs e)
        {
            miejsca.Clear();
            Licznik = 0;
            Menu menu = new Menu(sala, miejsca);
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Content = menu;
            }
        }
    }
}
