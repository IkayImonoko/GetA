namespace _315_D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a sentence:");
            string sentence = ReadSentence();
            string[] words = sentence.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int wordsCount = words.Length;
            string mostVowels = words.Aggregate("", (acc, cur) => CountVowels(cur) > CountVowels(acc) ? cur : acc);
            Console.WriteLine($"Words in the sentence: {wordsCount}\nWord with most vowels is: {mostVowels}\n");
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

        static int CountVowels(string word)
        {
            char[] vowels = { 'a', 'i', 'u', 'e', 'o', 'y', 'æ', 'ø', 'å' };
            return word.ToLower().Count(letter => vowels.Contains(letter));
        }
    }
}
