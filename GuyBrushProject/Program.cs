using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbFichier = 1, choixUser;
            string cheminTXT = ("../../../../../Cartes/");
            string[] fichiers = Directory.GetFiles(cheminTXT, "*.txt");
            Console.WriteLine("Quel fichier voulez vous traduire ?\n");
            foreach (string fichier in fichiers)
            {
                Console.WriteLine("{0} : {1}\n", nbFichier++, (fichier.Substring(fichier.LastIndexOf("/") + 1)));
            }
            Console.Write("Choix : ");
            choixUser = Convert.ToInt32(Console.ReadLine()) - 1; // -1 pour faire correspondre le choix du joueur avec la numérotation de la liste fichiers

            while ((choixUser < 0) || (choixUser > nbFichier - 2))
            {
                Console.Write("Veuillez faire un choix valide : ");
                choixUser = Convert.ToInt32(Console.ReadLine()) - 1;
            }


            if (fichiers[choixUser].Contains(".clair")) Console.WriteLine("ok");
            else if (fichiers[choixUser].Contains(".chiffre")) Console.WriteLine("ko");
            else Console.WriteLine("ni ko ni ok");




            /*StreamWriter sw;
            sw = new StreamWriter("../../../../test.txt");
            sw.WriteLine("test de texte/nle retour à la ligne fonctionne-t-il ?/nBonne question...");
            sw.Close();*/
        }
    }
}


// Proposer au lancement du programme de choisir le fichier à convertir parmi les .txt présents dans le dossier grâce à Path.GetFileName

// 