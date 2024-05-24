using System.IO;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Viragok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Virag> viragok = new();
        public List<string> adat { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            using StreamReader sr = new(
                path: @"..\..\..\src\flowers.txt",
                encoding: System.Text.Encoding.UTF8);
            while (!sr.EndOfStream) viragok.Add(new(sr.ReadLine()));
            Feltolt(viragok);
        }
        private void Feltolt(List<Virag> viragok)
        {
            var a = viragok.OrderBy(a => a._fajta).ToList();
            Viragok.Items.Clear();
            foreach (var v in viragok)
            {
                ListBoxItem virag = new();
                virag.Content = v._fajta;
                Viragok.Items.Add(virag);
                //orderby
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Ellenőrizzük, hogy van-e kijelölt elem a ListBox-ban
            if (Viragok.SelectedIndex != -1)
            {
                // Töröljük az elemet a kijelölt index alapján
                Viragok.Items.RemoveAt(Viragok.SelectedIndex);
                
            }
            else
            {
                MessageBox.Show("Válasszon ki egy elemet a törléshez!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Ellenőrizzük, hogy van-e kijelölt elem a ListBox-ban
            if (Viragok.SelectedIndex != -1)
            {
                // Másoljuk az elemet a kijelölt index alapján
                MasoltElemek.Items.Add(Viragok.SelectedItem.ToString());

            }
            else
            {
                MessageBox.Show("Válasszon ki egy elemet a törléshez!");
            }
        }

        //private void Adatok_TextChanged(object sender, TextChangedEventArgs e, List<Virag> viragok)
        //{
        //    // Content = viragok._fa
        //    foreach (var v in viragok)
        //    {
        //        ListBoxItem virag = new();
        //        Adatok.Text = v._ar + "\n" + v._szin;
        //        Ar.Items.Add(virag);
        //    }
        //}

        private void Viragok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Viragok.SelectedItem != null)
            {

                ListBoxItem virag = (ListBoxItem)Viragok.SelectedItem;
                foreach (var v in viragok)
                {
                    if (v._fajta == virag.Content.ToString())
                    {
                        Adatok.Text = $"Ár: {v._ar} \n Szín: {v._szin} asd {v._fajl}";
                        //IMG.Source = (new ImageSourceConverter()).ConvertFromString($"../src/IMAGES/{v._fajl}") as ImageSource;
                        try
                        {//application/src/IMAGES/{v._fajl}
                            //$"C:/Users/ny19vizia/source/repos/Viragok/Viragok/Viragok.csproj/src/IMAGES/{v._fajl}";
                            string imagePath = $"/Viragok.csproj/src/IMAGES/{v._fajl}";
                        
                        // var imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                        var imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                            BitmapImage bitmap = new BitmapImage();
                            IMG.Source = new BitmapImage(imageUri);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Hiba történt a kép betöltése közben: {ex.Message}");
                        }
                    }
                }

            }

        }
    }
}
