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

        // méthode Lecture, permettant de lire dans un fichier (.txt, .clair, .chiffre, etc) le texte
        public static string Lecture(string n)
        {
            string line;
            nomIle = n;
            StreamReader lecture = new StreamReader(cheminTXT + nomIle);
            line = lecture.ReadLine(); // copie le texte du fichier mis en argument de la méthode vers line
            lecture.Close(); // fermeture pour libérer la mémoire
            return line;
        }
    }
}
