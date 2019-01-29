using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia_Samochodów
{
    interface IZapisywalna
    {
        void ZapiszXML(string nazwa, Samochód s);
        object OdczytajXML(string nazwa);
        void ZapiszJSON(string nazwa);
        object OdczytajJSON(string nazwa);
    }
}
