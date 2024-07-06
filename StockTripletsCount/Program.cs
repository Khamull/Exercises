namespace StockTripletsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 3, 4, 7, 8 };
            int d = 5;
            int tripletCount = GetTripletCount(arr, d);
            Console.WriteLine($"Number of distinct triplets with sum divisible by {d}: {tripletCount}");
        }

        public static int GetTripletCount(int[] arr, int d)
        {
            int n = arr.Length;
            int[] prefixSum = new int[n];
            prefixSum[0] = arr[0];

            // Calculate prefix sums
            for (int i = 1; i < n; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + arr[i];
            }

            // Dictionary to store frequency of remainders
            Dictionary<int, int> remainderCount = new Dictionary<int, int>();
            remainderCount.Add(0, 1); // Base case for empty prefix sum

            int tripletCount = 0;

            // Iterate through prefix sums to count valid triplets
            for (int j = 0; j < n; j++)
            {
                int prefixSumJMod = prefixSum[j] % d;
                int target = (prefixSumJMod - d + d) % d; // ensure positive remainder

                Console.WriteLine($"Processing prefixSum[{j}] = {prefixSum[j]}, remainder = {prefixSumJMod}");
                Console.WriteLine($"Target remainder = {target}");

                if (remainderCount.ContainsKey(target))
                {
                    Console.WriteLine($"Found {remainderCount[target]} valid pairs for current j");
                    tripletCount += remainderCount[target];
                }

                // Update the remainder count
                if (remainderCount.ContainsKey(prefixSumJMod))
                {
                    remainderCount[prefixSumJMod]++;
                }
                else
                {
                    remainderCount.Add(prefixSumJMod, 1);
                }

                Console.WriteLine($"Updated remainder count for {prefixSumJMod} to {remainderCount[prefixSumJMod]}");
                Console.WriteLine();
            }

            return tripletCount;
        }
    }

}
