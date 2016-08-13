using Newtonsoft.Json;

namespace Solid.Srp
{
    internal class DocumentSerializer
    {
        public string SerializeDocument(Document doc)
        {
            return JsonConvert.SerializeObject(doc);
        }
    }
}