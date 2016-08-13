using System;
using System.IO;

namespace Solid.Liskov
{
    public abstract class DocumentStorage
    {
        public abstract string GetData(string sourceFileName);

        public abstract void PersistDocument(string serializedDoc,
            string targetFileName);
    }

    public class FileDocumentStorage : DocumentStorage
    {
        public override string GetData(string sourceFileName)
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

        public override void PersistDocument(string serializedDoc,
            string targetFileName)
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

    public class BlobDocumentStorage : DocumentStorage
    {
        public override string GetData(string sourceFileName)
        {
            throw new NotImplementedException();
        }

        public override void PersistDocument(string serializedDoc, 
            string targetFileName)
        {
            throw new NotImplementedException();
        }
    }
}