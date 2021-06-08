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
            int nbFichier = 1, choixUser;
            string cheminTXT = ("../../../../Cartes/");

            IEnumerable<String> fichiers = Directory.EnumerateFiles(cheminTXT).Where(fichier => fichier.EndsWith(".clair") || fichier.EndsWith(".chiffre"));

            Console.WriteLine("Quel fichier voulez vous traduire ?\n");
            foreach (string fichier in fichiers)
            {
                Console.WriteLine("{0} : {1}\n", nbFichier++, (fichier.Substring(fichier.LastIndexOf("/") + 1)));
            }
            Console.Write("Choix : ");

            try
            {
                choixUser = Convert.ToInt32(Console.ReadLine()) - 1; // -1 pour faire correspondre le choix du joueur avec la numérotation de la liste fichiers
                while ((choixUser < 0) || (choixUser > nbFichier - 2))
                {
                    Console.Write("Veuillez faire un choix valide : ");
                    choixUser = Convert.ToInt32(Console.ReadLine()) - 1;
                }
            }
            catch
            {
                Console.WriteLine("\nERREUR : Valeur non valide");
            }


            foreach (string fichier in fichiers)
            {
                if (fichier.EndsWith(".clair")) Console.WriteLine("ok");
                else if (fichier.EndsWith(".chiffre")) Console.WriteLine("ko");
                else Console.WriteLine("soucis !");
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