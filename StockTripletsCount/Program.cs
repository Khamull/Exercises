namespace StockTripletsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 3, 4, 7, 8 };
            int d = 5;

            /*Some possible edgecases*/
            /*
             * int[] arr = { 1, 2, 3 };
             * int d = 3;
             * Expected output: Number of distinct triplets with sum divisible by 3: 1
             */

            /*
             * int[] arr = { 1000000000, 2000000000, 3000000000 };
             * int d = 5;
             * Expected output: Number of distinct triplets with sum divisible by 5: 1
             */

            /*
             * int[] arr = { 2, 2, 2, 2, 2 };
             * int d = 3;
             * Expected output: Number of distinct triplets with sum divisible by 3: 6
             */

            /*
             * Random random = new Random();
             * int[] arr = new int[1000];
             * for (int i = 0; i < 1000; i++)
             * {
             *      longCase1[i] = random.Next(1, 1000000000);
             * }
             * int d = 10;
             * Expected output: Number of distinct triplets with sum divisible by 10: ?
             */
            /*
             * int[] arr = { 3, 3, 4, 7, 8 };
             * int d = 1000000;
             * Expected output: Number of distinct triplets with sum divisible by 1000000: ?
             */

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
/*
 * We have the cost of stocks on each day given in a array arr. An investor wants to buy the stocks in triplets, such that the sum of the cost for three days id divisible dy d!
The goal is to find the number of distinct triplets (i, j, k) such that i < J < K and the sum of (arr[i] + arr[j] + arr[k]) is divisble by d
For instance let arr[3,3,4,7,8] and d = 5, the triplets sum is divisible by d are the below:
Triplets with index (0,1,2), sum= 3+3+4=10
Triplets with index (0,2,4), sum= 3+4+8=15
Triplets with index (1,2,4), sum= 3+4+8=15
So, the answer is 3

I will have a function called getTripletCount, it receives an array arr[n], and a d, the divisor!

Constrains:
3 <= n <= 10^3
1 <= arr[i] <= 10^9
2 <= d <= 10 ^6
 */
