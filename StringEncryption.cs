using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    public class StringEncryption
    {
        public static string StringEncryptor(string s)
        {
            var phrase = s.Split(' ').Aggregate((a, b) => a + b).ToString();

            if(phrase.Length == 1) return phrase;

            var col = (int)Math.Sqrt(phrase.Length);
            var row = col;

            if(phrase.Length > col * col) row = col + 1;

            var words = new string[row];
            var index = 0;

            for(var i = 0; i < phrase.Length; i++)
            {
                if (index >= row ) index = 0;
                words[index] = words[index] + phrase[i];
                index++;
            }

            return string.Join(" ", words);
        }
    }
}