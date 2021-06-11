using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Dechiffrage : Traduction
    {
        public Dechiffrage(string n) : base(n)
        {

        }

        // méthode Lecture, permettant de lire dans un fichier (.txt, .clair, .chiffre, etc) la première ligne de texte et de la retourner
        public static string Lecture(string n)
        {
            string line;
            nomIle = n;
            StreamReader lecture = new StreamReader(cheminTXT + nomIle);
            line = lecture.ReadLine(); // copie le texte du fichier mis en argument de la méthode vers line
            lecture.Close(); // fermeture pour libérer la mémoire
            return line;
        }

        // méthodes pour séparer une chaîne dans le tableau valeurUnite à chaque ':' pour colonne et '|' pour ligne
        public static void SplitChiffre(string s)
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
            ConversionStringInt(valeurCase);
        }

        // méthodes pour transposer le tableau de string valeurUniteString dans le tableau valeurUniteInt
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

        public static List<Case> cases = new List<Case>(); // création d'une liste pour les cases

        // méthode pour traduire les nombres de la carte chiffree
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
            Case nvlCase = new Case(id, 0, type, frtE, frtS, frtO, frtN); // nouvelle case dans la liste
            cases.Add(nvlCase);
        }

        // méthode d'affichage dans la console et dans le fichier traduit de la traduction
        public static void Affichage()
        {
            StreamWriter ecriture = new StreamWriter(cheminTXT + nomIle.Replace(".chiffre", ".clair"));
            for (int i = 0; i < 100; i++)
            {
                if (cases[i].GetType() == 'P') // parcelle de terre
                {
                    Console.Write(cases[i].GetIDParcelle());
                    ecriture.Write(cases[i].GetIDParcelle());
                }
                if (cases[i].GetType() == 'M') // parcelle de mer (ou lac)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("M");
                    ecriture.Write("M");
                }
                if (cases[i].GetType() == 'F') // parcelle de forêt
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("F");
                    ecriture.Write("F");
                }
                if ((i + 1) % 10 == 0) // saut de ligne
                {
                    Console.WriteLine();
                    ecriture.WriteLine();
                }
                Console.ResetColor();
            }
            ecriture.Close(); // fermeture pour libérer la mémoire
        }
    }
}