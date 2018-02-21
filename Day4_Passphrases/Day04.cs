using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Passphrases
{
    public class Day04
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day4_Passphrases\\input.txt"))
            {
                var input = sr.ReadToEnd();
                Console.WriteLine(CountValidPassphrasesHard(input));
                Console.ReadKey();
            }
        }

        public static int CountValidPassphrases(string input)
        {
            var phrases = input?.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var result = 0;
            foreach (var phrase in phrases)
            {
                var words = phrase.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var uniqueWords = new List<string>();
                var isPhraseValid = true;

                foreach (var word in words)
                {
                    if (string.IsNullOrEmpty(uniqueWords.Find(w => w == word)))
                    {
                        uniqueWords.Add(word);
                    }
                    else
                    {
                        isPhraseValid = false;
                    }
                }

                if (isPhraseValid)
                    result++;
            }

            return result;
        }

        public static int CountValidPassphrasesHard(string input)
        {
            var phrases = input?.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var result = 0;
            foreach (var phrase in phrases)
            {
                var words = phrase.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var uniqueWords = new List<string>();
                var isPhraseValid = true;

                foreach (var word in words)
                {
                    var chars = word.ToCharArray().ToList();
                    chars.Sort();
                    var searchWord = new string(chars.ToArray());
                    var isFound = uniqueWords.FindIndex(w => w == searchWord) >= 0;
                    if (isFound)
                    {
                        // phrase is not valid
                        isPhraseValid = false;
                        break;
                    }
                    else
                    {
                        uniqueWords.Add(searchWord);
                    }
                }

                if (isPhraseValid)
                    result++;
            }

            return result;
        }
    }
}
