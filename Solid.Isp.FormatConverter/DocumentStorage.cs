using System;
using System.IO;

namespace Solid.Isp
{
    /*
     ISP - introduce two interfaces
    */

    public interface IInputRetriever
    {
        string GetData(string sourceFileName);
    }

    public interface IDocumentPersister
    {
        void PersistDocument(string serializedDoc, string targetFileName);
    }

    public abstract class DocumentStorage:IInputRetriever, IDocumentPersister
    {
        public abstract string GetData(string sourceFileName);

        public abstract void PersistDocument(string serializedDoc, string targetFileName);
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

    public class BlobDocumentStorage : DocumentStorage // IDocumentPersister
    {
        public override string GetData(string sourceFileName)
        {
            throw new NotImplementedException(); //VIOLATES LSP, instead just implement IDocumentPersister
            //TODO: youre implementation
        }

        public override void PersistDocument(string serializedDoc, 
            string targetFileName)
        {
            //TODO: youre implementation
        }
    }

    public class HttpInputRetriever : IInputRetriever
    {
        public string GetData(string sourceFileName)
        {
            //TODO: your custom implementation to retrieve data from HTTP
            return string.Empty;
        }
    }
}