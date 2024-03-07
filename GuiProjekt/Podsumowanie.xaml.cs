using Projekt;
using QRCoder;
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
using System.IO;
using System.Drawing;
using System.Xml.Serialization;
using System.Security.RightsManagement;
using MySql.Data.MySqlClient;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Win32;
using static iText.Kernel.Pdf.Colorspace.PdfDeviceCs;

namespace GuiProjekt
{
    public partial class Podsumowanie : Page
    {   
        private List<Button> miejsca;
        public Klient k;
        public int b;
        public int c;
        public int d;
        public Sala sala;
        public string connectionString = "Server=localhost;port=3006;Database=kino;User Id=root;Password=cinemaok;";

        public Podsumowanie(Klient k, int b, int c, int d,Sala sala,List<Button>miejsca)
        {
            InitializeComponent();  
            this.k = k;
            this.b = b;
            this.c = c;
            this.d = d;
            this.sala=sala;
            this.miejsca=sala.przyciski;
            INFO.Text = Info();
            k.ZapisXML("KlientZapisany");
            generowanieQR();
        }
        
    
       private void generowanieQR()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(INFO.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(200, 200, 96, 96, PixelFormats.Pbgra32);

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(BitmapToImageSource(qrCode.GetGraphic(20)), new Rect(0, 0, 200, 200));
            }
            renderTargetBitmap.Render(drawingVisual);
            QR.Source = renderTargetBitmap;
        }
        private string Info()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Podsumowanie transakcji");
            sb.AppendLine($"Liczba biletów: {c + d}");
            sb.AppendLine($"Kwota do zaplaty: {b} zł");
            sb.AppendLine($"Imię: {k.Imie}");
            sb.AppendLine($"Nazwisko: {k.Nazwisko}");
            sb.AppendLine($"Adres email: {k.Email}");
            sb.AppendLine($"Numer telefonu: {k.NrTelefonu}");
            sb.AppendLine($"Film: {sala.Adaptacja}");
            sb.AppendLine($"Godzina: {sala.Godzina}");
            sb.AppendLine($"Dzień: {sala.Dzien}");
            sb.AppendLine("Miejsca:");
            List<int> liczbyLista = new List<int>();
            foreach (Button s in sala.przyciski)
            {
                string z = s.Content.ToString();
                if (int.TryParse(z, out int liczba))
                {
                    liczbyLista.Add(liczba);
                }

            }
            liczbyLista.Sort();
            foreach(int liczba in liczbyLista)
            {
                sb.AppendLine($"{liczba}");
            }
                return sb.ToString();
            
        }
        
        private void Powrot(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(sala, miejsca);
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Content = menu;
            }

            AktualizujMiejscaWBazie();
        }

        private void AktualizujMiejscaWBazie()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT MiejscaZajete FROM Sale WHERE NazwaSali = @NazwaSali;";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@NazwaSali", sala.NazwaSali);
                    string aktualneMiejsca = Convert.ToString(selectCommand.ExecuteScalar());
                    string noweMiejsca = string.Join(",", miejsca.Select(przycisk => przycisk.Name));
                    string wszystkieMiejsca = string.Join(",", aktualneMiejsca, noweMiejsca);
                    string updateQuery = "UPDATE Sale SET MiejscaZajete = @MiejscaZajete WHERE NazwaSali = @NazwaSali;";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@NazwaSali", sala.NazwaSali);
                    updateCommand.Parameters.AddWithValue("@MiejscaZajete", wszystkieMiejsca);
                    updateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas aktualizowania informacji o miejscach w bazie danych: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

               private ImageSource BitmapToImageSource(Bitmap bitmap)
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                        memory.Position = 0;

                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memory;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();

                        return bitmapImage;
                    }
                }

        private void ZapiszPDF_Click(object sender, RoutedEventArgs e)
        {
         Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();

            MessageBoxResult messageResult = MessageBox.Show("Czy chcesz zapisać plik do PDF?", "PDF File", MessageBoxButton.OKCancel);

            if (messageResult == MessageBoxResult.Cancel)
            {
                MessageBox.Show("Operacja anulowana przez użytkowynika", "PDF File");
            }
            else
            {
                sfd.Title = "Zapisz jako PDF";
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.InitialDirectory = @"C:\";

                if (sfd.ShowDialog() == true)
                {

                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    doc.Add(new iTextSharp.text.Paragraph(INFO.Text));
                    doc.Close();
                    MessageBox.Show("PDF zapisany pomyślnie", "PDF File");

                }
            }
        }
    }
}