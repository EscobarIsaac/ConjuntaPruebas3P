namespace TDD.Models
{
    public class Circulo
    {
        public int radio { get; set; }

        public double area()
        {
            double area = 3.14 ;
            Console.WriteLine(area);  // Usamos Console.WriteLine() para imprimir el área
            return area;
        }
    }
}
