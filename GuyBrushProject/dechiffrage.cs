using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Dechiffrage : Traduction
    {
        public Dechiffrage(string n) : base(n)
        {

        }

        // méthodes pour séparer une chaîne dans le tableau valeurUnite à chaque ':' pour colonne et '|' pour ligne
        public static void SplitChiffre(string s)
        {
            string[,] valeurUnite = new string[10, 10];
            int ligne = 0, colonne = 0;
            foreach (char c in s)
            {
                if (c == '|')
                {
                    ligne++;
                    colonne = 0;
                }
                if (c == ':') colonne++;
                if (c != ':' && c != '|') valeurUnite[ligne, colonne] = valeurUnite[ligne, colonne] + c;
            }
            ConversionStringInt(valeurUnite);
        }

        // méthodes pour transposer le tableau de string valeurUniteString dans le tableau valeurUniteInt
        public static void ConversionStringInt(string[,] valeurUniteString)
        {
            int[,] valeurUniteInt = new int[10, 10];
            int idUnite = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    idUnite++;
                    valeurUniteInt[i, j] = Int32.Parse(valeurUniteString[i, j]);
                    TradChiffre(valeurUniteInt[i, j], idUnite);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                DefinitionParcelle();
            }
        }

        public static List<Case> cases = new List<Case>(); // création d'une liste pour les cases

        // méthode pour traduire les nombres de la carte chiffree
        public static void TradChiffre(int val, int id)
        {
            char type = 'P';
            bool frtE = false, frtS = false, frtO = false, frtN = false; 
            if ((val / 64) == 1)
            { 
                type = 'M';
                val -= 64;
            }
            if ((val / 32) == 1)
            {
                type = 'F';
                val -= 32;
            }
            if ((val / 8) == 1)
            {
                val -= 8;
                frtE = true;
            }
            if ((val / 4) == 1)
            {
                val -= 4;
                frtS = true;
            }
            if ((val / 2) == 1)
            {
                val -= 2;
                frtO = true;
            }
            if ((val / 1) == 1)
            {
                val -= 1;
                frtN = true;
            }
            Case nvlCase = new Case(id, -1, type, frtE, frtS, frtO, frtN);
            cases.Add(nvlCase);
        }




        // méthode appelant les méthodes d'affectation des parcelles adjacentes (est, nord, ouest, sud)
        public static void DefinitionParcelleUniteAdjacente(int compt)
        {
            AffectParcelleEst(compt);
            AffectParcelleNord(compt);
            AffectParcelleOuest(compt);
            AffectParcelleSud(compt);
        }

        // 
        public static void AffectParcelleNord(int compt)
        {
            int comptNorth = 1;
            if ((compt - (10 * comptNorth)) >= 0)
            {
                if (compt / 10 == 1 && cases[compt - (10 * comptNorth)].GetFrontiereSud() == false) cases[compt - (10 * comptNorth)].SetIDParcelle(cases[compt].GetIDParcelle());
                while (cases[compt - (10 * comptNorth)].GetFrontiereSud() == false && comptNorth < compt / 10)
                {
                    cases[compt - (10 * comptNorth)].SetIDParcelle(cases[compt].GetIDParcelle());
                    comptNorth++;
                }
            }
        }
        // 
        public static void AffectParcelleEst(int compt)
        {
            int comptEast = 1;
            if (compt + comptEast < 99)
            {
                if (99 - compt == 1 && cases[compt].GetFrontiereEst() == false) cases[compt + 1].SetIDParcelle(cases[compt].GetIDParcelle());
                while (cases[compt + comptEast].GetFrontiereOuest() == false && comptEast < (99 - compt))
                {
                    cases[compt + comptEast].SetIDParcelle(cases[compt].GetIDParcelle());
                    comptEast++;
                }
            }
        }
        // 
        public static void AffectParcelleSud(int compt)
        {
            int comptSouth = 1;
            if (compt + 10 <= 99)
            {
                if ((99 - compt) / 10 == 1 && cases[compt + 10].GetFrontiereNord() == false) cases[compt + 10].SetIDParcelle(cases[compt].GetIDParcelle());
                while (cases[compt + (10 * comptSouth)].GetFrontiereNord() == false && comptSouth < (99 - compt) / 10)//erreur
                {
                    cases[compt + (10 * comptSouth)].SetIDParcelle(cases[compt].GetIDParcelle());
                    comptSouth++;
                }
            }
        }
        // 
        public static void AffectParcelleOuest(int compt)
        {
            int comptWest = 1;
            if ((compt - comptWest) >= 0)
            {
                while (cases[compt - comptWest].GetFrontiereEst() == false && comptWest > compt)
                {
                    cases[compt - comptWest].SetIDParcelle(cases[compt].GetIDParcelle());
                    comptWest++;
                }
            }
        }

        // 
        public static void VerificationUniteNorth(int compt)
        {
            int comptNorth = 0;

            while (cases[compt - (comptNorth * 10)].GetFrontiereNord() == false && cases[compt].GetIDParcelle() == -1)
            {
                if (cases[compt - (comptNorth * 10)].GetIDParcelle() == -1) comptNorth++;
                else cases[compt].SetIDParcelle(cases[compt - (comptNorth * 10)].GetIDParcelle());
            }
        }
        // 
        public static void VerificationUniteEast(int compt)
        {
            int comptEast = 0;
            if (compt < 99)
            {
                if (cases[compt + 1].GetFrontiereEst() == true && cases[compt + 1].GetFrontiereOuest() == false) cases[compt].SetIDParcelle(cases[compt + 1].GetIDParcelle());
                else
                {
                    while (cases[compt + comptEast].GetFrontiereEst() == false && cases[compt].GetIDParcelle() == -1)
                    {
                        if (cases[compt + comptEast].GetIDParcelle() == -1) comptEast++;
                        else cases[compt].SetIDParcelle(cases[compt + comptEast].GetIDParcelle());
                    }
                }
            }
        }
        // 
        public static void VerificationUnitSouth(int compt)
        {
            int comptSouth = 0;
            while (cases[compt + (comptSouth * 10)].GetFrontiereSud() == false && cases[compt].GetIDParcelle() == -1)
            {
                if (cases[compt + (comptSouth * 10)].GetIDParcelle() == -1) comptSouth++;
                else cases[compt].SetIDParcelle(cases[compt + (comptSouth * 10)].GetIDParcelle());
            }
        }
        // 
        public static void VerificationUniteWest(int compt)
        {
            int comptWest = 0;
            while (cases[compt - comptWest].GetFrontiereOuest() == false && cases[compt].GetIDParcelle() == -1)
            {
                if (cases[compt - comptWest].GetIDParcelle() == -1) comptWest++;
                else cases[compt].SetIDParcelle(cases[compt - comptWest].GetIDParcelle());
            }
        }

        // 
        public static void ParcelleInconnu(int compt, ref int idParcelle)
        {
            int index = 0;
            bool formecasespecial = false;
            if (cases[compt].GetIDParcelle() == -1)
            {
                while (cases[compt + (index * 10)].GetFrontiereSud() == false && index < (99 - compt) / 10)
                {
                    if (cases[compt + (index * 10)].GetFrontiereSud() == false && cases[compt + (index * 10)].GetFrontiereOuest() == false) formecasespecial = true;
                    if (cases[compt + ((index + 1) * 10)].GetFrontiereSud() == true && cases[compt + ((index + 1) * 10)].GetFrontiereOuest() == false &&
                        cases[compt + ((index + 1) * 10)].GetFrontiereEst()) formecasespecial = true;
                    index++;
                }
                if (compt > 1)
                {
                    if (cases[compt - 1].GetFrontiereEst() == false && cases[compt + 10].GetIDParcelle() == -1) formecasespecial = true;
                }
                if (formecasespecial == true) cases[compt].SetIDParcelle(-1);
                else
                {
                    cases[compt].SetIDParcelle(idParcelle);
                    idParcelle++;
                }
            }
        }

        // 
        public static void DefinitionParcelleUniteCentrale(int compt, ref int idParcelle)
        {

            VerificationUniteEast(compt);
            VerificationUniteNorth(compt);
            VerificationUniteWest(compt);
            VerificationUnitSouth(compt);
            ParcelleInconnu(compt, ref idParcelle);
        }

        // 
        public static void DefinitionParcelle()
        {
            int idParcelle = 1;
            for (int compt = 0; compt < 100; compt++)
            {
                if (cases[compt].GetType() == 0)
                {
                    if (cases[compt].GetIDParcelle() == -1)
                    {
                        DefinitionParcelleUniteCentrale(compt, ref idParcelle);
                    }
                    else
                    {
                        if (cases[compt].GetFrontiereOuest() == false && cases[compt - 1].GetIDParcelle() != cases[compt].GetIDParcelle() && cases[compt - 1].GetIDParcelle() != -1)
                        {
                            cases[compt].SetIDParcelle(cases[compt - 1].GetIDParcelle());
                        }
                        else if (cases[compt].GetFrontiereNord() == false && cases[compt - 10].GetIDParcelle() != cases[compt].GetIDParcelle() && cases[compt - 10].GetIDParcelle() != -1)
                        {
                            cases[compt].SetIDParcelle(cases[compt - 10].GetIDParcelle());
                        }
                    }
                    DefinitionParcelleUniteAdjacente(compt);
                }
            }
        }




        //  méthode d'affichage dans la console et dans le fichier traduit de la traduction
        public static void Affichage()
        {
            StreamWriter ecriture = new StreamWriter(cheminTXT + nomIle.Replace(".chiffre", ".clair"));
            for (int compt = 0; compt < 100; compt++)
            {
                if (cases[compt].GetType() == 'P')
                {
                    Console.ResetColor();
                    Console.Write((char)(cases[compt].GetIDParcelle() - 1 + 'a') + " ");
                    ecriture.Write((char)(cases[compt].GetIDParcelle() - 1 + 'a') + " ");
                }
                if (cases[compt].GetType() == 'M')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("M ");
                    ecriture.Write("M ");
                }
                if (cases[compt].GetType() == 'F')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("F ");
                    ecriture.Write("F ");
                }
                if ((compt + 1) % 10 == 0)
                {
                    Console.WriteLine();
                    ecriture.WriteLine();
                }
            }
            Console.ResetColor();
            ecriture.Close();
        }
    }
}