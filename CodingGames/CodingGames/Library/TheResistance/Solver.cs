using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CodingGames.TheResistance
{
    public class Solver
    {
        private static Dictionary<char, string> morsetable = new Dictionary<char, string>()
        {
            {'A',".-"},
            {'B',"-..."},
            {'C',"-.-."},
            {'D',"-.."},
            {'E',"."},
            {'F',"..-."},
            {'G',"--."},
            {'H',"...."},
            {'I',".."},
            {'J',".---"},
            {'K',"-.-"},
            {'L',".-.."},
            {'M',"--"},
            {'N',"-."},
            {'O',"---"},
            {'P',".--."},
            {'Q',"--.-"},
            {'R',".-."},
            {'S',"..."},
            {'T',"-"},
            {'U',"..-"},
            {'V',"...-"},
            {'W',".--"},
            {'X',"-..-"},
            {'Y',"-.--"},
            {'Z',"--.."},
        };

        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        HashSet<int> lengths = new HashSet<int>();

        public BigInteger Entry(Interact interact)
        {
            string morsecode = interact.ReadNext();
            int nbKnownWords = int.Parse(interact.ReadNext());
            for (int i = 0; i < nbKnownWords; i++)
            {
                string W = interact.ReadNext();
                string EW = Encode(W);
                if (morsecode.Contains(EW))
                {
                    if (!dictionary.ContainsKey(EW))
                    {
                        dictionary.Add(EW, 1);
                    }
                    else
                    {
                        dictionary[EW]++;
                    }

                    if (!lengths.Contains(EW.Length))
                    {
                        lengths.Add(EW.Length);
                    }
                }
            }

            interact.Debug(morsecode);
            interact.Debug(nbKnownWords);
            interact.Debug(dictionary.Count);

            return Solve(morsecode);
        }

        BigInteger Solve(string morsecode)
        {
            Dictionary<int, BigInteger> results = new Dictionary<int, BigInteger>()
            {
                {0,1}
            };

            for (int i = 1; i <= morsecode.Length; i++)
            {
                string toAnalyse = morsecode.Substring(0, i);
                results.Add(i, 0);

                foreach (int length in lengths.Where(l => l <= i))
                {
                    int prefixLength = toAnalyse.Length - length;
                    int nbPossibility = Analyse(toAnalyse.Substring(prefixLength));

                    results[i] += results[prefixLength] * nbPossibility;
                }
            }

            return results[morsecode.Length];
        }

        int Analyse(string currentWord)
        {
            return dictionary.GetValueOrDefault(currentWord);
        }

        string Encode(string word)
        {
            StringBuilder encodedWord = new StringBuilder();

            foreach (char c in word)
            {
                encodedWord.Append(morsetable[c]);
            }

            return encodedWord.ToString();
        }
    }
}
