using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Liskov.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
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
}
