using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace hidak
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow win2 = new MainWindow();
            win2.Show();
        }
        List<Fuggohid> adatok = new List<Fuggohid>();
        List<string> orszagok = new List<string>();
        string[] tomb = File.ReadAllLines("fuggohidak.csv");
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string line in tomb.Skip(1))
            {
                adatok.Add(new Fuggohid(line));

            }
            foreach (Fuggohid line in adatok)
            {
                if (!orszagok.Contains(line.orszag))
                {
                    orszagok.Add(line.orszag);
                }

            }
            comboBox.ItemsSource = orszagok;

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            comboBox.ItemsSource = orszagok;

            foreach (Fuggohid line in adatok)
            {
                if (comboBox.Text == line.orszag)
                {
                    if(checkBox.IsChecked == true)
                    {
                        if(line.hossz > 1000)
                        {
                            ide.ItemsSource += line.nev;
                        }
                    }
                    else
                    {
                        ide.ItemsSource += line.nev;
                    }
                }
            }
        }
    }
}
