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
            bool nonTrad = false; // Tradution non faite si déjà existante
            string choixUser;

            IEnumerable<String> fichiers = Directory.EnumerateFiles(cheminTXT).Where(fichier => fichier.EndsWith(".clair") || fichier.EndsWith(".chiffre"));

            Console.WriteLine("Quel fichier voulez vous traduire ?\n");
            foreach (string fichier in fichiers)
            {
                Console.WriteLine("{0}\n", (fichier.Substring(fichier.LastIndexOf("/") + 1)));
            }
            Console.Write("\nChoix : ");
            choixUser = Console.ReadLine();



            if (choixUser.EndsWith(".clair"))
            {

                foreach (string fichier in fichiers)
                {
                    if (fichier == choixUser.Replace(".clair", ".chiffre"))
                    {
                        Console.WriteLine("Un fichier chiffre de cette carte existe deja !");
                        nonTrad = true;
                    }
                }
                if (nonTrad == false)
                {
                    Dechiffrage carte = new Dechiffrage(choixUser);
                    carte.dechiffrage();
                }

            }
            else if (choixUser.EndsWith(".chiffre"))
            {
                foreach (string fichier in fichiers)
                {
                    if (fichier == choixUser.Replace(".chiffre", ".clair"))
                    {
                        Console.WriteLine("Un fichier dechiffre de cette carte existe deja !");
                        nonTrad = true;
                    }
                }
                if (nonTrad == false)
                {
                    Chiffrage carte = new Chiffrage(choixUser);
                    carte.chiffrage();
                }


            }
            else
            {
                Console.WriteLine("Choix non valide.");
            }
            



            /*StreamWriter sw;
            sw = new StreamWriter("../../../../test.txt");
            sw.WriteLine("test de texte/nle retour à la ligne fonctionne-t-il ?/nBonne question...");
            sw.Close();*/
        }
    }
}


// Proposer au lancement du programme de choisir le fichier à convertir parmi les .txt présents dans le dossier grâce à Path.GetFileName

// 