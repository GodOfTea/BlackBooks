using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Database
{
    public class SerFile
    {
        string _fileName;

        public SerFile(string fileName)
        {
            _fileName = fileName;
        }

        public void Save(List<DomainData> domaindata)
        {
            XmlSerializer Object = new XmlSerializer(typeof(List<DomainData>));
            using (StreamWriter WriteToFileStream = new StreamWriter(_fileName))
                Object.Serialize(WriteToFileStream, domaindata);
        }

        public List<DomainData> LoadData()
        {
            List<DomainData> data = new List<DomainData>();
            XmlSerializer Object = new XmlSerializer(typeof(List<DomainData>));
            using (StreamReader ReadToFileStream = new StreamReader(_fileName))
                data = Object.Deserialize(ReadToFileStream) as List<DomainData>;
            return data;
        }
    }
}
