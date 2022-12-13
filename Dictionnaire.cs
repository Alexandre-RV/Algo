using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TDMotMel
{
    class Dictionnaire
    {
        private string langue;
        private int longueur;
        public string[] mots;
        public int taille;

        public Dictionnaire(string langue, int longueur)
        {
            this.langue = langue;
            this.longueur = longueur;


            ///Lecture du fichier pour extraire le dictionnaire
            StreamReader sReader = null;
            try
            {
                sReader = new StreamReader("MotsPossibles" + this.langue + ".txt");
                //Console.WriteLine("Lecture en cours");
                string line;
                int ligne = 0;
                bool f = false;
                while ((line = sReader.ReadLine()) != null)
                {
                    if (Convert.ToString(this.longueur) == line)
                    {
                        f = true;
                        //Console.WriteLine("ligne trouvée");

                    }
                    else if (f)
                    {
                        //Console.WriteLine("Ecriture...");
                        this.mots = new string[line.Split(" ").Length];
                        this.mots = line.Split(" ");
                        //Console.WriteLine("Fini !");
                        f = false;
                    }
                    ligne++;
                    //Console.WriteLine("Lecture de la ligne " + ligne);
                }
                this.taille = this.mots.Length;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sReader != null) { sReader.Close(); }
            }


        
    }


        /// <summary>
        /// Retourne une chaîne de caractères qui décrit le dictionnaire à savoir ici le nombre de mots par longueur et la langue
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string s = "";
            s += "Langue : " + this.langue + "\n";
            s += "Longueur : " + this.longueur + "\n";

            for (int i = 0; i < this.mots.Length; i++)
            {
                s += this.mots[i]+ " \n";
            }

            return s;
        }


        /// <summary>
        /// Teste que le mot appartient bien au dictionnaire
        /// </summary>
        /// <param name="mot">Mot à trouver</param>
        /// <returns></returns>
        public bool RechDichoRecursif(string mot)
        {
            string motATrouver = mot.ToUpper();
            foreach(string m in this.mots)
            {
                if(m == motATrouver)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
