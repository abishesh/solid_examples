using System;
using System.IO;

namespace Solid.Liskov
{
    static class Program
    {
        static void Main()
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "input.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "output.json");

            var formatConverter = new FormatConverter();
            if (!formatConverter.ConvertFormat(sourceFileName, targetFileName))
            {
                Console.WriteLine("Conversion Failed...");
                Console.ReadKey();
            }
        }
    }

    public class Document
    {
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
