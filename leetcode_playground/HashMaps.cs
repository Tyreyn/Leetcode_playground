using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            Dictionary<char, int> letterDictionary = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!letterDictionary.ContainsKey(c))
                {
                    letterDictionary.Add(c, 1);
                }
                else if (letterDictionary.ContainsKey(c))
                {
                    letterDictionary[c]++;
                }
            }

            foreach (char c in t)
            {
                if (letterDictionary.ContainsKey(c) && letterDictionary[c] > 0)
                {
                    letterDictionary[c]--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {

                int tmp = target - nums[i];
                if (result.ContainsKey(tmp)) return new int[] { result[tmp], i };
                result[nums[i]] = i;

            }

            return new int[] { };
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] arr = strs[i].ToCharArray();
                Array.Sort(arr);
                String sorted = new String(arr);

                if (!dict.ContainsKey(sorted))
                {
                    dict.Add(sorted, new List<String>() { strs[i] });
                }
                else
                {
                    dict[sorted].Add(strs[i]);
                }
            }

            return dict.Values.ToList();
        }
    }
}