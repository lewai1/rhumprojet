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
        #region Constructeur
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
<<<<<<< HEAD
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthodes pour faire en  une chaîne dans le tableau valeurUnite à chaque ':' pour colonne et '|' pour ligne
        /// </summary>
        public static string SplitLettre(string s)
=======
        /// <summary>
        /// Méthodes pour faire en  une chaîne dans le tableau valeurUnite à chaque ':' pour colonne et '|' pour ligne
        /// </summary>
        public static void SplitTab(string s)
>>>>>>> parent of f28ba28 (Chiffrage bancal :/ et ajustements)
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
<<<<<<< HEAD
            return s;
<<<<<<< HEAD
            
=======
            // ConversionStringInt(valeurCase);
=======
>>>>>>> parent of f9aea45 (Last version)
        }
        public static void chiffrage(string id)
        {

>>>>>>> parent of f28ba28 (Chiffrage bancal :/ et ajustements)
        }

        // méthode Lecture, permettant de lire dans un fichier (.txt, .clair, .chiffre, etc) la première ligne de texte et de la retourner
        public static string lectureClair(string n)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            
=======
            // à faire
>>>>>>> parent of f9aea45 (Last version)
            return s;
        }


        /// <summary>
        /// Méthode d'affichage dans la console
        /// </summary>
        public static void Affichage(string s)
=======
            string line;
            nomIle = n;
            StreamReader lecture = new StreamReader(cheminTXT + nomIle);
            line = lecture.ReadLine(); // copie le texte du fichier mis en argument de la méthode vers line
            lecture.Close(); // fermeture pour libérer la mémoire
            return line;
        }


        public static void Affichage()
>>>>>>> parent of f28ba28 (Chiffrage bancal :/ et ajustements)
        {
            StreamWriter ecriture = new StreamWriter(cheminTXT + nomIle.Replace(".chiffre", ".clair"));
            for (int i = 0; i < 100; i++)
            {

            }


        }
<<<<<<< HEAD
        #endregion
=======
        /*Note pour Moi (louca) dans le code pour pas que ca sois relou a aller chercher.
         * Le code doit -- Lire le fiuc
         * 
         * 
         */
>>>>>>> parent of f28ba28 (Chiffrage bancal :/ et ajustements)
    }
}
