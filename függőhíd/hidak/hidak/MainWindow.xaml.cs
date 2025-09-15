using System.IO;
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

namespace hidak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Fuggohid> adatok = new List<Fuggohid>();
        string[] tomb = File.ReadAllLines("fuggohidak.csv");
         
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string line in tomb.Skip(1))
            {
                adatok.Add(new Fuggohid(line));

            }


            foreach (Fuggohid line in adatok) 
            {
                nevek.Items.Add(line.nev);

            }
            foreach(Fuggohid line in adatok)
            {
                
            }


        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            int db = 0;
            foreach(Fuggohid line in adatok)
            {
                if(line.atadev < 2000)
                {
                    db++;
                }
            }
            evkiir.Text = db.ToString();
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            int db = 0;
            foreach (Fuggohid line in adatok)
            {
                if (line.atadev >= 2000)
                {
                    db++;
                }
            }
            evkiir.Text = db.ToString();
        }

        private void nevek_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void nevek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Fuggohid line in adatok)
            {
                if (nevek.SelectedItem == line.nev)
                {
                    hely.Text = line.folrajzhely.ToString();
                    orszag.Text = line.orszag.ToString();
                    hossz.Text = line.hossz.ToString();
                    ev.Text = line.atadev.ToString();
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            Window1 win1 = new Window1();
            win1.Show();
            this.Hide();
        }
    }
}