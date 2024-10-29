using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class ClassMenu
    {
        ShapesArray shapesArray;

        public ClassMenu()
        {
            shapesArray = new ShapesArray();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Add a shape");
                Console.WriteLine("2. Remove a shape");
                Console.WriteLine("3. Print all shapes");
                Console.WriteLine("4. Print shapes of a specified type");
                Console.WriteLine("5. Calculate the area of all shapes");
                Console.WriteLine("6. Calculate the area of shapes of a specified type");
                Console.WriteLine("7. Save shapes to file");
                Console.WriteLine("8. Load shapes from file");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddShape();
                        break;
                    case "2":
                        RemoveShape();
                        break;
                    case "3":
                        shapesArray.Print();
                        break;
                    case "4":
                        OutputSpecifiedFigure();
                        break;
                    case "5":
                        shapesArray.AreaFigure();
                        break;
                    case "6":
                        AreaTypeFigure();
                        break;
                    case "7":
                        shapesArray.Save();
                        break;
                    case "8":
                        shapesArray.Load();
                        break;
                    case "0":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }

        private void AddShape()
        {
            Console.WriteLine("Choose the type of shape to add (Triangle, Rectangle, Circle):");
            string shapeType = Console.ReadLine();

            Shape shape = null;

            if (shapeType.Equals("Triangle", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter the lengths of the legs (a b): ");
                string[] parts = Console.ReadLine().Split(' ');
                double cathetus1 = double.Parse(parts[0]);
                double cathetus2 = double.Parse(parts[1]);
                shape = new Triangle(cathetus1, cathetus2);
            }
            else if (shapeType.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter the coordinates of the top left and bottom right corners (x1 y1 x2 y2): ");
                string[] parts = Console.ReadLine().Split(' ');
                double x1 = double.Parse(parts[0]);
                double y1 = double.Parse(parts[1]);
                double x2 = double.Parse(parts[2]);
                double y2 = double.Parse(parts[3]);
                shape = new Rectangle(x1, y1, x2, y2);
            }
            else if (shapeType.Equals("Circle", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter the center coordinates and radius (x y radius): ");
                string[] parts = Console.ReadLine().Split(' ');
                double x = double.Parse(parts[0]);
                double y = double.Parse(parts[1]);
                double radius = double.Parse(parts[2]);
                shape = new Circle(x, y, radius);
            }
            else
            {
                Console.WriteLine("Invalid shape type.");
                return;
            }

            shapesArray.Add(shape);
            Console.WriteLine($"{shapeType} has been added.");
        }

        private void RemoveShape()
        {
            Console.WriteLine("Enter the type of shape to remove (Triangle, Rectangle, Circle):");
            string shapeType = Console.ReadLine();

            Shape shapeToRemove = null;

            for (int i = 0; i < shapesArray.Size; i++)
            {
                Shape shape = shapesArray[i];
                if (shapeType.Equals("Triangle", StringComparison.OrdinalIgnoreCase) && shape is Triangle)
                {
                    shapeToRemove = shape;
                    break;
                }
                else if (shapeType.Equals("Rectangle", StringComparison.OrdinalIgnoreCase) && shape is Rectangle)
                {
                    shapeToRemove = shape;
                    break;
                }
                else if (shapeType.Equals("Circle", StringComparison.OrdinalIgnoreCase) && shape is Circle)
                {
                    shapeToRemove = shape;
                    break;
                }
            }

            if (shapeToRemove != null)
            {
                shapesArray.Remove(shapeToRemove);
                Console.WriteLine($"{shapeType} has been removed.");
            }
            else
            {
                Console.WriteLine("Shape not found.");
            }
        }

        private void OutputSpecifiedFigure()
        {
            Console.WriteLine("Enter the type of shape to display (Triangle, Rectangle, Circle):");
            string figure = Console.ReadLine();
            shapesArray.OutputSpecifiedFigure(figure);
        }

        private void AreaTypeFigure()
        {
            Console.WriteLine("Enter the type of shape to calculate the area (Triangle, Rectangle, Circle):");
            string figure = Console.ReadLine();
            shapesArray.AreaTypeFigure(figure);
        }
    }
}
