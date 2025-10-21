using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;


namespace Loomad
{
    public abstract class Animal
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public string Color { get; set; } = string.Empty;

        public string Home { get; set; } = string.Empty;

        public virtual string Describe()
        {
            return $"My name is {Name} and I am {Age} years old. My skin is {Color} and I live in {Home}.";
        }

        public abstract string MakeSound();
    }

    public interface IFlyable
    {
        string Fly();
    }

    public interface ICrazyAction
    {
        string ActCrazy();
    }
}