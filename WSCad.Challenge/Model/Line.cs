using System;

namespace WSCad.Challenge.Model
{
    public class Line : Shape
    {
        public string A { get; set; }
        public string B { get; set; }

        public double X1 { get { return double.Parse(A.Split("; ")[0]); } }
        public double Y1 { get { return double.Parse(A.Split("; ")[1]); } }
        public double X2 { get { return double.Parse(B.Split("; ")[0]); } }
        public double Y2 { get { return double.Parse(B.Split("; ")[1]); } }
        public Line()
        {
            
        }
        public Line(string a, string b)
        {
            A = a;
            B = b;
        }

    }
}
