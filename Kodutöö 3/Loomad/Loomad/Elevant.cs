using System;

namespace Loomad
{
    public class Elevant : Animal, ICrazyAction
    {
        public override string MakeSound()
        {
            return $"oauuuaa (insert tromper)!";
        }

        public string ActCrazy()
        {
            return $"{Name} pritsib ninaga vett ja teeb suure segaduse!";
        }

        public override string Describe()
        {
            return $"Minu nimi on {Name}, ma olen {Age} aastat vana. Minu nahk on {Color} ja elan {Home}. Olen suur ja tark loom!";
        }
    }
}