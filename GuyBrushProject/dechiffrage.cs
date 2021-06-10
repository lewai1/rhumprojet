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



        public static List<Parcelle> parcelles = new List<Parcelle>();
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
            Parcelle parcelle = new Parcelle(id, -1, type, frtE, frtS, frtO, frtN);
            parcelles.Add(parcelle);

        }


        public static void DefinitionParcelleUniteAdjacente(int compt)
        {
            AffectParcelleEst(compt);
            AffectParcelleNord(compt);
            AffectParcelleOuest(compt);
            AffectParcelleSud(compt);
        }

        public static void AffectParcelleNord(int compt)
        {
            int comptNorth = 1;

            if ((compt - (10 * comptNorth)) >= 0)
            {
                if (compt / 10 == 1 && parcelles[compt - (10 * comptNorth)].GetFrontiereSud() == false) parcelles[compt - (10 * comptNorth)].SetNomParcelle(parcelles[compt].GetNomParcelle());
                while (parcelles[compt - (10 * comptNorth)].GetFrontiereSud() == false && comptNorth < compt / 10)
                {
                    parcelles[compt - (10 * comptNorth)].SetNomParcelle(parcelles[compt].GetNomParcelle());
                    comptNorth++;
                }
            }
        }
        public static void AffectParcelleEst(int compt)
        {
            int comptEast = 1;
            if (compt + comptEast < 99)
            {
                if (99 - compt == 1 && parcelles[compt].GetFrontiereEst() == false) parcelles[compt + 1].SetNomParcelle(parcelles[compt].GetNomParcelle());
                while (parcelles[compt + comptEast].GetFrontiereOuest() == false && comptEast < (99 - compt))
                {
                    parcelles[compt + comptEast].SetNomParcelle(parcelles[compt].GetNomParcelle());
                    comptEast++;
                }
            }
        }
        public static void AffectParcelleSud(int compt)
        {
            int comptSouth = 1;
            if (compt + 10 <= 99)
            {
                if ((99 - compt) / 10 == 1 && parcelles[compt + 10].GetFrontiereNord() == false) parcelles[compt + 10].SetNomParcelle(parcelles[compt].GetNomParcelle());
                while (parcelles[compt + (10 * comptSouth)].GetFrontiereNord() == false && comptSouth < (99 - compt) / 10)//erreur
                {
                    parcelles[compt + (10 * comptSouth)].SetNomParcelle(parcelles[compt].GetNomParcelle());
                    comptSouth++;
                }
            }
        }
        public static void AffectParcelleOuest(int compt)
        {
            int comptWest = 1;
            if ((compt - comptWest) >= 0)
            {
                while (parcelles[compt - comptWest].GetFrontiereEst() == false && comptWest > compt)
                {
                    parcelles[compt - comptWest].SetNomParcelle(parcelles[compt].GetNomParcelle());
                    comptWest++;
                }
            }
        }


        public static void DefinitionParcelleUniteCentrale(int compt, ref int idParcelle)
        {

            VerificationUniteEast(compt);
            VerificationUniteNorth(compt);
            VerificationUniteWest(compt);
            VerificationUnitSouth(compt);
            //ParcelleInconnu(compt, ref idParcelle);
        }

        public static void VerificationUniteNorth(int compt)
        {
            int comptNorth = 0;

            while (parcelles[compt - (comptNorth * 10)].GetFrontiereNord() == false && parcelles[compt].GetNomParcelle() == -1)
            {
                if (parcelles[compt - (comptNorth * 10)].GetNomParcelle() == -1) comptNorth++;
                else parcelles[compt].SetNomParcelle(parcelles[compt - (comptNorth * 10)].GetNomParcelle());
            }
        }
        public static void VerificationUniteEast(int compt)
        {
            int comptEast = 0;
            if (compt < 99)
            {
                if (parcelles[compt + 1].GetFrontiereEst() == true && parcelles[compt + 1].GetFrontiereOuest() == false) parcelles[compt].SetNomParcelle(parcelles[compt + 1].GetNomParcelle());
                else
                {
                    while (parcelles[compt + comptEast].GetFrontiereEst() == false && parcelles[compt].GetNomParcelle() == -1)
                    {
                        if (parcelles[compt + comptEast].GetNomParcelle() == -1) comptEast++;
                        else parcelles[compt].SetNomParcelle(parcelles[compt + comptEast].GetNomParcelle());
                    }
                }
            }
        }
        public static void VerificationUnitSouth(int compt)
        {
            int comptSouth = 0;
            while (parcelles[compt + (comptSouth * 10)].GetFrontiereSud() == false && parcelles[compt].GetNomParcelle() == -1)
            {
                if (parcelles[compt + (comptSouth * 10)].GetNomParcelle() == -1) comptSouth++;
                else parcelles[compt].SetNomParcelle(parcelles[compt + (comptSouth * 10)].GetNomParcelle());
            }
        }
        public static void VerificationUniteWest(int compt)
        {
            int comptWest = 0;
            while (parcelles[compt - comptWest].GetFrontiereOuest() == false && parcelles[compt].GetNomParcelle() == -1)
            {
                if (parcelles[compt - comptWest].GetNomParcelle() == -1) comptWest++;
                else parcelles[compt].SetNomParcelle(parcelles[compt - comptWest].GetNomParcelle());
            }
        }

        

        /*public static void ParcelleInconnu(int compt, ref int idParcelle)
        {
            int index = 0;
            bool formeParcelleSpecial = false;
            if (parcelles[compt].GetNomParcelle() == -1)
            {
                while (parcelles[compt + (index * 10)].GetFrontiereSud() == false && index < (99 - compt) / 10)
                {
                    if (parcelles[compt + (index * 10)].GetFrontiereSud() == false && parcelles[compt + (index * 10)].GetFrontiereOuest() == false) formeParcelleSpecial = true;
                    if (parcelles[compt + ((index + 1) * 10)].GetFrontiereSud() == true && parcelles[compt + ((index + 1) * 10)].GetFrontiereOuest() == false &&
                        parcelles[compt + ((index + 1) * 10)].GetFrontiereEst()) formeParcelleSpecial = true;
                    index++;
                }
                if (compt > 1)
                {
                    if (parcelles[compt - 1].GetFrontiereEst() == false && parcelles[compt + 10].GetNomParcelle() == -1) formeParcelleSpecial = true;
                }
                if (formeParcelleSpecial == true) parcelles[compt].SetNomParcelle(-1);
                else
                {
                    parcelles[compt].SetNomParcelle(idParcelle);
                    idParcelle++;
                }
            }
        }*/

        

        public static void DefinitionParcelle()
        {
            int idParcelle = 1;
            for (int compt = 0; compt < 100; compt++)
            {
                if (parcelles[compt].GetType() == 0)
                {
                    if (parcelles[compt].GetNomParcelle() == -1)
                    {
                        DefinitionParcelleUniteCentrale(compt, ref idParcelle);
                    }
                    else
                    {
                        if (parcelles[compt].GetFrontiereOuest() == false && parcelles[compt - 1].GetNomParcelle() != parcelles[compt].GetNomParcelle() && parcelles[compt - 1].GetNomParcelle() != -1)
                        {
                            parcelles[compt].SetNomParcelle(parcelles[compt - 1].GetNomParcelle());
                        }
                        else if (parcelles[compt].GetFrontiereNord() == false && parcelles[compt - 10].GetNomParcelle() != parcelles[compt].GetNomParcelle() && parcelles[compt - 10].GetNomParcelle() != -1)
                        {
                            parcelles[compt].SetNomParcelle(parcelles[compt - 10].GetNomParcelle());
                        }
                    }
                    DefinitionParcelleUniteAdjacente(compt);
                }
            }
        }

        public static void Affichage()
        {
            StreamWriter ecriture = new StreamWriter(cheminTXT + nomIle.Replace(".chiffre", ".clair"));
            for (int compt = 0; compt < 100; compt++)
            {
                if (parcelles[compt].GetType() == 'P')
                {
                    Console.ResetColor();
                    Console.Write((char)(parcelles[compt].GetNomParcelle() - 1 + 'a') + " ");
                    ecriture.Write((char)(parcelles[compt].GetNomParcelle() - 1 + 'a') + " ");
                }
                if (parcelles[compt].GetType() == 'M')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("M ");
                    ecriture.Write("M ");
                }
                if (parcelles[compt].GetType() == 'F')
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