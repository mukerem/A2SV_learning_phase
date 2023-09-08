using System;
using System.Collections.Generic;

public class WordCounter
{
    public static Dictionary<string, int> CountWords(string input)
    {
        input = input.ToLower();

        char[] punctuation = new char[] { '.', ',', ';', '!', '?', ':', '-', '_', '(', ')', '[', ']', '{', '}', '\'', '\"' };
        foreach (var punct in punctuation)
        {
            input = input.Replace(punct, ' ');
        }

        string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (!wordCounts.ContainsKey(word))
            {
                // Initialize word count for this word
                wordCounts[word] = 0;
            }
            wordCounts[word]++;
            
        }

        return wordCounts;
    }

    public static void Main(string[] args)
    {
        string testString = "This is a sample string, this is another sample.";
        Dictionary<string, int> result = CountWords(testString);

        foreach (var entry in result)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}

