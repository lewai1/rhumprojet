using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    /// <summary>
    /// Heritage de la classe Traduction
    /// </summary>
    class Dechiffrage : Traduction
    {
        #region Constructeur
        public Dechiffrage(string n) : base(n)
        {

        }

        /// <summary>
        /// Méthode Lecture, permettant de lire dans un fichier (.txt, .clair, .chiffre, etc) la première ligne de texte et de la retourner
        /// </summary>
        /// <param name="n">Variable contenant le nom des iles</param>
        public static string Lecture(string n)
        {
            string line;
            nomIle = n;
            StreamReader lecture = new StreamReader(cheminTXT + nomIle);
            line = lecture.ReadLine(); // Copie le texte du fichier mis en argument de la méthode vers line
            lecture.Close(); // Fermeture pour libérer la mémoire
            return line;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthodes pour séparer une chaîne dans le tableau valeurUnite à chaque ':' pour colonne et '|' pour ligne
        /// </summary> 
        public static void SplitChiffre(string s)
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
                if (c != ':' && c != '|') valeurCase[ligne, colonne] = valeurCase[ligne, colonne] + c; // entrée des valeurs de la séquence dans leur place du tableau
            }
            ConversionStringInt(valeurCase);
        }

        /// <summary>
        /// Méthodes pour transposer le tableau de string valeurUniteString dans le tableau valeurUniteInt
        /// </summary>
        public static void ConversionStringInt(string[,] valeurUniteString)
        {
            int[,] valeurUniteInt = new int[10, 10];
            int idUnite = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    idUnite++;
                    valeurUniteInt[i, j] = Int32.Parse(valeurUniteString[i, j]);
                    TradChiffre(valeurUniteInt[i, j], idUnite);
                }
            }
        }
        /// <summary>
        /// Liste pour les cases
        /// </summary>
        public static List<Case> cases = new List<Case>();

        /// <summary>
        /// Méthode pour traduire les nombres de la carte chiffree
        /// </summary>
        public static void TradChiffre(int val, int id)
        {
            char type = 'P';
            bool frtE = false, frtS = false, frtO = false, frtN = false; 
            if ((val / 64) == 1) // 2^6
            { 
                type = 'M';
                val -= 64;
            }
            if ((val / 32) == 1) // 2^5
            {
                type = 'F';
                val -= 32;
            }
            if ((val / 8) == 1) // 2^3
            {
                val -= 8;
                frtE = true;
            }
            if ((val / 4) == 1) // 2^2
            {
                val -= 4;
                frtS = true;
            }
            if ((val / 2) == 1) // 2^1
            {
                val -= 2;
                frtO = true;
            }
            if ((val / 1) == 1) // 2^0
            {
                val -= 1;
                frtN = true;
            }
            /// <summary>
            /// Nouvelle case dans la liste
            /// </summary>
            Case nvlCase = new Case(id, 0, type, frtE, frtS, frtO, frtN);
            cases.Add(nvlCase);
        }

        /// <summary>
        /// Méthode d'affichage dans la console et dans le fichier traduit de la traduction
        /// </summary>
        public static void Affichage()
        {
            StreamWriter ecriture = new StreamWriter(cheminTXT + nomIle.Replace(".chiffre", ".clair"));
            for (int i = 0; i < 100; i++)
            {
                /// <summary>
                /// Parcelle de terre
                /// </summary>
                if (cases[i].GetType() == 'P')
                {
                    Console.Write(cases[i].GetIDParcelle());
                    ecriture.Write(cases[i].GetIDParcelle());
                }
                /// <summary>
                /// Parcelle de mer (ou lac)
                /// </summary>
                if (cases[i].GetType() == 'M')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("M");
                    ecriture.Write("M");
                }
                /// <summary>
                /// Parcelle de forêt
                /// </summary>
                if (cases[i].GetType() == 'F')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("F");
                    ecriture.Write("F");
                }
                /// <summary>
                /// Saut de ligne
                /// </summary>
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                    ecriture.WriteLine();
                }
                Console.ResetColor();
            }
            ecriture.Close(); // Fermeture pour libérer la mémoire
        }
        #endregion
    }
}