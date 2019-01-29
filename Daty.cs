using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia_Samochodów
{
    ///<summary>
    /// W tej klasie mamy tylko metodę, odpowiadającą za poprawność wprowadzanych dat.
    /// Argumentami metody są dwie daty: zwrotu samochodu, jeśli jest już zarezerwowany,
    /// oraz żądana data wypożyczenia.
    /// Metoda sprawdza, czy wypożyczenia potencjalnie nie zachodzą na siebie.
    /// <return>Zwraca true, jeśli można od podanej daty wypożyczyć dany samochoód,
    /// oraz false, jeśli nie można go wypożyczyć.</return>
    /// </summary>
    /// 
    class Daty :Wypożyczenie
    {
        private static int d1, d2, m1, m2, r1, r2;
        public static bool ZakresDat(string dataZwr, string dataSpr)
        {
            d1 = Convert.ToInt32((dataZwr.Split('.'))[0]);
            m1 = Convert.ToInt32((dataZwr.Split('.'))[1]);
            r1 = Convert.ToInt32((dataZwr.Split('.'))[2]);

            d2 = Convert.ToInt32((dataSpr.Split('.'))[0]);
            m2 = Convert.ToInt32((dataSpr.Split('.'))[1]);
            r2 = Convert.ToInt32((dataSpr.Split('.'))[2]);


            DateTime sprawdź = new DateTime(r1, m1, d1);
            DateTime koniec = new DateTime(r2, m2, d2);

            if (sprawdź > koniec)
                return true;    //można wypożyczać, nie zachodzi na inne wypożyczenie
            else
                return false;     //znajduje się w zakresie innego wypożyczenia
        }
    }
}
