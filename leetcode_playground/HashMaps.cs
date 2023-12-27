using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_playground
{
    public class HashMaps
    {
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            if (magazine.Length < ransomNote.Length) return false;
            Dictionary<char, int> magazineDict = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (!magazineDict.ContainsKey(magazine[i]))
                {
                    magazineDict.Add(magazine[i], 1);
                }
                else
                {
                    magazineDict[magazine[i]]++;
                }
            }

            foreach(char c in ransomNote)
            {
                if (magazineDict.ContainsKey(c))
                {
                    if (magazineDict[c] > 0)
                    {
                        magazineDict[c]--;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
