using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Chiffrage : Traduction
    {
        #region Constructeur
        public Chiffrage(string n) : base(n)
        {

        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthodes qui met dans un string la carte clair en mettant toutes les lettre sur une seule ligne
        /// </summary>
        public static string Lecture(string n)
        {
            nomIle = n;
            string line;
            line = File.ReadAllText(cheminTXT + nomIle);
            line = line.Replace(System.Environment.NewLine, "");
            return line;
        }

        /// <summary>
        /// La méthode qui code les lettres de la carte .clair en nombres et qui ajoute ':' entre chaque caractère et '|' tous les 10 caractères
        /// </summary>
        public static string SplitAndConvert(string s)
        {
            int i; int j = 0;
            char[] LettresArray = s.ToCharArray(); // Création d'un tableau unidimensionnel pour y tranférer chaque lettre de s
            s = "";
            for (i = 0; i < 100; i++)
            {
                if(LettresArray[i]=='M') s += "64"; // si case mer(ou lac)
                else if (LettresArray[i] == 'F') s+= "32"; // si case foret
                else  s += "15"; // si case terre (non foret)
                if ((i % (9 + j) == 0) && (i != 0))
                {
                    s += "|";
                    j += 10;
                }
                else if (i != 99) s += ":";
            }
            return s;
        }
        /// <summary>
        /// Méthode d'affichage dans la console et dans le fichier créer.
        /// </summary>
        public static void Affichage(string s)
        {
            StreamWriter ecriture = new StreamWriter(cheminTXT + nomIle.Replace(".clair", ".chiffre"));
            ecriture.WriteLine(s); Console.WriteLine(s);
            ecriture.Close();
        }
        #endregion
    }
}
