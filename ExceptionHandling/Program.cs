namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            //If we use i = 3, for instance, we would not have the issue
            int v = 40;
            int[] p = new int[4];
            try
            {
                p[i] = v;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            foreach(var j in p)
            {
                Console.WriteLine(j.ToString());
            }
            Console.Read();
        }
        /*
         * System.IndexOutOfRangeException: Index was outside the bounds of the array.
         */
    }
}
