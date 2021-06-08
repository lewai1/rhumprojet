using GuyBrushProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        const string cheminTXT = ("../../../../Cartes/");

        static void Main(string[] args)
        {
            bool existClair=false, existChiffre=false; // Tradution non faite si déjà existante
            string choixUser;
            IEnumerable<String> fichiers = Directory.EnumerateFiles(cheminTXT).Where(fichier => fichier.EndsWith(".clair") || fichier.EndsWith(".chiffre"));

            Console.WriteLine("Quel fichier voulez vous traduire ?\n");
            foreach (string fichier in fichiers)
            {
                Console.WriteLine("{0}\n", (fichier.Substring(fichier.LastIndexOf("/") + 1)));
            }
            Console.Write("\nChoix : ");
            choixUser = Console.ReadLine();
            foreach (string fichier in fichiers)
            {
                if (fichier == cheminTXT + choixUser + ".clair")
                {
                    existClair = true; 
                }
                if (fichier == cheminTXT + choixUser + ".chiffre")
                {
                    existChiffre = true;
                }
            }
            if(existClair == true && existChiffre == false)
            {
                choixUser += ".clair";
                Chiffrage carte = new Chiffrage(choixUser);
                carte.chiffrage();
            }
            else if (existClair == false && existChiffre == true)
            {
                choixUser += ".chiffre";
                Dechiffrage carte = new Dechiffrage(choixUser);
                carte.dechiffrage();
            }
            else if (existClair == true && existChiffre == true)
            {
                Console.WriteLine("\nLa carte existe deja dans les deux formats.");
            }
            else if (choixUser.EndsWith(".clair"))
            {
                Chiffrage carte = new Chiffrage(choixUser);
                carte.chiffrage();

            }
            else if (choixUser.EndsWith(".chiffre"))
            {
                Dechiffrage carte = new Dechiffrage(choixUser);
                carte.dechiffrage();
            }
            else 
            {
                Console.WriteLine("\nChoix non valide.");
            }
        }
    }
}