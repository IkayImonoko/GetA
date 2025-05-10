namespace _315_D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a sentence:");
            string sentence = ReadSentence();
            string[] words = sentence.Split(new[] { ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            int wordsCount = words.Length;
            Console.WriteLine($"Words in the sentence:{wordsCount}\n");
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
    }
}
