using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    public class Traduction
    {
        const string cheminTXT = ("../../../../Cartes/");
        string ligne;
        public void Dechiffrage(string nFile)
        {
            try
            {
                StreamReader lecture = new StreamReader(cheminTXT + nFile + ".chiffre");
                StreamWriter ecriture = new StreamWriter(cheminTXT + nFile + ".clair");
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
