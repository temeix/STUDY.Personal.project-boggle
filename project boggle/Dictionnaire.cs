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

            Console.WriteLine(this.dico.Length);
           
            this.liste_mot_par_taille = new List<List<string>>();
            int cpt = 2;
            do
            {
                liste_mot_par_taille.Add(new List<string>());
                for (int i = 0; i < this.dico.Length; i++)
                {
                    if (this.dico[i].Length == cpt)
                    {
                        this.liste_mot_par_taille[cpt-2].Add(this.dico[i]);
                    }

                }
                cpt++;

            } while (liste_mot_par_taille[cpt-3].Count != 0);

            

            this.liste_mot_par_lettre = new List<List<string>>();
            for (int i = 0; i < 26; i++)
            {
                this.liste_mot_par_lettre.Add(new List<string>());

                for(int j = 0; j<this.dico.Length;j++)
                {
                    if (this.dico[j][0] == alphabet[i])
                    {
                        this.liste_mot_par_lettre[i].Add(this.dico[j]);
                    }
                }

            }  
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
            if (gauche > droite)
            {
                return false;
            }

            else if (this.dico[milieu] == mot)
            {
                return true;
            }
            else if (this.dico[milieu].CompareTo(mot) > 0)
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
