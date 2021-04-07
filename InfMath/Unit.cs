using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfMath
{
    class Unit
    {
        public static Dictionary<UnitType, char[]> BasicStates = new Dictionary<UnitType, char[]>
        {
            [UnitType.Binary] = "01".ToCharArray(),
            [UnitType.Octal] = "012345678".ToCharArray(),
            [UnitType.Decimal] = "0123456789".ToCharArray(),
            [UnitType.Hexadecimal] = "0123456789ABCDEF".ToCharArray()
        };
        public char[] States
        {
            get => states;
        }
        public char[] states;
        public int StateIndex
        {
            get => currentStateIndex;
        }
        public char StateChar
        {
            get => states[currentStateIndex];
        }
        int maxStateIndex;
        Sequence fullSeq;
        public int chainPosition;
        int currentStateIndex = 0;
        public Unit(char[] symbols, Sequence f)
        {
            fullSeq = f;
            states = symbols;
            maxStateIndex = symbols.Length - 1;
        }
        public override string ToString()
        {
            return states[currentStateIndex].ToString();
        }
        public void NextVar()
        {
            if (currentStateIndex + 1 > maxStateIndex)
            {
                currentStateIndex = 0;
                if (chainPosition == fullSeq.units.Count - 1)
                {
                    fullSeq.units.Add(new Unit(states, fullSeq));
                    fullSeq.units.Last().chainPosition = fullSeq.units.Count - 1;
                }

                fullSeq.units[chainPosition + 1].NextVar();
            }
            else
                currentStateIndex++;
        }
        public void LastVar()
        {
            if (currentStateIndex == 0)
            {

                currentStateIndex = maxStateIndex;
                fullSeq.units[chainPosition + 1].LastVar();
            }
            else
                currentStateIndex--;
        }
    }

    enum UnitType
    {
        Binary = 0,
        Octal = 1,
        Decimal = 2,
        Hexadecimal = 3,
        Another = 4
    }
}
