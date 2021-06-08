using System;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Parcelle
    {
        private string lettreParc = "a";
        private int nbInfo;
        private int i = 1 ;

        public Parcelle(int nb)
        {
            lettreParc += 1;
            nbInfo = nb;
        }
    }
}
