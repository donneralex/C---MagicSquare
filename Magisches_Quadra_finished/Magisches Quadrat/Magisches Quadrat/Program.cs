namespace Magisches_Quadrat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Magic_Square square = new Magic_Square();
            square.Create();
            square.Create(3);
        }
    }
}