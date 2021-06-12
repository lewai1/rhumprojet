using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    
    class Chiffrage : Traduction
    {
        public Chiffrage(string n) : base(n)
        {

        }

        // méthode Lecture, permettant de lire dans un fichier (.txt, .clair, .chiffre, etc) et de retourner le texte qu'il contient
        public static string Lecture(string n)
        {
            nomIle = n;
            string lines = File.ReadAllText(cheminTXT + nomIle);
            return lines;
        }

        // méthodes pour faire en  une chaîne dans le tableau valeurUnite à chaque ':' pour colonne et '|' pour ligne
        public static void SplitTab(string s)
        {
            string[,] valeurCase = new string[10, 10];
            int ligne = 0, colonne = 0;
            foreach (char c in s)
            {
                // changement de ligne et retour à la première colonne
                if (c == '|')
                {
                    ligne++;
                    colonne = 0;
                }

                if (c == ':') colonne++; // avancement à la colonne suivante
                if (c != ':' && c != '|') valeurCase[ligne, colonne] = valeurCase[ligne, colonne] + c; // entrée des valeurs de la séquence dans leur place du tableau
            }
            //ConversionStringInt(valeurCase);
        }
        public static void chiffrage(string id)
        {

        }

        // méthode Lecture, permettant de lire dans un fichier (.txt, .clair, .chiffre, etc) la première ligne de texte et de la retourner
        public static string lectureClair(string n)
        {
            string line;
            nomIle = n;
            StreamReader lecture = new StreamReader(cheminTXT + nomIle);
            line = lecture.ReadLine(); // copie le texte du fichier mis en argument de la méthode vers line
            lecture.Close(); // fermeture pour libérer la mémoire
            return line;
        }


        public static void Affichage()
        {
            StreamWriter ecriture = new StreamWriter(cheminTXT + nomIle.Replace(".chiffre", ".clair"));
            for (int i = 0; i < 100; i++)
            {

            }


        }
        /*Note pour Moi (louca) dans le code pour pas que ca sois relou a aller chercher.
         * Le code doit -- Lire le fiuc
         * 
         * 
         */
    }
}
