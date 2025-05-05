namespace Advent2020_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("trueData.txt");
            var sortedJolts = new SortedSet<int>();
            
            // Part 1
            foreach (var line in lines)
            {
                sortedJolts.Add(int.Parse(line));
            }
            sortedJolts.Add(0); // Add the charging outlet
            sortedJolts.Add(sortedJolts.Max() + 3); // Add built-in adapter of the device

            var diffs = new List<int>();
            int oldjolt = 0;
            foreach (var jolt in sortedJolts)
            {
                int diff = jolt - oldjolt;
                diffs.Add(diff);
                oldjolt = jolt;
            }
            int numberOfOnes = diffs.Count(x => x == 1);
            int numberOfThrees = diffs.Count(x => x == 3);
            int answer = numberOfOnes * (numberOfThrees + 1);
            //Console.WriteLine($"The answer is {answer}.");
            // Part 2
            //foreach (var jolt in sortedJolts)
            //{
            //    Console.WriteLine(jolt);
            //}
            var memo = new Dictionary<int, long>();
            int max = sortedJolts.Last();
            Console.WriteLine($"Max: {max}");
            long answer2 = CountArrangementsToJolt(max, sortedJolts, memo);
            Console.WriteLine(answer2);
        }
        static long CountArrangementsToJolt(int jolt, SortedSet<int> sortedJolts,  Dictionary<int, long> memo)
        {
            long count = 0;
            if (memo.ContainsKey(jolt)) return memo[jolt];
            if (jolt == 0) return 1;
            
            // Do stuff
            for (int i = 1; i<=3; i++)
            {
                //Console.WriteLine(i);
                if (sortedJolts.Contains(jolt - i))
                {
                    //Console.WriteLine("Found a jolt");
                    count = count + CountArrangementsToJolt(jolt - i, sortedJolts, memo);
                }
            }
            
            memo[jolt] = count;
            return count;
        }
            
    }
}