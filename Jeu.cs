using System;
using System.Collections.Generic;
using System.Text;

namespace TDMotMel
{
    class Jeu
    {
        Dictionnaire dic;
        Plateau plateau_actuelle;
        Plateau[] plateau_precedent;
        Joueur[] joueurs;
        string langue;

        public Jeu()
        {
            Console.WriteLine("=====Bienvenue sur le mot mélés ! ====");
            Console.WriteLine("\nEcrire règles ici\n");
            Console.WriteLine("En quelle langue voulez-vous jouer ? (FR pour français et EN pour anglais");
            this.langue = Console.ReadLine();
            Console.WriteLine("Combien y a-t-il de joueurs ?");
            this.joueurs = new Joueur[Convert.ToInt32(Console.ReadLine())];
            for(int i = 0; i<this.joueurs.Length; i++)
            {
                Console.WriteLine("Qui est le joueur " + i+1 + " ?");
                this.joueurs[i] = new Joueur(Console.ReadLine());
                for(int j = 0; j < 5; j++)
                {
                    this.joueurs[i].plateaux[j] = new Plateau(this.langue, j);
                }
            }
            Console.WriteLine("La partie est initialisée !");

        }

        public void Jouer()
        {
            Console.WriteLine("La partie commence !");
            bool running = true;
            int tour = 0;
            while (running)
            {
                
            }
        }
    }
}
