using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Solid.Isp
{
    public interface IDocumentSerializer
    {
        string Serialize(Document document);
    }

    public class JsonDocumentSerializer:IDocumentSerializer
    {
        public string Serialize(Document document)
        {
            return JsonConvert.SerializeObject(document);
        }
    }

    public class CamelCaseJsonSerializer : IDocumentSerializer
    {
        public string Serialize(Document document)
        {
            return JsonConvert.SerializeObject(document,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }


}