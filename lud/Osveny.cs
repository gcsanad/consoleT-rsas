using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lud
{
    internal class Osveny
    {
        string beolvas;
        public Osveny(string sor)
        {
            string[] feloszt = sor.Split(' ');
            this.beolvas = feloszt[0];
        }

        public string Beolvas { get => beolvas; }
    }
}
