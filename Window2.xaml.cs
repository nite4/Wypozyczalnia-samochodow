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
using System.Windows.Shapes;
using Wypożyczalnia_Samochodów;


namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public double stawka;

        public Window2()
        {
            InitializeComponent();
        }

        private void liczbadni_wprowadz_TextChanged(object sender, TextChangedEventArgs e)
        {
            int dni;
            if (int.TryParse(liczbadni_wprowadz.Text, out dni))
            {
                cena.Content = "Cena: " + stawka * dni;
            }
            
        }

        private void zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            //otwieranie okna

            string imie = podaj_imie.Text;
            string nazwisko = podaj_nazwisko.Text;
            string adres = podaj_adres.Text;
            string prawoJazdy = podaj_prawojazdy.Text;
            string dowód = podaj_dowód.Text;

            Klient klient = new Klient(imie, nazwisko, dowód, prawoJazdy, adres);
            Klient.DodajKlienta(klient);

            Window3 okno3 = new Window3();
            okno3.ShowDialog();

        }

      
    }
}
