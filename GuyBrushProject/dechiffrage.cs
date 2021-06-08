using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Dechiffrage : Traduction
    {
        const string adresseCarte = ("../../../../Cartes/");
        string nomIle;

        public Dechiffrage(string nom):base(nom)
        {
            nomIle = nom;
        }



        public void dechiffrage()
        {
            try
            {
                File.Copy(adresseCarte + nomIle, adresseCarte + nomIle.Replace(".chiffre", ".clair"));


                string line = null;
                List<string> lines = new List<string>();
                StreamReader lecture = new StreamReader(adresseCarte + nomIle.Replace(".chiffre", ".clair"));
                for (int i = 0; i < lines.Count; i++)
                {
                    lines.Add(line);
                }
                lecture.Close();


                for (int i = 1; i <= 10; i++)
                {
                    lines[i].Replace("|", "\n");
                }



                StreamWriter ecriture = new StreamWriter(adresseCarte + nomIle.Replace(".chiffre", ".clair"));
                for (int i = 0; i < lines.Count; i++)
                {
                    if (i < lines.Count - 1) Console.WriteLine(lines[i]);
                    else Console.Write(lines[i]);
                }
                ecriture.Close();



                lecture = new StreamReader(adresseCarte + nomIle.Replace(".chiffre", ".clair"));
                while ((line = lecture.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                lecture.Close();
            }
            catch
            {
                Console.WriteLine("ERREUR : Fichier ne correspondant pas aux normes du traducteur.\n");
            }


            /*StreamWriter ecriture = new StreamWriter(adresseCarte + nomIle + ".clair");
            ecriture.WriteLine(ecriture);

            lecture.Close(); ecriture.Close*/
        }
    }
}
