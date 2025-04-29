namespace Advent2020_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("trueData.txt");
            var jolts = new SortedSet<int>();
            
            // Part 1
            foreach (var line in lines)
            {
                jolts.Add(int.Parse(line));
            }
            var diffs = new List<int>();
            int oldjolt = 0;
            foreach (var jolt in jolts)
            {
                int diff = jolt - oldjolt;
                diffs.Add(diff);
                oldjolt = jolt;
            }
            int numberOfOnes = diffs.Count(x => x == 1);
            int numberOfThrees = diffs.Count(x => x == 3);
            int answer = numberOfOnes * (numberOfThrees + 1);
            Console.WriteLine($"The answer is {answer}.");

        }
    }
}