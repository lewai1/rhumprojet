using System;
using System.Collections.Generic;
using System.Text;

namespace GuyBrushProject
{
    /// <summary>
    /// Classe Foret: Modelise une parcelle de forêt.
    /// </summary>
    class Foret : Parcelle
    {
        #region Attributs
        /// <summary>
        /// Lettre de la parcelle
        /// </summary>
        private char lettreParc;
        /// <summary>
        /// Numero qui représente l'unité.
        /// </summary>
        private int nbInfo;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de la classe foret
        /// </summary>
        /// <param name="nb"></param>

        #region Constructeur
        /// <summary>
        /// Constructeur de la classe foret
        /// </summary>
        /// <param name="nb"></param>

        public Foret(int nb) : base(nb)
        {
            lettreParc = 'F';
            nbInfo = nb;
        }
        #endregion
    }
}
