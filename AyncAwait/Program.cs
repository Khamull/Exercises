namespace AyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSyncWork();
                var test = DoStuffAsync();
                DoSyncAfterAwait();
                test.Wait();
                Console.Read();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Flatten().ToString());
            }
        }

        public static void DoSyncWork()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Some Sync Stuff");
        }
        static async Task DoStuffAsync()
        {
            Console.WriteLine("Async Stuff Start");
            await Task.Delay(5000);
            Console.WriteLine("Async Stuff Done");
        }
        static void DoSyncAfterAwait()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Sync Stuff After Awaited");
        }
        /*
         * Output
            Some Sync Stuff
            Async Stuff Start
            Async Stuff Done
            Sync Stuff After Awaited
         */
    }
}

