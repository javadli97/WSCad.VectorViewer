using System;
using System.Collections.Generic;
using WSCad.Challenge.Model;
using WSCad.Challenge.Services.Abstractions;

namespace WSCad.Challenge.Services
{
    internal class XmlDataReader<T> : IDataReader<T> where T : Shape
    {
        // for future implementation
        public List<T> Deserialize(string json)
        {
            throw new NotImplementedException();
        }
    }
}
