using System;

public class Palindrome
{
    public static bool isPalindrome(string input)
    {
        input = input.ToLower();

        char[] punctuation = new char[] { ' ', '.', ',', ';', '!', '?', ':', '-', '_', '(', ')', '[', ']', '{', '}', '\'', '\"' };
        foreach (var punct in punctuation)
        {
            input = input.Replace(punct.ToString(), "");
        }

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reverseString = new string(charArray);

        return input == reverseString;
    }

    public static void Main(string[] args)
    {
        string testString = "Racecar.";
        bool ispal = isPalindrome(testString);

        if(ispal)
            Console.WriteLine($"{testString} is a palindrome");
        else
            Console.WriteLine($"{testString} is not a palindrome");
    }
}

