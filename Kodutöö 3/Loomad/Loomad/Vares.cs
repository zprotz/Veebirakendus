using System;

namespace Loomad
{
    public class Vares : Animal, IFlyable, ICrazyAction
    {
        public bool IsFlying { get; set; }

        public override string MakeSound()
        {
            return $"{Name} teeb: Kaark-kraak!";
        }

        public string Fly()
        {
            IsFlying = !IsFlying;
            if (IsFlying)
            {
                return $"{Name} tõuseb õhku ja hakkab lendama!";
            }
            else
            {
                return $"{Name} maandub oksale!";
            }
        }

        public string ActCrazy()
        {
            return $"{Name} varastab läikiva eseme ja peidab selle oma pessa!";
        }

        public override string Describe()
        {
            string flyingStatus = IsFlying ? "lendan praegu" : "istun oksal";
            return $"Minu nimi on {Name}, ma olen {Age} aastat vana. Minu sulestik on {Color} ja elan {Home}. {flyingStatus}!";
        }
    }
}