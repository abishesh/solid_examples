using System;
using System.IO;

namespace Solid.Liskov
{
    /*
     * 
     *  OCP - Software entities should be open for extension,
     *  but closed for modification
     *  Once a class is done, it's done!
     *  Meyer vs. Polymorphic
    */
    public class FormatConverter
    {
        private readonly DocumentStorage _documentStorage;
        private readonly InputParser _inputParser;
        private readonly IDocumentSerializer _documentSerializer;

        public FormatConverter()
        {
            _documentSerializer = new JsonDocumentSerializer();
            _inputParser= new InputParser();
            _documentStorage = new FileDocumentStorage();
        }

        public bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            try
            {
                var input = _documentStorage.GetData(sourceFileName);
                var doc = _inputParser.ParseToDocument(input);
                var serializeDoc = _documentSerializer.Serialize(doc);
                _documentStorage.PersistDocument(serializeDoc, targetFileName);
            }
            catch (FileNotFoundException fex)
            {
                Console.Write(fex.Message);
                return false;
            }
            catch (AccessViolationException ave)
            {
                Console.Write(ave.Message);
                return false;
            }
            catch (InvalidDataException ide)
            {
                Console.Write(ide.Message);
                return false;
            }

            return true;
        }
    }
}
