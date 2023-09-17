using Newtonsoft.Json;
using System.Collections.Generic;
using WSCad.Challenge.Helpers;
using WSCad.Challenge.Model;
using WSCad.Challenge.Services.Abstractions;

namespace WSCad.Challenge.Services
{
    internal class JsonDataReader<T> : IDataReader<T> where T : Shape
    {
        public List<T> Deserialize(string json)
        {
           return JsonConvert.DeserializeObject<List<T>>(json, new ShapeConverter());
        }
    }
}
