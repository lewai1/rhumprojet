using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey yo World");

            StreamWriter writer = new StreamWriter("../test.txt");
            StreamWriter.Write("test de texte\nle retour à la ligne fonctionne-t-il ?\nBonne question...");
            writer.Close();
        }
    }
}


// Proposer au lancement du programme de choisir le fichier à convertir parmi les .txt présents dans le dossier.