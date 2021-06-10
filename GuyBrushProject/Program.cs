using GuyBrushProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private const string cheminTXT = ("../../../../Cartes/");

        static void Main(string[] args)
        {
            bool existClair=false, existChiffre=false;
            string choixUser;
            IEnumerable<String> fichiers = Directory.EnumerateFiles(cheminTXT).Where(fichier => fichier.EndsWith(".clair") || fichier.EndsWith(".chiffre"));

            Console.WriteLine("Quel fichier voulez vous traduire ?\n");
            foreach (string fichier in fichiers)
            {
                Console.WriteLine("{0}\n", (fichier.Substring(fichier.LastIndexOf("/") + 1)));
            }
            Console.Write("\nChoix : ");
            choixUser = Console.ReadLine();

            if (choixUser.EndsWith(".clair")) choixUser = choixUser.Replace(".clair","");
            else if (choixUser.EndsWith(".chiffre")) choixUser = choixUser.Replace(".chiffre","");
            
            foreach (string fichier in fichiers)
            {
                if ((fichier == cheminTXT + choixUser + ".clair")) existClair = true;
                else if ((fichier == cheminTXT + choixUser + ".chiffre")) existChiffre = true;
            }

            Console.WriteLine("\n");
            if (existClair == true && existChiffre == false)
            {
                choixUser += ".clair";
            }
            else if (existClair == false && existChiffre == true)
            {
                choixUser += ".chiffre";
                Traduction carte = new Traduction(choixUser);
                Dechiffrage.SplitChiffre(Traduction.Lecture(choixUser));
                Dechiffrage.Affichage();
            }
            else if (existClair == true && existChiffre == true)
            {
                Console.WriteLine("La carte existe deja dans les deux formats.");
            }
            else 
            {
                Console.WriteLine("Choix non valide.");
            }
        }
    }
}