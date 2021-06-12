using GuyBrushProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        
        private const string cheminTXT = ("../../../../Cartes/"); // chemin d'adresse relatif

        static void Main(string[] args)
        {
            //delete(("../../../../Cartes/monhumour.chiffre"));
            //delete(("../../../../Cartes/test.chiffre"));
            bool existClair=false, existChiffre=false; // pour vérifier si une traduction existe déjà
            string choixUser;
            IEnumerable<String> fichiers = Directory.EnumerateFiles(cheminTXT).Where(fichier => fichier.EndsWith(".clair") || fichier.EndsWith(".chiffre")); // 'liste' de tous les fichiers présents dans cheminTXT
            Console.WriteLine("Quel fichier voulez vous traduire ?\n");
            
            // affichage de la précédente 'liste'
            foreach (string fichier in fichiers)
            {
                if (fichier.EndsWith(".clair"))
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("{0}\n", (fichier.Substring(fichier.LastIndexOf("/") + 1)));
                Console.ResetColor();
            }

            Console.Write("\nChoix : ");
            choixUser = Console.ReadLine(); // entrée du choix du joueur

            // effacement de l'extension, si elle est tapée par l'utilisateur
            if (choixUser.EndsWith(".clair")) choixUser = choixUser.Replace(".clair","");
            else if (choixUser.EndsWith(".chiffre")) choixUser = choixUser.Replace(".chiffre","");
            
            // vérification d'une éventuelle traduction déjà existante
            foreach (string fichier in fichiers)
            {
                if ((fichier == cheminTXT + choixUser + ".clair")) existClair = true;
                else if ((fichier == cheminTXT + choixUser + ".chiffre")) existChiffre = true;
            }

            // lancement du codage
            Console.WriteLine("\n");
            if (existClair == true && existChiffre == false)
            {
                choixUser += ".clair";
                Traduction carte = new Traduction(choixUser);
                StreamWriter ecriture = new StreamWriter(cheminTXT + choixUser.Replace(".clair", ".chiffre"));
                Chiffrage.SplitTab(Chiffrage.Lecture(choixUser));
                ecriture.Close();
                //Chiffrage.SplitTab(Traduction.Lecture(choixUser));
                //Chiffrage.Affichage();
            }

            // lancement du décodage
            else if (existClair == false && existChiffre == true)
            {
                choixUser += ".chiffre";
                Traduction carte = new Traduction(choixUser);
                Dechiffrage.SplitChiffre(Dechiffrage.Lecture(choixUser));
                Dechiffrage.Affichage();
            }

            // traduction déjà existante
            else if (existClair == true && existChiffre == true)
            {
                Console.WriteLine("La carte existe deja dans les deux formats.");
            }

            // choix de l'utilisateur non valide
            else 
            {
                Console.WriteLine("Choix non valide.");
            }

        }
        public static void delete(string chemin)// supprime le fichier correspondant au parametre.
        {
            try
            {
                if (File.Exists(chemin))
                {
                    File.Delete(chemin);
                    Console.WriteLine($"{chemin} a ete supprimer avec succes!");
                }
                else
                    Console.WriteLine("Le fichier n'existe pas!");
                    
            }
            catch(Exception E)
            {
                Console.WriteLine(" Pas de fichier ou erreur");
            }
        }



    }
}