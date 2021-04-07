using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfMath
{
    class Sequence
    {
        public List<Unit> units;
        public Sequence(UnitType type)
        {
            units = new List<Unit>();
            units.Add(new Unit(Unit.BasicStates[type], this));
            units.Last().chainPosition = units.Count - 1;
        }
        public void NextValue()
        {
            units[0].NextVar();

        }
        public void LastValue()
        {
            units[0].LastVar();
        }
        public override string ToString()
        {
            units.Reverse();
            var str = string.Join("", units.Select(i => i.StateChar.ToString()));
            units.Reverse();
            return str;
        }
    }
}
