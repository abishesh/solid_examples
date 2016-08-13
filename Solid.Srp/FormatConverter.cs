using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Srp
{
    public class FormatConverter
    {
        private readonly DocumentStorage _documentStorage;
        private readonly InputParser _inputParser;
        private readonly DocumentSerializer _documentSerializer;

        public FormatConverter()
        {
            _documentSerializer = new DocumentSerializer();
            _inputParser= new InputParser();
            _documentStorage = new DocumentStorage();
        }

        public bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            try
            {
                var input = _documentStorage.GetData(sourceFileName);
                var doc = _inputParser.ParseToDocument(input);
                var serializeDoc = _documentSerializer.SerializeDocument(doc);
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
