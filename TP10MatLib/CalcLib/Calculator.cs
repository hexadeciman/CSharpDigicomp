using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public class Calculator
    {
        public static int Add(int x, int y) => x + y;
        public static int Sub(int x, int y) => x - y;
        public static int Mul(int x, int y) => x * y;
        public static int Div(int x, int y) {
            Contract.Requires(y != 0);
            return x / y;
        }
        public static int Pow(int x, int y) => (int)Math.Pow(x, y);
    }
}
