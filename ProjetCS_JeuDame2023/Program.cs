using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetCS_JeuDame2023
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisation du plateau de jeu en créant un tableau à deux dimensions
            int[,] plateau = new int[7, 7];
            for (int ligne = 0; ligne < 7; ligne++)
            {
                for (int colonne = 0; colonne < 7; colonne++)
                {
                    // Les cases noires représentent les cases valides pour les pions
                    if ((ligne + colonne) % 2 == 1)
                    {
                        plateau[ligne, colonne] = 1;
                    }
                }
            }

            // Initialisation des deux joueurs
            string joueur1 = "Joueur 1";
            string joueur2 = "Joueur 2";

            // Initialisation des positions de départ pour chaque joueur
            int joueur1X = 1;
            int joueur1Y = 0;

            int joueur2X = 5;
            int joueur2Y = 6;

            // Boucle principale qui permet aux joueurs de jouer à tour de rôle
            string joueurActuel = joueur1;
            bool finDuJeu = false;
            while (!finDuJeu)
            {
                // Affichage du plateau de jeu
                Console.WriteLine("  0 1 2 3 4 5 6 ");
                for (int ligne = 0; ligne < 7; ligne++)
                {
                    Console.Write(ligne + " ");
                    for (int colonne = 0; colonne < 7; colonne++)
                    {
                        if (joueur1X == ligne && joueur1Y == colonne)
                        {
                            // Affichage du pion du joueur 1
                            Console.Write("X ");
                        }
                        else if (joueur2X == ligne && joueur2Y == colonne)
                        {
                            // Affichage du pion du joueur 2
                            Console.Write("O ");
                        }
                        else if (plateau[ligne, colonne] == 1)
                        {
                            // Affichage d'une case noire
                            Console.Write("- ");
                        }
                        else
                        {
                            // Affichage d'une case blanche
                            Console.Write("  ");
                        }
                    }
                    Console.WriteLine();
                }

                // Demande à l'utilisateur de saisir une position de destination pour son pion
                int destinationX;
                int destinationY;
                do
                {
                    Console.Write("Au tour de " + joueurActuel + ". Entrez la ligne de votre pion : ");
                    destinationX = int.Parse(Console.ReadLine());

                    Console.Write("Entrez la colonne de votre pion : ");
                    destinationY = int.Parse(Console.ReadLine());

                } while (plateau[destinationX, destinationY] != 1);

                // Déplacement du pion du joueur courant
                if (joueurActuel == joueur1)
                {
                    joueur1X = destinationX;
                    joueur1Y = destinationY;
                    joueurActuel = joueur2;
                }
                else
                {
                    joueur2X = destinationX;
                    joueur2Y = destinationY;
                    joueurActuel = joueur1;
                }

                // Vérification de la fin du jeu
                if (joueur1X == joueur2X || joueur1Y == joueur2Y)
                {
                    Console.WriteLine(joueurActuel + " a gagné !");
                    Console.ReadLine();
                    finDuJeu = true;
                }
            }
        }
    }
}

