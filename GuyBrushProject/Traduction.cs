using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Traduction
    {
        protected static string nomIle;
        protected const string cheminTXT = ("../../../../Cartes/");

        public Traduction(string n)
        {
            nomIle = n;
        }

        public static string Lecture(string n)
        {
            string line;
            nomIle = n;
            StreamReader lecture = new StreamReader(cheminTXT + nomIle);
            line = lecture.ReadLine();
            lecture.Close();
            return line;
        }
    }
}
