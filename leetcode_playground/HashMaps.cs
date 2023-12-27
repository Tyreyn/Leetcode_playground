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
            Dictionary<char, int> ransomNoteDict = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                magazineDict[magazine[i]]++;
                ransomNoteDict[ransomNote[i]]++;
            }

            foreach(KeyValuePair<char, int> keyValuePair in ransomNoteDict)
            {
                if(keyValuePair.Value > magazineDict[keyValuePair.Key])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
