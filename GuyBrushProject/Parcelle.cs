using System;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Parcelle
    {
        private int id, nomParcelle;
        private char type;
        private bool frtE, frtS, frtO, frtN;

        public Parcelle()
        {
            id = -1;
            nomParcelle = -1;
            type = 'P';
            frtE = false; frtS = false; frtO = false; frtN = false; 
        }

        public Parcelle(int id, int nomParcelle, char type, bool frtE, bool frtS, bool frtO, bool frtN)
        {
            this.id = id;
            this.nomParcelle = nomParcelle;
            this.type = type;
            this.frtE = frtE; this.frtS = frtS; this.frtO = frtO; this.frtN = frtN;
        }


        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return id;
        }


        public void SetType(char type)
        {
            this.type = type;
        }
        public new char GetType()
        {
            return type;
        }


        public void SetNomParcelle(int nomParcelle)
        {
            this.nomParcelle = nomParcelle;
        }
        public int GetNomParcelle()
        {
            return nomParcelle;
        }


        public void SetFrontiereEst(bool frtE)
        {
            this.frtE = frtE;
        }
        public bool GetFrontiereEst()
        {
            return frtE;
        }


        public void SetFrontiereSud(bool frtS)
        {
            this.frtS = frtS;
        }
        public bool GetFrontiereSud()
        {
            return frtS;
        }


        public void SetFrontiereOuest(bool frtO)
        {
            this.frtO = frtO;
        }
        public bool GetFrontiereOuest()
        {
            return frtO;
        }


        public void SetFrontiereNord(bool frtN)
        {
            this.frtN = frtN;
        }
        public bool GetFrontiereNord()
        {
            return frtN;
        }
    }
}
