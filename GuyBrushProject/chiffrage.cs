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
            try
            {
                StreamReader lecture = new StreamReader(adresseCarte + nomIle + ".clair");
                StreamWriter ecriture = new StreamWriter(adresseCarte + nomIle + ".chiffre");
                ecriture.WriteLine(ecriture);

                lecture.Close(); ecriture.Close();
            }
            catch
            {
                Console.WriteLine("ERREUR : Fichier ne correspondant pas aux normes du traducteur.");
            }
        }
    }
}
