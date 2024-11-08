namespace project_boggle
{
    public class Jeu
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!skusku lala");
            De de = new De();
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                de.Lance(r);
                Console.Write(de.toString());
            }
            Console.ReadLine();
            
        }
    }
}
