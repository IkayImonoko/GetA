namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var counter = new CharCounter();
            counter.SetText("Ta utgangspunkt i koden");
            counter.Count();
            counter.Show();
        }
    }
}
