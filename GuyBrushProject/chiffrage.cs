using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    /// <summary>
    /// Heritage de la classe Traduction
    /// </summary>
    class Chiffrage : Traduction
    {
        public Chiffrage(string n) : base(n)
        {

        }
        /// <summary>
        /// Méthode Lecture, permettant de lire dans un fichier (.txt, .clair, .chiffre, etc) et de retourner le texte qu'il contient
        /// </summary>
        public static string Lecture(string n)
        {
            nomIle = n;
            string lines = File.ReadAllText(cheminTXT + nomIle);
            return lines;
        }
        /// <summary>
        /// Méthodes pour faire en  une chaîne dans le tableau valeurUnite à chaque ':' pour colonne et '|' pour ligne
        /// </summary>
        public static void SplitTab(string s)
        {
            string[,] valeurCase = new string[10, 10];
            int ligne = 0, colonne = 0;
            foreach (char c in s)
            {
                // Changement de ligne et retour à la première colonne
                if (c == '|')
                {
                    ligne++;
                    colonne = 0;
                }

                if (c == ':') colonne++; // Avancement à la colonne suivante
                if (c != ':' && c != '|') valeurCase[ligne, colonne] = valeurCase[ligne, colonne] + c; // Entrée des valeurs de la séquence dans leur place du tableau
            }
            // ConversionStringInt(valeurCase);
        }


        public static void Affichage()
        {
            
        }
    }
}
