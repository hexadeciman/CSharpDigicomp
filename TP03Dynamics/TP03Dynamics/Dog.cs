using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP03Dynamics
{
    public class Dog
    {
        int Nlegs;
        public Dog()
        {
            this.Nlegs = 4;
        }

        public string Bark(string message)
        {
            return $"Dog barks: WOUF WOUF {message}";
        }
    }
}
