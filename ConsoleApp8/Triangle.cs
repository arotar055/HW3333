using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp8
{
    class Triangle : Shape
    {
        double Cathetus1;
        double Cathetus2;

        public Triangle(double cath1, double cath2)
        {
            Cathetus1 = cath1;
            Cathetus2 = cath2;
        }

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Triangle:");
            Console.WriteLine("First cathetus: " + Cathetus1 + "\nSecond cathetus: " + Cathetus2);
        }

        public override double Area()
        {
            return Cathetus1 * Cathetus2 * 0.5;
        }

        public override void Save(StreamWriter writeToFile)
        {
            writeToFile.WriteLine("Triangle");
            writeToFile.WriteLine(Cathetus1);
            writeToFile.WriteLine(Cathetus2);
        }

        public override void Load(StreamReader readFile)
        {
            Cathetus1 = double.Parse(readFile.ReadLine());
            Cathetus2 = double.Parse(readFile.ReadLine());
        }
    }
}
