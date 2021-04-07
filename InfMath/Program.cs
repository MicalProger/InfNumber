using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Sequence s = new Sequence(UnitType.Decimal);
            for (int i = 0; i < 99; i++)
            {
                s.NextValue();
                Console.WriteLine(s.ToString());
            }
            for (int i = 100 - 1; i >= 5; i--)
            {
                s.LastValue();
                Console.WriteLine(s.ToString());
            }
        }
    }
}
