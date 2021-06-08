using System;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Mer : Parcelle
    {
        private char lettreParc;
        private int nbInfo;

        public Mer(int nb) : base(nb)
        {
            lettreParc = 'M';
            nbInfo = nb;
        }
    }
}
