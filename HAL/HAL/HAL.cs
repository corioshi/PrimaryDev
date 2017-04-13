using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;


namespace HAL
{
    class HAL
    {
        static void Main(string[] args)
        {
            // import the entire dictionary into one string
            string dict = Properties.Resources.dict;


            //Break up string into an array of strings utilizing string.split
            char[] delimeters = new char[] { '\r', '\n' };
            string[] lines = dict.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

            //Insert each word into binary tree
            SortedDictionary<string, string> d = new SortedDictionary<string, string>();

            foreach (var word in lines)
            {
                d.Add(word, word);
            }

            //foreach (var pair in d)
            //{
            //   Console.WriteLine(pair.Key + " " + pair.Value);
            //}

            //Number of times to shift
            for (int j = 1; j < 26; j++)
            {
                //for each dictionary entry
                foreach (var pair in d)
                {
                    //Create string builder
                    StringBuilder shift = new StringBuilder();
                    string word = pair.Value;

                    //Convert word into array of characters
                    char[] letters = word.ToCharArray();

                    //Iterate over all chars in word
                    for (int i = 0; i < letters.Length; i++)
                    {
                        int letter = (int) letters[i];

                        if (letter + j > 'z') letter -= (26 - j);
                        else letter += j;

                        letters[i] = (char)letter;
                    }

                    Console.WriteLine(letters);
                }
            }           
        }
    }
}

