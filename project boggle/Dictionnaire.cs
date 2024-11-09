using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_boggle
{
    public class Dictionnaire
    {
        private List<List<string>> liste_mot_par_taille;
        private List<List<string>> liste_mot_par_lettre;
        private string langue;
        private string[] dico;

        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Dictionnaire(string langue)
        {
            
            StreamReader sr = null;
            this.langue =langue.ToLower();
            if(this.langue == "français"||this.langue=="francais")
            {
                sr = new StreamReader("MotsPossiblesFR.txt");
            }
            else if (this.langue == "anglais" || this.langue == "english")
            {
                sr = new StreamReader("MotsPossiblesEN.txt");
            }
            else
            {
                Console.WriteLine("mauvaise langue renseigné, veuillez relancer le programme");
            }

            string line = sr.ReadLine();
            this.dico = line.Split(" ");



            ///on trie le tableau dico dan sl'ordre alphabetique
            
            QuickSort(this.dico,0,this.dico.Length-1);
           
            ///on met en place la liste où les mots sont triées par leur tailles
            
            this.liste_mot_par_taille = new List<List<string>>();
            tri_par_taille(liste_mot_par_taille);


            ///on met en place la liste où les mots sont triées par leur première lettre
            
            this.liste_mot_par_lettre = new List<List<string>>();
            tri_par_lettre(liste_mot_par_lettre);
        }
        public void tri_par_taille(List<List<string>> liste)
        {
            int cpt = 2;
            do
            {
                liste.Add(new List<string>());
                for (int i = 0; i < this.dico.Length; i++)
                {
                    if (this.dico[i].Length == cpt)
                    {
                        liste[cpt - 2].Add(this.dico[i]);
                    }
                }
                cpt++;

            } while (liste[cpt - 3].Count != 0);
        }
        public void tri_par_lettre(List<List<string>> liste)
        {
            for (int i = 0; i < 26; i++)
            {
                liste.Add(new List<string>());

                for (int j = 0; j < this.dico.Length; j++)
                {
                    if (this.dico[j][0] == alphabet[i])
                    {
                        liste[i].Add(this.dico[j]);
                    }
                }

            }
        }
        public void QuickSort(string[] tab, int low, int high)
        {
            if (low < high)
            {
                // Partitionner le tableau
                int pi = Partition(tab, low, high);

                // Trier récursivement les sous-tableaux
                QuickSort(tab, low, pi - 1);  // Avant la partition
                QuickSort(tab, pi + 1, high); // Après la partition
            }
        }    
        public int Partition(string[] tab, int low, int high)
        {                                                               // Fonction de partitionnement
            // Choisir un pivot (ici, l'élément à l'indice high)
            string pivot = tab[high];
            int i = (low - 1);  // Index du plus petit élément

            // Parcours du tableau pour partitionner les éléments
            for (int j = low; j < high; j++)
            {
                // Si l'élément est plus petit ou égal au pivot, on l'échange
                if (string.Compare(tab[j], pivot) <= 0)
                {
                    i++;
                    Swap(tab, i, j);
                }
            }

            // Échanger l'élément au pivot avec l'élément à i + 1
            Swap(tab, i + 1, high);
            return i + 1;
        }
        public void Swap(string[] tab, int i, int j)
        {
            string temp = tab[i];        // Fonction pour échanger deux éléments dans le tableau
            tab[i] = tab[j];
            tab[j] = temp;
        }



        public string toString()
        {

            string phrase = "Dans notre dictionnaire en "+this.langue+", il y a ";
            for(int i = 0; i < this.liste_mot_par_taille.Count-1; i++)
            {
                phrase += this.liste_mot_par_taille[i].Count+" mots de "+(i+2)+" lettres, ";
            }
            phrase += "\n\n Il y a egalement ";
            for (int i = 0; i < this.liste_mot_par_lettre.Count; i++)
            {
                phrase += this.liste_mot_par_lettre[i].Count + " mots qui commencent par la lettre " + alphabet[i]+", ";
            }
            return phrase;
        }

        public bool RechDichoRecursif(string mot,int gauche, int droite)
        {
            int milieu = (gauche + droite) / 2;
            string mot_teste = this.dico[milieu];
            if (gauche > droite)
            {
                return false;
            }

            else if (mot_teste == mot.ToUpper())
            {
                return true;
            }
            else if (mot_teste.CompareTo(mot) > 0)
            {
                return RechDichoRecursif(mot, gauche, milieu-1);
            }
            else 
            {
                return RechDichoRecursif(mot,milieu+1, droite);
            }
            
        }


        public string[] Dico
        {
            get { return this.dico; }
        }





    }
}
