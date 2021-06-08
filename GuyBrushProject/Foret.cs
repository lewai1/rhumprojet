using System;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Foret : Parcelle
    {
        private char lettreParc;
        private int nbInfo;

        public Foret(int nb) : base(nb)
        {
            lettreParc = 'F';
            nbInfo = nb;
        }
    }
}
