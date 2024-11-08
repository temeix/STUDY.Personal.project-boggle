using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project_boggle
{
    public class De
    {
        private List<char> liste_lettre_de;


        Random r = new Random();
        StreamReader sr = new StreamReader("Lettre.txt");

        

        

        public De()
        {
            List<char> liste_lettre_entiere = new List<char>();

            string line= sr.ReadLine();

            int nb_total_lettre = 0;

            while (line != null)
            {
                int dernierpv= line.LastIndexOf(";");

                int cpt = Convert.ToInt32(line.Substring(dernierpv));  // recupere le nombre apres le dernier pt virgule;

                nb_total_lettre += cpt;

                for(int i=0; i<cpt; i++)
                {
                    liste_lettre_entiere.Add(Convert.ToChar(line.Substring(0, 1))); //rajoute la lettre cpt fois (correspond a la prob quelle tombe)
                }
                line = sr.ReadLine();
            }
        }
    }
}
