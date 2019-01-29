using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Wypożyczalnia_Samochodów
{ 

    [Serializable]

    ///<summary>
    /// W tej klasie mamy obiekt Wypożyczenie i wszystko, czego do wypożyczenia możemy sobie zażyczyć.
    /// Włączając w to serializację danych.
    /// </summary>
    public class Wypożyczenie : IZapisywalna
    {
        public Samochód auto;
        public double cena;
        public DateTime dataWypożyczenia;
        public DateTime dataZwrotu;
        public Klient klient;
        public TimeSpan liczbaDni;
        public int liczbaWypożyczeń;
        public List<Wypożyczenie> listaWypożyczeń = new List<Wypożyczenie>();

        public string numer;

        public Wypożyczenie()
        {
            numer = "";
            auto = auto;
            klient = klient;
            dataWypożyczenia = new DateTime(1, 1, 1);
            dataZwrotu = new DateTime(1, 1, 1);
        }

        public Wypożyczenie(string id, Samochód s, Klient k, DateTime dataWyp, DateTime dataZwr)
        ///<summary>
        /// Konstruktor wypożyczenia. ZakresDat jest opisany w klasie Daty.
        /// <param name="id">Identyfikator wypożyczenia. </param>
        /// <param name="auto">Obiekt samochodu, przypisywanego do danego wypożyczenia. </param>
        /// <param name="klient">Obiekt klienta, przypisywanego do danego wypożyczenia. </param>
        /// <param name="dataWypożyczenia">Data wypożyczenia, którą proponuje klient. </param>
        /// <param name="dataZwrotu">Data zwrotu, którą proponuje klient. </param>
        /// </summary>
        {
            numer = id;
            auto = s;
            klient = k;

            dataWypożyczenia.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture);
            dataZwrotu.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture);
            if (Daty.ZakresDat(dataZwr.ToString("dd.MM.yyyy"), dataWyp.ToString("dd.MM.yyyy")))
            {
                dataWypożyczenia = dataWyp;
                dataZwrotu = dataZwr;
                liczbaDni = dataZwr - dataWyp;
                cena = s.Stawka * liczbaDni.Days;
            }
            else
            {
                Console.WriteLine("Błąd!");
            }
        }

        [Key] public int wypozyczenieId { get; set; }

        public virtual Wypożyczenie wypozyczenieBaza { get; set; }

        public DateTime DataWypożyczenia
        {
            get => dataWypożyczenia;
            set => dataWypożyczenia = value;
        }

        public DateTime DataZwrotu
        {
            get => dataZwrotu;
            set => dataZwrotu = value;
        }

        public void ZapiszXML(string nazwa, Samochód s)
        ///<summary>
        /// Serializacja do XML.
        /// </summary>
        {
            var serializer = new XmlSerializer(typeof(Samochód));
            var sw = new StreamWriter(nazwa);
            serializer.Serialize(sw, s);
            sw.Close();
        }

        public object OdczytajXML(string nazwa)
        ///<summary>
        /// Odczyt z XML.
        /// </summary>
        {
            var serializer = new XmlSerializer(typeof(Samochód));
            var sr = new StreamReader(nazwa);
            var wynik = (Samochód)serializer.Deserialize(sr);
            sr.Close();
            return wynik;
        }

        public void ZapiszJSON(string nazwa)
        ///<summary>
        /// Serializacja do JSON.
        /// </summary>
        {
            var json = new JavaScriptSerializer().Serialize(this);
            using (var sw = new StreamWriter(nazwa))
            {
                sw.Write(json);
            }
        }

        public object OdczytajJSON(string nazwa)
        ///<summary>
        /// Odczyt z JSON.
        /// </summary>
        {
            string json;
            using (var sr = new StreamReader(nazwa))
            {
                json = sr.ReadLine();
            }

            return json;
        }

        public override string ToString()
        {
            return "WYPOŻYCZENIE numer: " + numer + ", samochód: " + auto + ", \nklient: " + klient +
                   ", \nczas wypożyczenia: " + dataWypożyczenia.ToShortDateString() + " - " +
                   DataZwrotu.ToShortDateString();
        }

        public void DodajDoListy(Wypożyczenie w)
        {
            listaWypożyczeń.Add(w);
            liczbaWypożyczeń++;
        }

        public void UsuńZListy(Wypożyczenie w)
        {
            listaWypożyczeń.Remove(w);
            liczbaWypożyczeń--;
        }

        public void ZapiszDoBazy()
        ///<summary>
        /// Zapis do bazy danych.
        /// </summary>
        {
            using (var db = new Model1())
            {
                db.Wypożyczenies.Add(this);
                db.SaveChanges();
            }
        }

        public Wypożyczenie OdczytZBazy()
        ///<summary>
        /// Odczyt z bazy danych.
        /// </summary>
        {
            using (var db = new Model1())
            {
                return db.Wypożyczenies.FirstOrDefault();
            }
        }
    }

}
