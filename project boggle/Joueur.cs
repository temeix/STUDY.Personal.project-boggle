﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_boggle
{
    public class Joueur
    {
        private string nom;
        private int score;
        private List<string> liste;
        private string[] dico;

        public Joueur (string nom)
        {
            this.nom = nom;
            this.score = 0;
            this.liste = new List<string>();
        }
        public bool Contain(string mot)
        {
            bool valeur = false;
            for(int i = 0; i < this.liste.Count; i++)
            {
                if(liste[i] == mot)
                {
                    valeur = true;
                }
            }
            return valeur;
        }
        public void Add_Mot(string mot)
        {
            if(!Contain(mot))
            {
                this.liste.Add(mot);
                this.score++;
            }
        }

        public string toString()
        {
            string phrase = this.nom+" a actuellement "+this.score+" points avec les mots ";
            for (int i = 0;i < this.liste.Count; i++)
            {
                phrase += this.liste[i]+" ";
            }
            return phrase;
        }
        
    }
}
