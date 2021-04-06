using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AunoNumber
{
    class Symbol
    {
        char[] variants;
        Seq fullSeq;
        int currentVariant = 0;
        public Symbol(char[] seq, Seq f)
        {
            this.fullSeq = f;
            variants = seq;
        }
        public override string ToString()
        {
            return variants[currentVariant].ToString();
        }
        public void NextVar()
        {
            if (currentVariant + 1 > variants.Length - 1)
            {
                currentVariant = 0;
                int index = fullSeq.s.ToList().LastIndexOf(this);
                fullSeq.s[index - 1].NextVar();
            }

            else
                currentVariant++;

        }

    }
    class Seq
    {
        public Symbol[] s;
        int[] seqOfSymbols;
        public Seq(int[] times)
        {
            seqOfSymbols = times;
        }
        public void NextValue()
        {
            s.Last().NextVar();
        }
        public override string ToString()
        {
            return string.Join("", seqOfSymbols.Select(i => s[i - 1].ToString()));
        }

    }
    public class Class1
    {
        public bool IsCorrect(string n)
        {
            var alphadets = "ABCDEHKMOPTXZ".ToCharArray();

            if(n.Length == 5 && alphadets.Contains( n.ToCharArray()[0]) && int.TryParse( n.Substring(1, 3), out int _) && alphadets.Contains(n.ToCharArray()[4]) && alphadets.Contains(n.ToCharArray()[5]))
            {
                return true;
            }
            return false;
        }
        public int GetNumsBeetwen(string num1, string num2)
        {

        }
    }
}
