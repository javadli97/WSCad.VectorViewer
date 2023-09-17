using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WSCad.Challenge.Model;
using WSCad.Challenge.Services.Abstractions;

namespace WSCad.Challenge.Services
{
    public class JsonFileService : IFileService
    {
        public List<Shape> Open(string fileName)
        {
            List<Shape> phones = new List<Shape>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Shape>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                phones = jsonFormatter.ReadObject(fs) as List<Shape>;
            }

            return phones;
        }

        public void Save(string fileName, List<Shape> phoneList)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Shape>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, phoneList);
            }
        }
    }
}
