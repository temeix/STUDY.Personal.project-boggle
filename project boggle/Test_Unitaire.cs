using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_boggle
{
    public class Test_Unitaire
    {
        public static void testfonction()
        {
            ///test de la fonction Lance et tostring de la classe Dé.
            ///on verifie que le lancer de dé donnent des lettres differentes a chaque fois (sauf si on a pas de chance et qu'on tombe sur 6 E.
            
            De de = new De();
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                de.Lance(r);
                Console.Write(de.toString());
            }
            ///On teste la fonction contain addmot et to string.
            ///on ajoute plusieurs mots et on met des doublons pour verifier que tous les programmes fonctionnent.
            Joueur adam = new Joueur ("Adam");
            adam.Add_Mot("POMPIER");
            adam.Add_Mot("POLICIER");
            adam.Add_Mot("AMBULANCIER");
            adam.Add_Mot("POMPIER");
            Console.WriteLine(adam.toString());


        }
    }
}
