using System;

namespace LIHAPOOD
{
    public class Meat
    {
        public string Name { get; set; } = "";
        public double Pricekg { get; set; }
        public string Location { get; set; } = "";
        public DateTime FreshUntil { get; set; }
        public string Type { get; set; } = "";

        public Meat() { }

        public Meat(string name, double pricekg, string location, DateTime freshUntil, string type)
        {
            Name = name;
            Pricekg = pricekg;
            Location = location;
            FreshUntil = freshUntil;
            Type = type;
        }
    }
}