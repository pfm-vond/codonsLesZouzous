using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeral
{
    public class Convertor
    {
        private IList<(string from, string to)> RewriteRules { get; set; }

        public Convertor(IList<(string from, string to)> rewriteRules = null)
        {
            RewriteRules = rewriteRules ?? new List<(string from, string to)> 
            {
                ("IIIII", "V"),
                ("IIII", "IV"),
                ("VV", "X"),
                ("VIV", "IX"),
                ("XXXXX", "L"),
                ("XXXX", "XL"),
                ("LL", "C"),
                ("LXL", "XC"),
                ("CCCCC", "D"),
                ("CCCC", "CD"),
                ("DD", "M"),
                ("DCD", "CM")
            };
        }

        public int Convert(string roman)
        {
            foreach (var rule in RewriteRules.Reverse())
            {
                roman = roman.Replace(rule.to, rule.from);
            }

            return roman.Length;
        }

        public string Convert(int arabic)
        {
            string roman = new string('I', arabic);

            foreach(var rule in RewriteRules)
            {
                roman = roman.Replace(rule.from, rule.to);
            }

            return roman;
        }
    }
}
