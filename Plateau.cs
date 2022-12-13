using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TDMotMel
{
    class Plateau
    {
        Random r = new Random();
        string langue;
        int difficulte;
        string[,] grille;
        string[] mots_a_trouver;
        List<string> liste_mots_a_trouver;
        List<string> liste_mots_trouvés;
        List<string> liste_mots_non_trouvés;
        int nb_lignes;
        int nb_colonnes;
        int nb_mots;

        public Plateau(string fileName)
        {
            //Console.WriteLine("Création du plateau");
            ToRead(fileName);
        }

        public Plateau(string langue,int difficulte)
        {
            this.langue = langue;
            this.difficulte = difficulte;
        }


        /// <summary>
        /// La fonction ToRead va donner des valeurs aux attributs d'une instance à partir d'un fichier csv
        /// </summary>
        /// <param name="fileName">Nom du fichier csv</param>
        public void ToRead(string fileName)
        {
            Console.WriteLine("Début lecture");
            StreamReader sReader = null;       

            try
            {
                sReader = new StreamReader(fileName);
                string line;
                int ligne = 0;
                while ((line = sReader.ReadLine()) != null)
                {
                    if(ligne == 0)
                    {
                        string[] en_tete = line.Split(";");
                        this.difficulte = Convert.ToInt32(en_tete[0]);
                        //Console.WriteLine("Difficulte ajoutée");
                        this.nb_lignes = Convert.ToInt32(en_tete[1]);
                        //Console.WriteLine("Nombre de ligne ajouté");
                        this.nb_colonnes = Convert.ToInt32(en_tete[2]);
                        //Console.WriteLine("Nombre de colonne ajouté");
                        this.nb_mots = Convert.ToInt32(en_tete[3]);
                        //Console.WriteLine("Nombre de mot ajouté");
                    }

                    else if(ligne == 1)
                    {
                        this.mots_a_trouver = new string[this.nb_mots];
                        this.mots_a_trouver = line.Split(";");
                        this.liste_mots_a_trouver = new List<string>();
                        this.liste_mots_trouvés = new List<string>();
                        this.liste_mots_non_trouvés = new List<string>();
                        this.liste_mots_a_trouver.AddRange(this.mots_a_trouver);
                        this.liste_mots_non_trouvés.AddRange(this.mots_a_trouver);
                        //Console.WriteLine("Liste de mot initalisée");
                        this.grille = new string[this.nb_lignes, this.nb_colonnes];
                    }

                    else if (ligne > 1 && ligne < this.nb_lignes + 2)
                    {

                        string[] c = line.Split(";");
                        for (int colonne = 0; colonne < this.nb_colonnes; colonne++)
                        {
                            //Console.WriteLine("Ligne : " + ligne + " ,Colonne : " + colonne);
                            this.grille[ligne - 2, colonne] = c[colonne];
                        }
                    }
                    ligne++;

                }
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
        /// Renvoie la description d'un plateau avec aussi les attributs de difficulté, la liste de mot à trouver, et la grille.
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string s = "Difficulte : " + this.difficulte + "\nNombre de lignes : " + this.nb_lignes + "\nNombre de colonnes : " + this.nb_colonnes + "\nNombre de mots : " + this.nb_mots + "\nMots à trouver : ";

            if (mots_a_trouver != null)
            {
                foreach (string mot in this.mots_a_trouver)
                {
                    s += mot + " ; ";
                }
            }
            else
            {
                foreach (string mot in this.liste_mots_a_trouver)
                {
                    s += mot + " ; ";
                }
            }
            s += "\n";
            for (int i = 0; i < this.nb_lignes; i++)
            {
                for (int j = 0; j < this.nb_colonnes; j++)
                {
                    s += " | " + this.grille[i, j];
                }
                s += " |\n";
            }
            return s;
        }


        /// <summary>
        /// Sauvegarde le plateau dans fichier csv
        /// </summary>
        /// <param name="fileName">Chemin du fichier de sauvegarde</param>
        public void ToFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                
                string[] csv = new string[2+this.nb_lignes];

                //Console.WriteLine("Création de l'en tete");
                csv[0] = this.difficulte + ";" + this.nb_lignes + ";" + this.nb_colonnes + ";" + this.nb_mots;


                //Console.WriteLine("Création de la liste de mot");
                csv[1] = "";
                foreach(string mot in this.mots_a_trouver)
                {
                    csv[1] += mot + ";";
                }

                //Console.WriteLine("Creation du tableau");
                for (int i = 0; i < this.nb_lignes; i++)
                {
                    csv[i+2] = "";
                    for (int j = 0; j < this.nb_colonnes; j++)
                    {
                        csv[i+2] += this.grille[i, j]+";";
                    }
                }
                File.WriteAllLines(fileName, csv); // écriture dans le fichier
            }
        }

        /// <summary>
        /// Crée une grille en fonction de la difficulté de la grille et de sa langue.
        /// </summary>
        public void Create()
        {
            Console.WriteLine("Initialisation création");
            this.liste_mots_a_trouver = new List<string>();
            int nombre_lignes = 0;
            int nombre_colonnes = 0;
            switch (this.difficulte)
            {
                case 1:
                    nombre_lignes = 7;
                    nombre_colonnes= 7;
                    this.nb_mots = 8;
                    break;
                case 2:
                    nombre_lignes = 7;
                    nombre_colonnes = 7;
                    this.nb_mots = 8;
                    break;
                case 3:
                    nombre_lignes = 10;
                    nombre_colonnes = 10;
                    this.nb_mots = 9;
                    break;
                case 4:
                    nombre_lignes = 13;
                    nombre_colonnes = 13;
                    this.nb_mots = 12;
                    break;
                case 5:
                    nombre_lignes = 17;
                    nombre_colonnes = 17;
                    this.nb_mots = 17;
                    break;
            }

            this.nb_lignes = nombre_lignes;
            this.nb_colonnes = nombre_colonnes;
            this.grille = new string[nombre_lignes, nombre_colonnes];


            while (this.liste_mots_a_trouver.Count < this.nb_mots)
            {
                Generer_mot(this.langue, this.difficulte, nombre_colonnes);
            }
            for (int i = 0; i < this.nb_lignes; i++)
            {
                for (int j = 0; j < this.nb_colonnes; j++)
                {
                    if(this.grille[i,j] == null)
                    {
                        this.grille[i, j] = "*";
                    }
                }
            }

        }
        /// <summary>
        /// Essaye de placer un mot sur grille (avec 500 essais)
        /// </summary>
        /// <param name="langue"></param>
        /// <param name="difficulte"></param>
        /// <param name="nombre_char_max"></param>
        public void Generer_mot(string langue, int difficulte,int nombre_char_max)
        {
            string[] directions = new string[] { "S", "E", "N", "O", "SE", "SO", "NE", "NO" };
            string direction;
            Dictionnaire d;
            string mot;
            if(nombre_char_max > 14)
            {
                nombre_char_max = 14;
            }
            int taille_mot = r.Next(2, nombre_char_max);
            d = new Dictionnaire(langue, taille_mot);
            mot = d.mots[r.Next(0, d.taille - 1)];
            int direction_max = 0;

            switch (difficulte){
                case 1:
                    direction_max = 2;
                    break;
                case 2:
                    direction_max = 3;
                    break;
                case 3:
                    direction_max = 4;
                    break;
                case 4:
                    direction_max = 5;
                    break;
                case 5:
                    direction_max = 7;
                    break;
            }
            

            bool continuer = true;

            for(int i = 0; i< 500; i++)
            {
                if (continuer)
                {
                    int colonne_test = r.Next(0, nb_colonnes - 1);
                    int ligne_test = r.Next(0, nb_lignes - 1);
                    direction = directions[r.Next(0, direction_max)];

                    if (Test_Plateau(mot, ligne_test, colonne_test, direction))
                    {
                        Placer_mot(mot, ligne_test, colonne_test, direction);
                        this.liste_mots_a_trouver.Add(mot);
                        continuer = false;

                    }

                }
            }

            
        }




        /// <summary>
        /// Teste si un mot peut être placé à un endroit donné
        /// </summary>
        /// <param name="mot"></param>
        /// <param name="ligne"></param>
        /// <param name="colonne"></param>
        /// <param name="direction">string représentant sa direction (ex : "NO" pour nord-ouest)</param>
        /// <returns>Si le mot est placable ou non</returns>
        public bool Test_Plateau(string mot, int ligne, int colonne, string direction)
        {
            mot = mot.ToUpper();
            string[] cases = new string[mot.Length];

            try
            {

                switch (direction)
                {
                    case ("E"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            cases[i] = this.grille[ligne, colonne+i];
                        }
                        break;

                    case ("O"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            cases[i] = this.grille[ligne, colonne - i];
                        }
                        break;

                    case ("S"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            cases[i] = this.grille[ligne + i, colonne];
                        }
                        break;
                    case ("N"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            cases[i] = this.grille[ligne - i, colonne ];
                        }
                        break;

                    case ("SE"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            cases[i] = this.grille[ligne + i, colonne+i];
                        }
                        break;

                    case ("SO"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            cases[i] = this.grille[ligne + i, colonne - i];
                        }
                        break;

                    case ("NE"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            cases[i] = this.grille[ligne - i, colonne + i];
                        }
                        break;

                    case ("NO"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            cases[i] = this.grille[ligne - i, colonne - i];
                        }
                        break;
                }
            }

            catch (IndexOutOfRangeException e)
            {
                //Console.WriteLine("Le mot " + mot + " ne rentre pas dans la case " + ligne + "," + colonne + " avec la direction " + direction);
                return false;
            }

            for(int i = 0; i < mot.Length; i++)
            {
                if (!(Convert.ToString(mot[i]) == cases[i]) && !(cases[i] == null))
                {
                    //Console.WriteLine(mot[i] + cases[i]);
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Place un mot dans la grille selon les paramètres donnés
        /// </summary>
        /// <param name="mot">mot à placer</param>
        /// <param name="ligne">s</param>
        /// <param name="colonne"></param>
        /// <param name="direction">string représentant sa direction (ex : "NO" pour nord-ouest)</param>
        public void Placer_mot(string mot, int ligne, int colonne, string direction)
        {
            mot = mot.ToUpper();

                switch (direction)
                {
                    case ("E"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            this.grille[ligne, colonne + i] = Convert.ToString(mot[i]);
                        }
                        break;

                    case ("O"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            this.grille[ligne, colonne - i] =  Convert.ToString(mot[i]); ;
                        }
                        break;

                    case ("S"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            this.grille[ligne + i, colonne] = Convert.ToString(mot[i]); ;
                        }
                        break;
                    case ("N"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            this.grille[ligne - i, colonne] = Convert.ToString(mot[i]) ;
                        }
                        break;

                    case ("SE"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            this.grille[ligne + i, colonne + i] = Convert.ToString(mot[i]) ;
                        }
                        break;

                    case ("SO"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            this.grille[ligne + i, colonne - i] = Convert.ToString(mot[i]);
                        }
                        break;

                    case ("NE"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            this.grille[ligne - i, colonne + i] = Convert.ToString(mot[i]); 
                        }
                        break;

                    case ("NO"):
                        for (int i = 0; i < mot.Length; i++)
                        {
                            this.grille[ligne - i, colonne - i] = Convert.ToString(mot[i]); 
                        }
                        break;
                
            }

            
        }

        public string plateau_ingame()
        {
            string s = "Difficulte : " + this.difficulte + "\nNombre de lignes : " + this.nb_lignes + "\nNombre de colonnes : " + this.nb_colonnes + "\nNombre de mots : " + this.nb_mots + "\nMots à trouver : ";

            if (mots_a_trouver != null)
            {
                foreach (string mot in this.mots_a_trouver)
                {
                    s += mot + " ; ";
                }
            }
            else
            {
                foreach (string mot in this.liste_mots_a_trouver)
                {
                    s += mot + " ; ";
                }
            }
            s += "\n";
            for (int i = 0; i < this.nb_lignes; i++)
            {
                for (int j = 0; j < this.nb_colonnes; j++)
                {
                    s += " | " + this.grille[i, j];
                }
                s += " |\n";
            }
            return s;
        }

    }
}
