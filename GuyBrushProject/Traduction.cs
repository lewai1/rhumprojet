using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Traduction
    {
        protected static string nomIle;
        protected const string cheminTXT = ("../../../../Cartes/");

        // constructeur Traduction
        public Traduction(string n)
        {
            nomIle = n;
        }
    }
}
