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

        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Dictionnaire(string langue)
        {
            this.langue = langue;
            StreamReader sr = null;
            langue =langue.ToLower();
            if(langue == "français"||langue=="francais")
            {
                sr = new StreamReader("MotsPossiblesFR.txt");
            }
            else if (langue == "anglais" || langue == "english")
            {
                sr = new StreamReader("MotsPossiblesEN.txt");
            }
            else
            {
                Console.WriteLine("mauvaise langue renseigné, veuillez relancer le programme");
            }

            string line = sr.ReadLine();
            string[] dico = line.Split(" ");

            Console.WriteLine(dico.Length);
           
            this.liste_mot_par_taille = new List<List<string>>();
            int cpt = 2;
            do
            {
                liste_mot_par_taille.Add(new List<string>());
                for (int i = 0; i < dico.Length; i++)
                {
                    if (dico[i].Length == cpt)
                    {
                        this.liste_mot_par_taille[cpt-2].Add(dico[i]);
                    }

                }
                cpt++;

            } while (liste_mot_par_taille[cpt-3].Count != 0);

            

            this.liste_mot_par_lettre = new List<List<string>>();
            for (int i = 0; i < 26; i++)
            {
                this.liste_mot_par_lettre.Add(new List<string>());

                for(int j = 0; j<dico.Length;j++)
                {
                    if (dico[j][0] == alphabet[i])
                    {
                        this.liste_mot_par_lettre[i].Add(dico[j]);
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





    }
}
