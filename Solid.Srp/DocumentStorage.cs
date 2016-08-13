using System;
using System.IO;

namespace Solid.Srp
{
    internal class DocumentStorage
    {
        public string GetData(string sourceFileName)
        {
            if (!File.Exists(sourceFileName))
            {
                throw new FileNotFoundException();
            }

            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public void PersistDocument(string serializedDoc, string targetFileName)
        {
            try
            {
                using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(serializedDoc);
                    streamWriter.Close();
                }
            }
            catch
            {
                throw new AccessViolationException();
            }            
        }
    }
}