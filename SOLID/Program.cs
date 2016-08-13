using System;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Solid.InitialRefactor
{
    static class Program
    {
 static void Main()
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "input.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "output.json");

            var input = GetInput(sourceFileName);
            var doc = GetDocument(input);
            var serializeDoc = SerializeDocument(doc);
            PersistDocument(serializeDoc, targetFileName);
        }

        private static void PersistDocument(string serializedDoc, string targetFileName)
        {
            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write(serializedDoc);
                streamWriter.Close();
            }
        }

        private static string SerializeDocument(Document doc)
        {
            return JsonConvert.SerializeObject(doc);
        }

        private static Document GetDocument(string input)
        {
            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            return doc;
        }

        private static string GetInput(string sourceFileName)
        {
            string input;
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                input = reader.ReadToEnd();
            }

            return input;
        }
    }

    public class Document
    {
        public string Text { get; set; }
        public string Title { get; set; }
    }

}
