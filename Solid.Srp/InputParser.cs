using System.IO;
using System.Xml.Linq;

namespace Solid.Srp
{
    internal class InputParser
    {
        public Document ParseToDocument(string input)
        {
            Document doc;
            try
            {
                var xdoc = XDocument.Parse(input);
                doc = new Document
                {
                    Title = xdoc.Root.Element("title").Value,
                    Text = xdoc.Root.Element("text").Value
                };
            }
            catch
            {
                throw new InvalidDataException();
            }
           
            return doc;
        }
    }
}