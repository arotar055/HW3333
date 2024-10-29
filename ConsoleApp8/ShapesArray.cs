using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class ShapesArray
    {
        Shape[] shapes;
        int size;

        public ShapesArray()
        {
            shapes = new Shape[2];
            size = 0;
        }

        public int Size
        {
            get { return size; }
        }

        public Shape this[int index] // Indexer to access shapes in the Menu class
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException("Index out of array bounds.");
                }
                return shapes[index];
            }
        }

        // Add a shape
        public void Add(Shape shape)
        {
            if (size == shapes.Length)
            {
                Shape[] newShapes = new Shape[shapes.Length * 2];
                for (int i = 0; i < shapes.Length; i++)
                {
                    newShapes[i] = shapes[i];
                }
                shapes = newShapes;
            }

            shapes[size] = shape;
            size++;
        }

        // Remove a shape
        public void Remove(Shape shape)
        {
            int index = Array.IndexOf(shapes, shape, 0, size); // Get the index of the shape to be removed
            if (index >= 0)
            {
                for (int i = index; i < size - 1; i++)
                {
                    shapes[i] = shapes[i + 1];
                }
                shapes[size - 1] = null;
                size--;
                Console.WriteLine("");
            }
        }

        // Print all shapes
        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                shapes[i].Show();
            }
        }

        // Print shapes of the specified type
        public void OutputSpecifiedFigure(string figure)
        {
            bool figureFound = false;
            for (int i = 0; i < size; i++)
            {
                Shape shape = shapes[i];
                if (figure == "Triangle" && shape is Triangle)
                {
                    shape.Show();
                    figureFound = true;
                }
                else if (figure == "Rectangle" && shape is Rectangle)
                {
                    shape.Show();
                    figureFound = true;
                }
                else if (figure == "Circle" && shape is Circle)
                {
                    shape.Show();
                    figureFound = true;
                }
            }

            if (!figureFound)
            {
                Console.WriteLine("No such shape found.");
            }
        }

        // Calculate the area of all shapes
        public void AreaFigure()
        {
            Console.WriteLine("");
            double area;
            for (int i = 0; i < size; i++)
            {
                area = shapes[i].Area();
                Console.WriteLine("Area of shape " + i + ": " + area);
            }
        }

        // Calculate the area of shapes of a specified type
        public void AreaTypeFigure(string figure)
        {
            Console.WriteLine("");
            double area;
            bool figureFound = false;
            for (int i = 0; i < size; i++)
            {
                Shape shape = shapes[i];
                if (figure == "Triangle" && shape is Triangle)
                {
                    area = shape.Area();
                    Console.WriteLine("Area of triangle: " + area);
                    figureFound = true;
                }
                else if (figure == "Rectangle" && shape is Rectangle)
                {
                    area = shape.Area();
                    Console.WriteLine("Area of rectangle: " + area);
                    figureFound = true;
                }
                else if (figure == "Circle" && shape is Circle)
                {
                    area = shape.Area();
                    Console.WriteLine("Area of circle: " + area);
                    figureFound = true;
                }
            }

            if (!figureFound)
            {
                Console.WriteLine("No such shape found.");
            }
        }

        // Save shapes to file
        public void Save()
        {
            using (StreamWriter writer = new StreamWriter("Figure.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    shapes[i].Save(writer);
                }
            }
            Console.WriteLine("Shapes saved to file.");
        }

        // Load shapes from file
        public void Load()
        {
            size = 0;

            using (StreamReader read = new StreamReader("Figure.txt"))
            {
                while (!read.EndOfStream)
                {
                    string shapeType = read.ReadLine();
                    Shape shape = null;

                    if (shapeType == "Triangle")
                    {
                        shape = new Triangle(0, 0);
                    }
                    else if (shapeType == "Rectangle")
                    {
                        shape = new Rectangle(0, 0, 0, 0);
                    }
                    else if (shapeType == "Circle")
                    {
                        shape = new Circle(0, 0, 0);
                    }

                    if (shape != null)
                    {
                        shape.Load(read);
                        Add(shape);
                    }
                }
            }
            Console.WriteLine("Shapes loaded from file.");
        }
    }
}
