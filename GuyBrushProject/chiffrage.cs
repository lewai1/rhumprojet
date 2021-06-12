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
            string line;
            line = File.ReadAllText(cheminTXT + nomIle);
            line = line.Replace(System.Environment.NewLine, "");
            return line;
        }

        // méthodes pour faire en  une chaîne dans le tableau valeurUnite à chaque ':' pour colonne et '|' pour ligne
        public static string SplitLettre(string s)
        {
            int i;
            double j = 0;
            for (i = 10; i < 100; i+=10)
            {
                s = s.Insert(i + Convert.ToInt32(j), "|");
                j++;
            }
            for (i = 1; i < 20; i++)
            {
                if ((i % 2 != 0) && (i % (19) != 0)) s = s.Insert(i, ":");
            }
            for (i = 21; i < 39; i++)
            {
                if ((i % 2 != 0) && (i % (38) != 0)) s = s.Insert(i, ":");
            }
            for (i = 41; i < 59; i++)
            {
                if ((i % 2 != 0) && (i % (58) != 0)) s = s.Insert(i, ":");
            }
            for (i = 60; i < 79; i++)
            {
                if ((i % 2 != 0) && (i % (78) != 0)) s = s.Insert(i, ":");
            }
            for (i = 81; i < 99; i++)
            {
                if ((i % 2 != 0) && (i % (98) != 0)) s = s.Insert(i, ":");
            }
            for (i = 100; i < 119; i++)
            {
                if ((i % 2 != 0) && (i % (118) != 0)) s = s.Insert(i, ":");
            }
            for (i = 120; i < 139; i++)
            {
                if ((i % 2 != 0) && (i % (138) != 0)) s = s.Insert(i, ":");
            }
            for (i = 140; i < 159; i++)
            {
                if ((i % 2 != 0) && (i % (158) != 0)) s = s.Insert(i, ":");
            }
            for (i = 160; i < 179; i++)
            {
                if ((i % 2 != 0) && (i % (178) != 0)) s = s.Insert(i, ":");
            }
            for (i = 180; i < 199; i++)
            {
                if ((i % 2 != 0) && (i % (198) != 0)) s = s.Insert(i, ":");
            }
            return s;
        }

        public static string ConvertLettreToNb(string s)
        {
            // à faire
            return s;
        }

        public static void Affichage(string s)
        {
            StreamWriter ecriture = new StreamWriter(cheminTXT + nomIle.Replace(".clair", ".chiffre"));
            ecriture.WriteLine(s); Console.WriteLine(s);
            ecriture.Close();
        }
    }
}
