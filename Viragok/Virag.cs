using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragok
{
    internal class Virag
    {
        public string _fajta;
        public double _ar;
        public string _szin;
        public string _fajl;

        public Virag(string fajta, double ar, string szin, string fajl)
        {

            _fajta = fajta;
            _ar = ar;
            _szin = szin;
            _fajl = fajl;
        }
        public Virag(string sor)
        {
            var adatok = sor.Split(';').ToList();
            _fajta = adatok[0];
            _ar = double.Parse(adatok[1]);
            _szin = adatok[2];
            _fajl = adatok[3];
        }
    }
}
