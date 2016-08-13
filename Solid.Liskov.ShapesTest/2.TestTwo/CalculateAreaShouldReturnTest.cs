using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solid.Liskov.ShapesTest._2.TestTwo
{
    /*
  Substitutability 
     Child classes must not:
         1. Remove base class behavior (not throw new exceptions)
         2. Violate base class invariants
            And in general must not require calling code to know they are different from their base type. 

     IS-A should be replaced with IS_SUBSTITUTABLE-FOR

     Invariants
         - consists of reasonable assumptions of behavior by clients
         - can be expressed as preconditions and postconditions for methods
         - Frequently, unit tests are used to specify expected behavior of a method or class
         - Design By Contract is a technique that makes defining these pre- and post conditions explicit within code itself
         - To follow LSP, derived classes must not violate any constraints (or assumed by clients) on the base class

        Problems
            Non-suitable code breaks polymorphism
            Client code excepts child classes to work in place of their base classes
            "Fixing" substitutability problem by adding if-then or switch statement quickly becomes a maintenance nightmare and violates OCP
      */

    [TestClass]
    public class CalculateAreaShouldReturn
    {
        [TestMethod]
        public void SixFor2X3Rectangle()
        {
            var rectangle = new Rectangle() { Height = 2, Width = 3 };
            Assert.AreEqual(6, rectangle.Area());
        }

        [TestMethod]
        public void NineFor3X3Square()
        {
            var square = new Square() { SideLength = 3 };
            Assert.AreEqual(9, square.Area());
        }

        [TestMethod]
        public void TwentyFor4X5ShapeFromRectangleAnd9for3X3Square()
        {
            var shapes = new List<Shape>
            {
                new Rectangle() {Height = 4, Width = 5},
                new Square() {SideLength = 3}
            };

            var areas = new List<int>();
            foreach (Shape shape in shapes)
            {
                if(shape.GetType()==typeof(Rectangle))
                    areas.Add(((Rectangle)shape).Area());
                if (shape.GetType() == typeof(Square))
                    areas.Add(((Square)shape).Area());
                //if new shape type is added, a new condition needs to be added to this class thereby violating OCP principle
                if (shape.GetType() == typeof(Triangle))
                    areas.Add(((Triangle)shape).Area());
            }

            Assert.AreEqual(20, areas[0]);
            Assert.AreEqual(9, areas[1]);
        }
    }

    public abstract class Shape
    {
    }

    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int Area()
        {
            return Height * Width;
        }
    }

    public class Square : Shape
    {
        public int SideLength { get; set; }

        public int Area()
        {
            return SideLength * SideLength;
        }
    }

    public class Triangle : Shape
    {
        public int Height { get; set; }
        public int Base { get; set; }

        public int Area()
        {
            return (int)(.5 * Height * Base); //casting to int for simplicity
        }
    }
}
