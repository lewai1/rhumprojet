using System;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    /// <summary>
    /// Modélisation du système de case
    /// </summary>
    class Case
    {
        #region Attributs
        /// <summary>
        /// id + idParcelle
        /// </summary>
        private int id, idParcelle;
        /// <summary>
        /// Type de parcelle
        /// </summary>
        private char type;
        /// <summary>
        /// Frontières
        /// </summary>
        private bool frtE, frtS, frtO, frtN; // frontières est, sud, ouest & nord
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de parcelle
        /// </summary>
        public Case()
        {
            id = 0;
            idParcelle = 0;
            type = 'P';
            frtE = false; frtS = false; frtO = false; frtN = false; 
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de parcelles avec arguments
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="idParcelle">id de la parcelle</param>
        /// <param name="type">Type de parcelle</param>
        /// <param name="frtE">Frontière Est</param>

        public Case(int id, int idParcelle, char type, bool frtE, bool frtS, bool frtO, bool frtN)
        {
            this.id = id;
            this.idParcelle = idParcelle;
            this.type = type;
            this.frtE = frtE; this.frtS = frtS; this.frtO = frtO; this.frtN = frtN;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthodes pour initialiser l'id d'une parcelle, puis une méthode pour le retourner
        /// </summary>
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Méthodes pour initialiser le type d'une parcelle, puis une méthode pour le retourner
        /// </summary>
        public void SetType(char type)
        {
            this.type = type;
        }
        public new char GetType()
        {
            return type;
        }

        /// <summary>
        /// Méthodes pour initialiser l'id d'une parcelle, puis une méthode pour le retourner
        /// </summary>
        public void SetIDParcelle(int idParcelle)
        {
            this.idParcelle = idParcelle;
        }
        public int GetIDParcelle()
        {
            return idParcelle;
        }

        /// <summary>
        /// Méthodes pour initialiser la frontière est d'une parcelle, puis une méthode pour la retourner
        /// </summary>
        public void SetFrontiereEst(bool frtE)
        {
            this.frtE = frtE;
        }
        public bool GetFrontiereEst()
        {
            return frtE;
        }

        /// <summary>
        /// Méthodes pour initialiser la frontière sud d'une parcelle, puis une méthode pour la retourner
        /// </summary>
        public void SetFrontiereSud(bool frtS)
        {
            this.frtS = frtS;
        }
        public bool GetFrontiereSud()
        {
            return frtS;
        }

        /// <summary>
        /// Méthodes pour initialiser la frontière ouest d'une parcelle, puis une méthode pour la retourner
        /// </summary>
        public void SetFrontiereOuest(bool frtO)
        {
            this.frtO = frtO;
        }
        public bool GetFrontiereOuest()
        {
            return frtO;
        }

        /// <summary>
        /// Méthodes pour initialiser la frontière nord d'une parcelle, puis une méthode pour la retourner
        /// </summary>
        public void SetFrontiereNord(bool frtN)
        {
            this.frtN = frtN;
        }
        public bool GetFrontiereNord()
        {
            return frtN;
        }
        #endregion
    }
}
