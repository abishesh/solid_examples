using System;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Solid.Initial
{
    class Program
    {
        static void Main()
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "input.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "output.json");

            string input;
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                input = reader.ReadToEnd();
            }

            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);

            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
                using(var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write(serializedDoc);
                streamWriter.Close();
            }
        }
    }

    public class Document
    {
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
