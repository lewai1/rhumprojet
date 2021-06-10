using System;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    class Case
    {
        private int id, idParcelle;
        private char type;
        private bool frtE, frtS, frtO, frtN; // frontières est, sud, ouest & nord

        // constructeur de parcelles
        public Case()
        {
            id = -1;
            idParcelle = -1;
            type = 'P';
            frtE = false; frtS = false; frtO = false; frtN = false; 
        }

        // constructeur de parcelles avec arguements
        public Case(int id, int idParcelle, char type, bool frtE, bool frtS, bool frtO, bool frtN)
        {
            this.id = id;
            this.idParcelle = idParcelle;
            this.type = type;
            this.frtE = frtE; this.frtS = frtS; this.frtO = frtO; this.frtN = frtN;
        }

        // méthodes pour initialiser l'id d'une parcelle, puis une méthode pour le retourner
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return id;
        }

        // méthodes pour initialiser le type d'une parcelle, puis une méthode pour le retourner
        public void SetType(char type)
        {
            this.type = type;
        }
        public new char GetType()
        {
            return type;
        }

        // méthodes pour initialiser l'id d'une parcelle, puis une méthode pour le retourner
        public void SetIDParcelle(int idParcelle)
        {
            this.idParcelle = idParcelle;
        }
        public int GetIDParcelle()
        {
            return idParcelle;
        }

        // méthodes pour initialiser la frontière est d'une parcelle, puis une méthode pour la retourner
        public void SetFrontiereEst(bool frtE)
        {
            this.frtE = frtE;
        }
        public bool GetFrontiereEst()
        {
            return frtE;
        }

        // méthodes pour initialiser la frontière sud d'une parcelle, puis une méthode pour la retourner
        public void SetFrontiereSud(bool frtS)
        {
            this.frtS = frtS;
        }
        public bool GetFrontiereSud()
        {
            return frtS;
        }

        // méthodes pour initialiser la frontière ouest d'une parcelle, puis une méthode pour la retourner
        public void SetFrontiereOuest(bool frtO)
        {
            this.frtO = frtO;
        }
        public bool GetFrontiereOuest()
        {
            return frtO;
        }

        // méthodes pour initialiser la frontière nord d'une parcelle, puis une méthode pour la retourner
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
