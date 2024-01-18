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

            foreach (char c in ransomNote)
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

        public static bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;
            Dictionary<char, char> isoDict = new Dictionary<char, char>();
            for (int index = 0; index < s.Length; index++)
            {
                if (!isoDict.ContainsKey(s[index]))
                {
                    if (isoDict.ContainsValue(t[index]))
                    {
                        return false;
                    }
                    else
                    {
                        isoDict.Add(s[index], t[index]);
                    }
                }
                else if (isoDict[s[index]] != t[index])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool WordPattern(string pattern, string s)
        {
            string[] words = s.Split(' ');
            if (pattern.Length != words.Count()) return false;
            Dictionary<char, string> wordDictionary = new Dictionary<char, string>();
            for (int index = 0; index < words.Length; index++)
            {
                if (!wordDictionary.ContainsKey(pattern[index]))
                {
                    if (wordDictionary.ContainsValue(words[index])) return false;
                    wordDictionary.Add(pattern[index], words[index]);
                }
                else if (wordDictionary[pattern[index]] != words[index])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
