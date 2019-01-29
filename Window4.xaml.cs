using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Wypożyczalnia_Samochodów;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        
        public Window4()
        {
            InitializeComponent();

            Klient k1 = new Klient("Weronika", "Zaręba", "AYNXXX", "WER123", "os. Kraka 3");
            Klient k2 = new Klient("Magdalena", "Nitefor", "AKA465", "MAG465", "Bielsko 343");
            Klient k3 = new Klient("Kinga", "Pakos", "ASN34J", "KIN234", "ul.Miła 4");

            List<Klient> list = new List<Klient>();
            list.Add(k1);
            list.Add(k2);
            list.Add(k3);

            klienciLista.ItemsSource = list;

            klienciLista.ItemsSource = null;
            klienciLista.ItemsSource = list;

        }

        
    }
}
