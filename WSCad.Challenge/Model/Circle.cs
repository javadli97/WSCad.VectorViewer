﻿namespace WSCad.Challenge.Model
{
    public class Circle : Shape
    {
        public string Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }
    }
}