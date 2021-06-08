using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Dechiffrage : Traduction
    {
        const string adresseCarte = ("../../../../Cartes/");
        string nomIle;

        public Dechiffrage(string nom):base(nom)
        {
            nomIle = nom;
        }



        public void dechiffrage()
        {
            try
            {
                File.Copy(adresseCarte + nomIle, adresseCarte + nomIle.Replace(".chiffre", ".clair"));
            }
            catch
            {
                Console.WriteLine("ERREUR : Fichier ne correspondant pas aux normes du traducteur.");
            }


            /*StreamReader lecture = new StreamReader(adresseCarte + nomIle + ".chiffre");
            StreamWriter ecriture = new StreamWriter(adresseCarte + nomIle + ".clair");
            ecriture.WriteLine(ecriture);

            lecture.Close(); ecriture.Close*/
        }
    }
}
