using System;

namespace Loomad
{
    public class Lehm : Animal, ICrazyAction
    {
        public override string MakeSound()
        {
            return $"Ammuuuu!";
        }

        public string ActCrazy()
        {
            return $"{Name} jooksis välja karjusest ja trampis üle aia!";
        }

        public override string Describe()
        {
            return $"Minu nimi on {Name}, ma olen {Age} aastat vana. Minu nahk on {Color} ja elan {Home}.";
        }
    }
}