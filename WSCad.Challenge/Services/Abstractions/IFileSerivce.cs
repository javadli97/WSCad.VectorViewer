using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCad.Challenge.Model;

namespace WSCad.Challenge.Services.Abstractions
{
    public interface IFileService
    {
        List<Shape> Open(string fileName);
        void Save(string fileName, List<Shape> phoneList);
    }
}
