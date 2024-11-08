﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project_boggle
{
    public class De
    {
        private char[] liste_lettre_de;
        private char lettre_visible;


        Random r = new Random();
        


        public De()
        {
            List<char> liste_lettre_entiere = new List<char>();
            StreamReader sr = new StreamReader("Lettres.txt");

            string line= sr.ReadLine();

            while (line != null)
            {
                int dernierpv= line.LastIndexOf(";");

                int cpt = Convert.ToInt32(line.Substring(dernierpv+1));  // recupere le nombre apres le dernier pt virgule;


                for(int i=0; i<cpt; i++)
                {
                    liste_lettre_entiere.Add(Convert.ToChar(line.Substring(0, 1))); //rajoute la lettre cpt fois (correspond a la prob quelle tombe)
                }
                line = sr.ReadLine();
            }
            sr.Close();

            //on a recuperer un liste avec toutes les lettres de l'alphabet, il y a autant d'exemplaire de chaques lettres que de fois où elle peut apparaitre

            this.liste_lettre_de = new char[6];

            for (int i = 0; i < 6; i++)
            {
                int cpt=r.Next(liste_lettre_entiere.Count);

                this.liste_lettre_de[i] = liste_lettre_entiere[cpt];

                liste_lettre_entiere.RemoveAt(cpt);
            }

            //On a pris une valeur cpt aleatoire entre 0 et la longeur du tableau dynamique liste_lettre_entiere,
            //mis la lettre positionnée à la cpt -nieme du tableau liste_lettre_entiere dans un des slots de notre tableau liste_lettre_de
            //et tout ca 6 fois pour les 6 faces.


        }

        public void Lance(Random r)
        {
            int valeur =r.Next(6);
            this.lettre_visible = this.liste_lettre_de[valeur];
        }
        //On a definit la face visible de notre dé

        public string toString()
        {
            return this.lettre_visible+" est la face visible de notre dé.\n";
        }


        

    }
}
