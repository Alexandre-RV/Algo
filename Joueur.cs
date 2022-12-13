using System;
using System.Collections.Generic;
using System.Text;

namespace TDMotMel
{
    class Joueur
    {
        private string nom;
        private string[] mots;
        private int score;
        public Plateau[] plateaux;



        public Joueur(string nom)
        {
            this.nom = nom;
            this.mots = new string[0];
            this.score = 0;
            this.plateaux = new Plateau[5];
            
        }

        /// <summary>
        ///  Ajoute le mot dans la liste des mots déjà trouvés parle joueur au cours de la partie
        /// </summary>
        /// <param name="mot">mot a ajouter</param>
        public void Add_Mot(string mot)
        {
            
            string[] a = new string[this.mots.Length + 1];
            for(int i =0; i< this.mots.Length; i++)
            {
                a[i] = this.mots[i];
            }
            a[this.mots.Length] = mot;

            this.mots = a;

        }

        public string toString()
        {
            string s = "";
            s+= "Nom : " + this.nom + " Score : "+ this.score;

            for (int i = 0; i < this.mots.Length; i++)
            {
                s += "\n"+this.mots[i];
            }
            return s;
        }

        /// <summary>
        /// Ajoute une valeur au score 
        /// </summary>
        /// <param name="val">valeur à ajouter</param>
        public void Add_Score(int val)
        {
            this.score+= val;
        }
    }
    
}
