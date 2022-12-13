using System;

namespace TDMotMel
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Joueur a = new Joueur("gab");
            a.Add_Mot("oui");
            a.Add_Mot("non");

            Plateau b = new Plateau("CasSimple.csv");
            Console.WriteLine(b.toString());
            b.ToFile("TestduToFile.csv");
            Console.WriteLine(b.Test_Plateau("voiture", 0, 2, "S"));

            /*Plateau c = new Plateau("FR",5);
            c.Create();
            Console.WriteLine(c.toString());*/

            /*Dictionnaire d = new Dictionnaire("FR", 8);
            Console.WriteLine(d.toString());
            Console.WriteLine(d.RechDichoRecursif("Vouerais"));
            Console.WriteLine(d.RechDichoRecursif("P0ire"));*/




        }
    }
}
