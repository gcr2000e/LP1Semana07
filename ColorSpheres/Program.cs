using System;
using System.Security.Claims;

namespace ColorSpheres
{
    public class Color
    {
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }
        public int Alpha { get; private set; }

        public Color(int red, int green, int blue, int alpha)
        {
            Red = Clamp(red);
            Green = Clamp(green);
            Blue = Clamp(blue);
            Alpha = Clamp(alpha);
        }

        public Color(int red, int green, int blue) : this(red, green, blue, 255)
        {

        }

        private int Clamp(int value)
        {
            return Math.Min(255, Math.Max(0, value));
        }

        public int GetGrey()
        {
            return (Red + Green + Blue) / 3;
        }
    }

    public class Sphere
    {

        public Color Color { get; private set; }
        public float Raio { get; private set; }
        public int TimesThrown { get; private set; }

        public Sphere(Color color, float raio)
        {
            Color = color;
            Raio = raio;
            TimesThrown = 0;
        }

        public void Pop()
        {
            Raio = 0;
        }

        public void Throw()
        {
            if (Raio > 0)
            {
                TimesThrown++;
            }
        }

        public int GetTimesThrown()
        {
            return TimesThrown;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"Cor: ({Color.Red}, {Color.Green}, {Color.Blue}, {Color.Alpha})");
            Console.WriteLine($"Sphere radius: {Raio}");
            Console.WriteLine($"Número de vezes atirada: {TimesThrown}");
        }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            Color redColor = new Color(255, 0, 0);
            Color greenColor = new Color(255, 0, 0);
            Color blueColor = new Color(255, 0, 0);

            Sphere redSphere = new Sphere(redColor, 10f);
            Sphere greenSphere = new Sphere(greenColor, 15f);
            Sphere blueSphere = new Sphere(blueColor, 20f);

            redSphere.Throw();
            greenSphere.Throw();
            blueSphere.Throw();
            greenSphere.Throw();

            greenSphere.Pop();
            blueSphere.Pop();

            Console.WriteLine("Estado das esferas:");
            redSphere.PrintStatus();
            greenSphere.PrintStatus();
            blueSphere.PrintStatus();
        }
    }
}
