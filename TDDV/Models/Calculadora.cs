namespace TDD.Models
{
    public class Calculadora
    {
        public int FirstNumber { get; set; }
        public int SecondNumber {get; set; }

        public int sumar ()
        {
            return FirstNumber + SecondNumber;
        }
    }
}


