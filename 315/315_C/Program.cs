namespace _315_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string argument = args.Length > 0 ? args[0] : "";
            
            while (!(argument.Length > 0) || string.IsNullOrWhiteSpace(argument))
            {
                try
                {
                    Console.WriteLine("You send no argument, try again");
                    argument = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(argument))
                    {
                        Console.WriteLine("it is null or space");
                        continue;
                    }
                }
                catch (IOException) { }
                catch (OutOfMemoryException) { }
                catch (ArgumentOutOfRangeException) { }
            }
            char[] letters = argument.ToCharArray();
            Array.Reverse(letters);
            Console.WriteLine(new string(letters));
        }
    }
}
