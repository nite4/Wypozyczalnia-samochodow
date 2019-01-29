using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia_Samochodów
{
    /// <summary>
    /// Klasa Garaż grupuje samochody wg wtypu/marki. Posiada także metodę Clone().
    /// </summary>
    public class Garaż :ICloneable
    {
        public Garaż(string nazwaGarażu)
        {
            NazwaGarażu = nazwaGarażu;
            Samochody1 = new List<Samochód>();
        }

        public Garaż()
        {
            NazwaGarażu = "";
            Samochody1 = new List<Samochód>();
        }

        public int LiczbaSamochodów { get; set; }
        public List<Samochód> Samochody1 { get; set; } = new List<Samochód>();
        public string NazwaGarażu { get; set; }

        public object Clone()
        ///<summary>
        /// Metoda klonująca samochody.
        /// </summary>
        {
            var klon = new Garaż();
            klon.NazwaGarażu = NazwaGarażu;
            klon.Samochody1 = new List<Samochód>();
            foreach (var x in Samochody1)
                klon.Samochody1.Add((Samochód)x.Clone());
            return klon;
        }

        public void DodajSamochód(Samochód s)
        ///<summary>
        /// Dodawanie samochodów do listy.
        /// </summary>
        {
            Samochody1.Add(s);
            LiczbaSamochodów++;
        }

        public void UsuńSamochód(Samochód s)
        ///<summary>
        /// Usuwanie samochodów z listy.
        /// </summary>
        {
            Samochody1.Remove(s);
            LiczbaSamochodów--;
        }

        public override string ToString()
        {
            var wynik = NazwaGarażu + ": \n";
            foreach (var s in Samochody1)
                wynik += s.Marka + " " + s.Model + ", " + s.Silnik + ", numer rejestracyjny: " + s.NrRejestracyjny +
                         "\n";
            return wynik;
        }
    }
}
