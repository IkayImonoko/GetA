namespace _315_D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vowels = { 'a', 'i', 'u', 'e', 'o', 'y', 'æ', 'ø', 'å' };
            string sentence = "";
            string exit = "exit";

            while (true)
            {
                Console.WriteLine("Write a sentence:");
                sentence = ReadSentence();
                if (sentence == exit)
                {
                    break;
                }
                string[] words = sentence.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int wordsCount = words.Length;
                string mostVowels = words.Aggregate("", (acc, cur) => CountLetters(cur, vowels) > CountLetters(acc, vowels) ? cur : acc);
                string longestWords = words.Aggregate("", (acc, cur) => CountLetters(cur) > CountLetters(acc) ? cur : acc);
                Console.WriteLine($"Words in the sentence: {wordsCount}\nWord with most vowels is: {mostVowels}\nLongest word is: {longestWords}\n");
            }
        }

        static string ReadSentence()
        {
            string sentence = "";
            while (!(sentence.Length > 0))
            {
                try
                {
                    sentence = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sentence))
                    {
                        Console.WriteLine("it is null or space");
                        continue;
                    }
                }
                catch (IOException) { }
                catch (OutOfMemoryException) { }
                catch (ArgumentOutOfRangeException) { }
            }

            return sentence;
        }

        static int CountLetters(string word, char[] alphabet = null)
        {
            if (string.IsNullOrEmpty(word))
            {
                return 0;
            }
            if (alphabet == null)
            {
                return word.Length;
            }
            else
            {
                return word.ToLower().Count(letter => alphabet.Contains(char.ToLower(letter)));
            }
        }
    }
}
