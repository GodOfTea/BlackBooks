using System;
using System.IO;
using System.Xml.Serialization;

namespace BlackBooks
{
    public static class BooksDtoHelper
    {
        private static readonly XmlSerializer Xs = new XmlSerializer(typeof(BookRequestDto));
        public static void WriteToFile (string fileName, BookRequestDto data)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xs.Serialize(fileStream, data);
            }
        }

        public static BookRequestDto LoadFromFile(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (BookRequestDto)Xs.Deserialize(fileStream);
            }
        }

        public static BookRequestDto LoadFromStream(Stream file)
        {
            return (BookRequestDto)Xs.Deserialize(file);
        }
    }
}
