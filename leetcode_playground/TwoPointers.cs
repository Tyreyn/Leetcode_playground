using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_playground
{
    public class TwoPointers
    {
        /// <summary>
        /// 28. Find the Index of the First Occurrence in a String
        /// </summary>
        public static int StrStr(string haystack, string needle)
        {
            int needleLength = needle.Length;
            int i = 0, j = 0;
            while(haystack.Length > i)
            {
                if (haystack[i] == needle[j])
                {
                    i++;
                    j++;
                    if (needleLength <= j) return i - j;
                }
                else
                {
                    i = i - j + 1;
                    j = 0;
                }
            }

            return -1;
        }

        /// <summary>
        /// 30. Substring with Concatenation of All Words
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static IList<int> FindSubstring(string s, string[] words)
        {
            int len = s.Length, wordLen = words[0].Length, wordCount = words.Length;
            Dictionary<string, int> w = new();
            foreach (string i in words)
            {
                if (w.ContainsKey(i)) w[i]++;
                else w[i] = 1;
            }
            List<int> result = new();

            for (int i = 0; i < wordLen; i = i + wordLen)
            { //normal sliding window start from different index
                int left = i, right = i, count = 0, cur = 0;
                Dictionary<string, int> dict = new(w); // make a copy
                while (right + wordLen <= len)
                {
                    string k = s.Substring(right, wordLen);
                    right += wordLen;  //move right pointer
                    if (dict.ContainsKey(k) && --dict[k] >= 0) cur++;

                    if (++count > wordCount)
                    {
                        string removing = s.Substring(left, wordLen);
                        left += wordLen; //move left pointer
                        if (dict.ContainsKey(removing) && ++dict[removing] > 0) cur--;
                    }

                    if (cur == wordCount) result.Add(left); // add to result
                }
            }
            return result;
        }
    }
}
