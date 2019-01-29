using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia_Samochodów
{
    /// <summary>
    /// W tej klasie tworzymy obiekty samochodów.
    /// Ze względu na specyfikę środowiska, wystąpiła konieczność ręcznego wymuszenia metody Clone().
    /// </summary>
    
    [Serializable]
   
    public enum Marka { BMW, Audi, MercedesBenz, Porsche, Nissan }
    public enum ZródłoMocy { benzyna, diesel }
    public class Samochód:object
    {
        [Key]
        public int samochódId { get; set; }

        private string model;
        private double stawka;
        private Marka marka;
        private string nrRejestracyjny;
        private ZródłoMocy silnik;

        public string Model { get => model; set => model = value; }
        public double Stawka { get => stawka; set => stawka = value; }
        public Marka Marka { get => marka; set => marka = value; }
        public string NrRejestracyjny { get => nrRejestracyjny; set => nrRejestracyjny = value; }
        public ZródłoMocy Silnik { get => silnik; set => silnik = value; }

        public Samochód(Marka marka, string model, double stawka, ZródłoMocy silnik, string nrRejestracyjny)
        {
            this.Model = model;
            this.Stawka = stawka;
            this.Silnik = silnik;
            this.Marka = marka;
            this.NrRejestracyjny = nrRejestracyjny;
        }

        public override string ToString()
        {
            return "Marka: " + Marka +", Model: " + Model+ ", Silnik: " + Silnik+", Cena za dobę: " + Stawka;
        }

        public object Clone()
        ///<summary>
        /// Zazwyczaj tego w ogóle nie trzeba pisać, ale w tym projekcie trzeba było wymusić klonowanie w ten sposób.
        /// </summary>
        {
            return MemberwiseClone();
        }
    }
}
