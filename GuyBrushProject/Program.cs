using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbFichier = 1;
            bool nonTrad = false; //
            string choixUser;
            const string cheminTXT = ("../../../../Cartes/");

            IEnumerable<String> fichiers = Directory.EnumerateFiles(cheminTXT).Where(fichier => fichier.EndsWith(".clair") || fichier.EndsWith(".chiffre"));

            Console.WriteLine("Quel fichier voulez vous traduire ?\n");
            foreach (string fichier in fichiers)
            {
                Console.WriteLine("{0} : {1}\n", nbFichier++, (fichier.Substring(fichier.LastIndexOf("/") + 1)));
            }
            Console.Write("Choix : ");

            Console.Write("Veuillez faire un choix valide : ");
            choixUser = Console.ReadLine();


            if (choixUser.EndsWith(".clair"))
            {

                foreach (string fichier in fichiers)
                {
                    if (fichier == choixUser +".chiffre")
                    {
                        Console.WriteLine("Un fichier chiffre de cette carte existe deja !");
                        nonTrad = true;
                    }
                }
                if (nonTrad == false)
                {
                    dechiffrage.Dechiffrage(choixUser);

                }

            }
            else if (choixUser.EndsWith(".chiffre"))
            {
                foreach (string fichier in fichiers)
                {
                    if (fichier == choixUser + ".clair")
                    {
                        Console.WriteLine("Un fichier dechiffre de cette carte existe deja !");
                        nonTrad = true;
                    }
                }
                if (nonTrad == false)
                {
                    chiffrage.Chiffrage(choixUser);

                }


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