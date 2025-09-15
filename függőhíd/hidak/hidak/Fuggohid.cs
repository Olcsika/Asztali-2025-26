using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace hidak
{
    class Fuggohid
    {
        public int helyezes;
        public string nev;
        public string folrajzhely;
        public string orszag;
        public int hossz;
        public int atadev;

        public Fuggohid(string sor)
        {
            string[] vag = sor.Split("\t");
            this.helyezes = int.Parse(vag[0]);
            this.nev = vag[1];
            this.folrajzhely = vag[2];
            this.orszag = vag[3];
            this.hossz = int.Parse(vag[4]);
            this.atadev = int.Parse(vag[5]);
            
        }
    }
}
