using System;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace BetterColorSpheres
{
    public class Color
    {
        public readonly int Red;
        public readonly int Green;
        public readonly int Blue;
        public readonly int Alpha;

        public Color(int Red, int Green, int Blue, int Alpha)
        {
            this.Red = Clamp(Red);
            this.Green = Clamp(Green);
            this.Blue = Clamp(Blue);
            this.Alpha = Clamp(Alpha);
        }

        public Color(int red, int green, int blue) : this(red, green, blue, 255)
        { }

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
        public readonly Color Color;
        public float Raio;
        public int TimesThrown;

        public bool Popped;

        public Sphere(Color color, float raio)
        {
            Color = color;
            Raio = raio;
            TimesThrown = 0;
        }

        public void Pop()
        {
            Popped = true;
            Raio = 0;
        }

        public void Throw()
        {
            if (Raio > 0)
            {
                Popped = false;
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

            if (Popped == true)
            {
                Console.WriteLine("A esfera rebentou!");
            }
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
