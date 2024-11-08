namespace project_boggle
{
    public class Jeu
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!skusku lala");
            De de = new De();
            Random r = new Random();
            de.Lance(r);
            de.toString();
            Console.ReadLine();
        }
    }
}
