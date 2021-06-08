using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Chiffrage : Traduction
    {
        const string adresseCarte = ("../../../../Cartes/");
        string nomIle;

        public Chiffrage(string nom) : base(nom)
        {
            nomIle = nom;
        }



        public void chiffrage()
        {
            
        }
    }
}
