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

        public Dictionnaire(string langue)
        {
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

            for (int i = 0; i < dico.Length; i++)
            {

            }
        }
    }
}
