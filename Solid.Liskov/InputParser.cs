using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Solid.Liskov
{
    public class InputParser
    {
        public virtual Document ParseToDocument(string input)
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

    //Bertrand Meyer 
    public class JsonInputParser : InputParser
    {
        public override Document ParseToDocument(string input)
        {
            return JsonConvert.DeserializeObject<Document>(input);
        }
    }
}