using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia_Samochodów
{
    class Program
    {
        ///<summary>
        /// W tej metodzie dodajemy klientów, samochody, garaże oraz wypożyczenia i dokonujemy zapisu do bazy danych.
        /// </summary>
        static void Main(string[] args)
        {
            Klient k1 = new Klient("Weronika", "Zaręba", "AYNXXX", "WER123", "os. Kraka 3");
            Klient k2 = new Klient("Magdalena", "Nitefor", "AKA465", "MAG465", "Bielsko 343");
            Klient k3 = new Klient("Kinga", "Pakos", "ASN34J", "KIN234", "ul.Miła 4");
            Console.WriteLine(k1);
            Console.WriteLine(k2);
            Console.WriteLine(k3);

            Console.WriteLine("\n");

            Samochód s1 = new Samochód(Marka.BMW, "X5", 350, ZródłoMocy.diesel, "KR1X5");
            Samochód s2 = new Samochód(Marka.BMW, "X1", 300, ZródłoMocy.benzyna, "KR1X1");
            Samochód s3 = new Samochód(Marka.Audi, "Q3", 280, ZródłoMocy.diesel, "KR1Q3");
            Samochód s4 = new Samochód(Marka.Audi, "RS7", 1500, ZródłoMocy.benzyna,"KRRS7");
            Samochód s5 = new Samochód(Marka.BMW, "M3", 1800, ZródłoMocy.benzyna, "KRBM3");
            Samochód s6 = new Samochód(Marka.Porsche, "Cayman", 1100, ZródłoMocy.benzyna, "K2CAY");
            Samochód s7 = new Samochód(Marka.Nissan, "GT-R", 3000, ZródłoMocy.benzyna, "K1GTR");
            Samochód s8 = new Samochód(Marka.MercedesBenz, "A45 AMG", 800, ZródłoMocy.benzyna,"KRA45");
            Samochód s9 = new Samochód(Marka.MercedesBenz, "CLA AMG", 950, ZródłoMocy.benzyna,"K0AMG");
            Samochód s10 = new Samochód(Marka.Porsche, "911 4S", 1250, ZródłoMocy.diesel, "KR911");

            Wypożyczenie w1 = new Wypożyczenie("123", s2, k1, new DateTime(2018,02,12), new DateTime(2019, 01, 25));
            Console.WriteLine(w1);
            Console.WriteLine("\n");

            Wypożyczenie w2 = new Wypożyczenie("124", s3, k2, new DateTime(2018, 02, 14), new DateTime(2019, 01, 20));
            Console.WriteLine(w2);
            Console.WriteLine("\n");


            Garaż g1 = new Garaż("Garaż BMW");
            List<Samochód> samochodyBMW = new List<Samochód>();
            g1.DodajSamochód(s1);
            g1.DodajSamochód(s2);
            g1.DodajSamochód(s5);
            Console.WriteLine(g1);

            Garaż g2 = new Garaż("Garaż Audi");
            List<Samochód> samochodyAudi = new List<Samochód>();
            g2.DodajSamochód(s3);
            g2.DodajSamochód(s4);
            Console.WriteLine(g2);

            Garaż g3 = new Garaż("Garaż luksusowych");
            List<Samochód> samochodyLuksusowe = new List<Samochód>();
            g3.DodajSamochód(s6);
            g3.DodajSamochód(s7);
            g3.DodajSamochód(s8);
            g3.DodajSamochód(s9);
            g3.DodajSamochód(s10);
            Console.WriteLine(g3);

            var ww = new Wypożyczenie();
            w1.ZapiszDoBazy();
            ww.OdczytZBazy();


            Console.ReadKey();
        }
    }
}
