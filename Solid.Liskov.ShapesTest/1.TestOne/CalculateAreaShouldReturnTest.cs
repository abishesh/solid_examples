using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solid.Liskov.ShapesTest._1.TestOne
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
      */

    [TestClass]
    public class CalculateAreaShouldReturn
    {
        [TestMethod]
        public void SixFor2X3Rectangle()
        {
            var rectangle = new Rectangle() {Height = 2, Width = 3};
            Assert.AreEqual(6, AreaCalculator.CalculateArea(rectangle));
        }

        [TestMethod]
        public void NineFor3X3Square()
        {
            var square = new Square() { Width = 3 };
            Assert.AreEqual(9, AreaCalculator.CalculateArea(square));
        }

        [TestMethod]
        public void TwentyFor4X5RectangleFromSquare()
        {
            Rectangle rectangle = new Square() { Height = 4, Width = 5 };
            Assert.AreEqual(20, AreaCalculator.CalculateArea(rectangle));
        }
    }

    public class Rectangle
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
    }

    public class Square : Rectangle
    {
        private int _height;
        private int _width;

        //Violate base class invariants
        public override int Height
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
                _height = value;
            }
        }


        public override int Width
        {
            get
            {
                return _height;
            }

            set
            {
                _width = value;
                _height = value;
            }
        }
    }

    //Lack of cohesion, violates tell don't ask. 
    //This class works only works if collaborated with Rectangle or Square
    //Behaviour decoupled from state
    public class AreaCalculator
    {
        public static int CalculateArea(Rectangle r)
        {
            return r.Height*r.Width;
        }

        public static int CalculateArea(Square r)
        {
            return r.Width * r.Width;
        }
    }
}
