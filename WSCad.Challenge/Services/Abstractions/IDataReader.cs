using System.Collections.Generic;
using WSCad.Challenge.Model;

namespace WSCad.Challenge.Services.Abstractions
{
    public interface IDataReader<T> where T : Shape
    {
        List<T> Deserialize(string json);
    }
}
