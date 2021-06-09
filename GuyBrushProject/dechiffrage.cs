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


                string line;
                StreamReader lecture = new StreamReader(adresseCarte + nomIle.Replace(".chiffre", ".clair"));
                line = lecture.ReadLine();
                lecture.Close();


                line += "//";

                foreach(int i in line)
                {
                    if (i >= 64)
                    {
                        line += "MM";

                    }
                    if (i >= 32)
                    {

                    }
                    if (i >= 16)
                    {

                    }
                    if (i >= 8)
                    {

                    }
                    if (i >= 4)
                    {

                    }
                    if (i >= 2)
                    {

                    }
                    if (i >= 1)
                    {

                    }
                }

                string[] lines = line.Split('|');








                StreamWriter ecriture = new StreamWriter(adresseCarte + nomIle.Replace(".chiffre", ".clair"));
                foreach (string x in lines)
                {
                    ecriture.WriteLine(x);
                }
                ecriture.Close();


                



                /*lecture = new StreamReader(adresseCarte + nomIle.Replace(".chiffre", ".clair"));
                while ((line = lecture.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                lecture.Close();*/
            }
            catch
            {
                Console.WriteLine("ERREUR : Fichier ne correspondant pas aux normes du traducteur.\n");
            }
        }
    }
}
