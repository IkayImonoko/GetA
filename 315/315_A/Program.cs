namespace _315_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var number = random.Next(1, 100);

            Console.WriteLine("Guess a number from 0 to 100");
            var guessedNumber = ParseNumber();

            while (guessedNumber != number)
            {
                if (guessedNumber > number)
                {
                    Console.WriteLine("Too much, try again");
                }
                else
                {
                    Console.WriteLine("Too little, try again");
                }
                guessedNumber = ParseNumber();
            }

            Console.WriteLine($"you win, a secret number was {number}");
        }

        static int ParseNumber()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("it is null or space");
                        continue;
                    }

                    int number = int.Parse(input);
                    return number;
                }
                catch (FormatException) { Console.WriteLine("Your input is not a number, idiot"); }
                catch (OverflowException) { Console.WriteLine("Try the infinity next time"); }
                catch (ArgumentNullException) { Console.WriteLine("You're one of them who divides by 0 aren't you?"); }
            }

        }
    }
}
