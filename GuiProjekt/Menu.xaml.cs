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
using MySql.Data.MySqlClient;
using System.Diagnostics.Metrics;

namespace GuiProjekt
{/// <summary>
/// 
/// </summary>
    public partial class Menu : Page, IPrzejscie
    {
        public string connectionString = "Server=localhost;port=3006;Database=kino;User Id=root;Password=cinemaok;";
        public List<Button> miejsca = new List<Button>();
        public Sala sala;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sala"></param>
        /// <param name="miejsca"></param>
        public Menu(Sala sala, List<Button> miejsca)
        {
            InitializeComponent();
            Comboboxy();
            this.sala= sala;
            this.miejsca=miejsca;
        }


   
        /// <summary>
        /// 
        /// </summary>
        private void Comboboxy()
        {
            Filmy.Items.Add("Akademia Pana Kleksa");
            Filmy.Items.Add("Wonka");
            Filmy.Items.Add("Aquaman i Zaginione Królestwo");
            Filmy.Items.Add("Piep.zyć Mickiewicza");

            Dni.Items.Add("Poniedziałek");
            Dni.Items.Add("Wtorek");
            Dni.Items.Add("Środa");
            Dni.Items.Add("Czwartek");
            Dni.Items.Add("Piątek");

            Dni.SelectionChanged += WybranyDzien;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WybranyFilm(object sender, SelectionChangedEventArgs e)
        { 

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WybranyDzien(object sender, SelectionChangedEventArgs e)
        {
            Godziny.Items.Clear();

            if(Dni.SelectedItem == "Poniedziałek" || Dni.SelectedItem == "Wtorek" || Dni.SelectedItem == "Czwartek")
            {
                Godziny.Items.Add("10:00");
                Godziny.Items.Add("16:00");
                Godziny.Items.Add("21:00");
            }
            else
            {
                Godziny.Items.Add("17:00");
                Godziny.Items.Add("20:00");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WybranaGodzina(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Sala> PobierzSaleZBazy()
        {
            List<Sala> sale = new List<Sala>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT NazwaSali, Dzien, Godzina, Film FROM Sale;";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nazwaSali = reader.GetString("NazwaSali");
                            string dzien = reader.GetString("Dzien");
                            string godzina = reader.GetString("Godzina");
                            string film = reader.GetString("Film");

                            Sala sala = new Sala(dzien, godzina, film);
                            sala.NazwaSali = nazwaSali;
                            sale.Add(sala);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas pobierania danych o salach z bazy danych: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return sale;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dzien"></param>
        /// <param name="godzina"></param>
        /// <param name="film"></param>
        /// <returns></returns>
        private string UtworzNazweSali(string dzien, string godzina, string film)
        {
            return dzien + "_" + godzina + "_" + film;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Nastepne(object sender, RoutedEventArgs e)
        {
            if (Filmy.SelectedItem != null && Dni.SelectedItem != null && Godziny.SelectedItem != null)
            {
                string wybranyFilm = Filmy.SelectedItem.ToString();
                string wybranyDzien = Dni.SelectedItem.ToString();
                string wybranaGodzina = Godziny.SelectedItem.ToString();
                string nazwaSali = UtworzNazweSali(wybranyDzien, wybranaGodzina, wybranyFilm);
                List<Sala> istniejaceSale = PobierzSaleZBazy();
                Sala sala = istniejaceSale.FirstOrDefault(s => s.NazwaSali == nazwaSali);
                if (sala == null)
                {
                    sala = new Sala(wybranyDzien, wybranaGodzina, wybranyFilm);
                    sala.NazwaSali = nazwaSali;
                    DodajSaleDoBazy(sala);
                }
                Miejsca pon = new Miejsca(sala, miejsca);
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    parentWindow.Content = pon;
                }
            }
            else
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sala"></param>
        private void DodajSaleDoBazy(Sala sala)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Sale WHERE NazwaSali = @NazwaSali;";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@NazwaSali", sala.NazwaSali);
                    int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingCount > 0)
                    {
                        string updateQuery = "UPDATE Sale SET Dzien = @Dzien, Godzina = @Godzina, Film = @Film WHERE NazwaSali = @NazwaSali;";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@NazwaSali", sala.NazwaSali);
                        updateCommand.Parameters.AddWithValue("@Dzien", sala.Dzien);
                        updateCommand.Parameters.AddWithValue("@Godzina", sala.Godzina);
                        updateCommand.Parameters.AddWithValue("@Film", sala.Adaptacja);
                        updateCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sala.NazwaSali))
                        { 
                            MessageBox.Show("Błąd: Nie podano nazwy sali.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO Sale (NazwaSali, Dzien, Godzina, Film) VALUES (@NazwaSali, @Dzien, @Godzina, @Film);";
                            MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@NazwaSali", sala.NazwaSali);
                            insertCommand.Parameters.AddWithValue("@Dzien", sala.Dzien);
                            insertCommand.Parameters.AddWithValue("@Godzina", sala.Godzina);
                            insertCommand.Parameters.AddWithValue("@Film", sala.Adaptacja);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas dodawania/aktualizacji informacji o sali do bazy danych: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void Powrot(object sender, RoutedEventArgs e)
        {
            MainWindow glowne = new MainWindow();
            glowne.Show();
            Window.GetWindow(this).Close();
        }

       
    }
}
