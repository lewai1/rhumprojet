using GuyBrushProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{

    /// <summary>
    /// Modelise le programme
    /// </summary>
    class Program
    {
        #region Attributs

        /// <summary>
        /// Chemin relatif des cartes
        /// </summary>
        private const string cheminTXT = ("../../../../Cartes/");
        #endregion

        #region Constructeur
        static void Main(string[] args)
        {
            //delete(("../../../../Cartes/monhumour.chiffre"));
            //delete(("../../../../Cartes/test.chiffre"));
            bool existClair=false, existChiffre=false; // pour vérifier si une traduction existe déjà
            string choixUser;
            IEnumerable<String> fichiers = Directory.EnumerateFiles(cheminTXT).Where(fichier => fichier.EndsWith(".clair") || fichier.EndsWith(".chiffre")); // 'liste' de tous les fichiers présents dans cheminTXT
            Console.WriteLine("Quel fichier voulez vous traduire ?\n");
            
            // Affichage de la précédente 'liste'
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

            /// <summary>
            /// Effacement de l'extension, si elle est tapée par l'utilisateur
            /// </summary>
            if (choixUser.EndsWith(".clair")) choixUser = choixUser.Replace(".clair","");
            else if (choixUser.EndsWith(".chiffre")) choixUser = choixUser.Replace(".chiffre","");

            /// <summary>
            /// Vérification d'une éventuelle traduction déjà existante
            /// </summary>
            foreach (string fichier in fichiers)
            {
                if ((fichier == cheminTXT + choixUser + ".clair")) existClair = true;
                else if ((fichier == cheminTXT + choixUser + ".chiffre")) existChiffre = true;
            }

            /// <summary>
            /// Lancement du codage
            /// </summary>
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

            /// <summary>
            /// Lancement du décodage
            /// </summary>
            else if (existClair == false && existChiffre == true)
            {
                choixUser += ".chiffre";
                Traduction carte = new Traduction(choixUser);
                Dechiffrage.SplitChiffre(Dechiffrage.Lecture(choixUser));
                Dechiffrage.Affichage();
            }

            /// <summary>
            /// Si traduction déjà existante
            /// </summary>
            else if (existClair == true && existChiffre == true)
            {
                Console.WriteLine("La carte existe deja dans les deux formats.");
            }

            /// <summary>
            /// Choix de l'utilisateur non valide
            /// </summary>
            else
            {
                Console.WriteLine("Choix non valide.");
            }

        }
        #endregion
<<<<<<< HEAD

<<<<<<< HEAD
=======
        #region Méthodes
        /// <summary>
        /// Supprime le fichier qui correspond au paramètre 
        /// </summary>
        public static void delete(string chemin)// supprime le fichier correspondant au parametre.
        {
            try
            {
                if (File.Exists(chemin))
                {
                    File.Delete(chemin);
                    Console.WriteLine($"{chemin} a ete supprime avec succes!");
                }
                else
                    Console.WriteLine("Le fichier n'existe pas!");
                    
            }
            catch(Exception E)
            {
                Console.WriteLine("Pas de fichier ou erreur");
            }
        }

        #endregion

>>>>>>> parent of f28ba28 (Chiffrage bancal :/ et ajustements)
=======
>>>>>>> parent of f9aea45 (Last version)
    }
}