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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private bool otwieraj;
        public Window1()
        {
            InitializeComponent();

            Samochód s1 = new Samochód(Marka.BMW, "X5", 350, ZródłoMocy.diesel, "KR1X5");
            Samochód s2 = new Samochód(Marka.BMW, "X1", 300, ZródłoMocy.benzyna, "KR1X1");
            Samochód s3 = new Samochód(Marka.Audi, "Q3", 280, ZródłoMocy.diesel, "KR1Q3");
            Samochód s4 = new Samochód(Marka.Audi, "RS7", 1500, ZródłoMocy.benzyna, "KRRS7");
            Samochód s5 = new Samochód(Marka.BMW, "M3", 1800, ZródłoMocy.benzyna, "KRBM3");
            Samochód s6 = new Samochód(Marka.Porsche, "Cayman", 1100, ZródłoMocy.benzyna, "K2CAY");
            Samochód s7 = new Samochód(Marka.Nissan, "GT-R", 3000, ZródłoMocy.benzyna, "K1GTR");
            Samochód s8 = new Samochód(Marka.MercedesBenz, "A45 AMG", 800, ZródłoMocy.benzyna, "KRA45");
            Samochód s9 = new Samochód(Marka.MercedesBenz, "CLA AMG", 950, ZródłoMocy.benzyna, "K0AMG");
            Samochód s10 = new Samochód(Marka.Porsche, "911 4S", 1250, ZródłoMocy.diesel, "KR911");

            List<Samochód> samochodyBMW = new List<Samochód>();
            samochodyBMW.Add(s1);
            samochodyBMW.Add(s2);
            samochodyBMW.Add(s5);

            List<Samochód> samochodyAudi = new List<Samochód>();
            samochodyAudi.Add(s3);
            samochodyAudi.Add(s4);
           
            List<Samochód> samochodyLuksusowe = new List<Samochód>();
            samochodyLuksusowe.Add(s6);
            samochodyLuksusowe.Add(s7);
            samochodyLuksusowe.Add(s8);
            samochodyLuksusowe.Add(s9);
            samochodyLuksusowe.Add(s10);

            audi_combo.ItemsSource=samochodyAudi;
            audi_combo.SelectedIndex = 0;

            bmw_combo.ItemsSource = samochodyBMW;
            bmw_combo.SelectedIndex = 0;

            luksusowe_combo.ItemsSource = samochodyLuksusowe;
            luksusowe_combo.SelectedIndex = 0;

            otwieraj = true;

            //zeby dpdawaly sie nowe samochody
            //luksusowe_combo.ItemsSource = null;
           // luksusowe_combo.ItemsSource = samochodyLuksusowe;
        }

        public void StwórzOknoComboBox(ComboBox combo)
        {
            Window2 window2 = new Window2();
            Samochód samochód = (Samochód)combo.SelectedItem;

            window2.marka.Content = "Marka: " + samochód.Marka;
            window2.model.Content = "Model: " + samochód.Model;
            window2.stawka = samochód.Stawka;

            //Hide();
            window2.ShowDialog();
        }

        private void wybierz_bmw_Click(object sender, RoutedEventArgs e)
        {
            StwórzOknoComboBox(bmw_combo);
        }

        private void wybierz_luksusowe_Click(object sender, RoutedEventArgs e)
        {
            StwórzOknoComboBox(luksusowe_combo);
        }

        private void wybierz_audi_Click(object sender, RoutedEventArgs e)
        {
            StwórzOknoComboBox(audi_combo);
        }


        /*private void luksusowe_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             if(otwieraj)
             StwórzOknoComboBox(luksusowe_combo);
         }
         */

    }
}
