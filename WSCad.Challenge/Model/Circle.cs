namespace WSCad.Challenge.Model
{
    public class Circle : Shape
    {
        public string Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }

        public double X1 { get { return double.Parse(Center.Split("; ")[0]); } }
        public double Y1 { get { return double.Parse(Center.Split("; ")[1]); } }

        public Circle()
        {
                
        }

        public Circle(string center, double radius, bool filled)
        {
            Center = center;
            Radius = radius;
            Filled = filled;
        }
    }
}
