using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia_Samochodów
{
    ///<summary>
    /// Klasa Klient tworzy nam obiekty klienta.
    /// </summary>
    public class Klient : Osoba
    {
        public static int liczbaKlientów;

        public Klient(string imię, string nazwisko, string nrDowodu, string nrPrawaJazdy, string adres)
        ///<summary>
        /// Konstruktor tworzy klienta.
        /// <param name="imię">Przechowuje imię klienta.</param>
        /// <param name="nazwisko">Przechowuje nazwisko klienta.</param>
        /// <param name="nrDowodu">Przechowuje numer dowodu osobistego klienta.</param>
        /// <param name="adres">Przechowuje adres podany jako ulica lub miasto zamieszkania klienta.</param>
        /// <param name="NrPrawaJazdy">Przechowuje numer prawa jazdy klienta.</param>
        /// </summary>
        {
            this.imię = imię;
            this.nazwisko = nazwisko;
            this.nrDowodu = nrDowodu;
            this.adres = adres;
            NrPrawaJazdy = nrPrawaJazdy;
            
        }

        public Klient()
        {
            imię = "";
            nazwisko = "";
            nrDowodu = "";
            adres = "";
            NrPrawaJazdy = "";
        }

        [Key] public int samochódId { get; set; }

        public string Imię
        {
            get => imię;
            set => imię = value;
        }

        public string Nazwisko
        {
            get => nazwisko;
            set => nazwisko = value;
        }

        public string NrDowodu
        {
            get => nrDowodu;
            set => nrDowodu = value;
        }

        public string Adres
        {
            get => adres;
            set => adres = value;
        }

        public string NrPrawaJazdy { get; set; }

        public static List<Klient> ListaKlientów { get; set; } = new List<Klient>();

        public static void DodajKlienta(Klient k)
        ///<summary>
        /// Metoda dodaje klienta do listy klientów wypożyczalni.
        /// <param name="liczbaKlientów">Licznik klientów (zwiększa się).</param>
        /// </summary>
        {
            ListaKlientów.Add(k);
            liczbaKlientów++;
        }

        public static void UsuńKlienta(Klient k)
        ///<summary>
        /// Metoda usuwa klienta z listy klientów.
        /// <param name="liczbaKlientów">Licznik klientów (zmniejsza się).</param>
        /// </summary>
        {
            ListaKlientów.Remove(k);
            liczbaKlientów--;
        }

        public override string ToString()
        {
            return "Imię: " + imię + ", Nazwisko: " + nazwisko + ", Adres: " + adres + ", Numer dowodu: " + NrDowodu +
                   ", Numer prawa jazdy: " + NrPrawaJazdy;
        }
    }
}
