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
            Viragok.Items.Clear();
            foreach (var v in viragok)
            {
                ListBoxItem varos = new();
                varos.Content = v._fajta;
                Viragok.Items.Add(varos);
            }
            Ar.Items.Clear();
            foreach (var v in viragok)
            {
                ListBoxItem varos = new();
                varos.Content = v._ar;
                Ar.Items.Add(varos);
            }
            Szin.Items.Clear();
            foreach (var v in viragok)
            {
                ListBoxItem varos = new();
                varos.Content = v._szin;
                Szin.Items.Add(varos);
            }
        }

        
    }
}
