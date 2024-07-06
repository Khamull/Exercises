using System.Collections.ObjectModel;

namespace GenericsCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Step 1: Initializing a List<int> with initial elements
             * A List<T> is a generic collection provided by the .NET Framework that represents
             * a list of objects that can be accessed by index. The <T> denotes that List is a 
             * generic collection. You specify the type of elements it will hold when you create 
             * an instance of List. In this case, List<int> creates a list that holds integers.
             */
            var list = new List<int> { 20, 40, 35, 85, 70 };
            GenericsCollectionsRun(list);
        }

        public static void GenericsCollectionsRun(List<int> list)
        {
            var arr = list;
            /*
             * Step 2: Creating a Collection<int> that wraps around the List<int>
             * Collection<T> is another generic collection provided by the .NET Framework.
             * It is designed to be a base class for custom collections and can wrap around
             * another collection (like a List<T>) to provide additional functionality or 
             * enforce certain behaviors. When a Collection<T> wraps a List<T>, it references 
             * the same data, so any changes to the List<T> are reflected in the Collection<T>.
             */
            var collection = new Collection<int>(arr);
            // Step 3: Adding an element to the List<int>
            arr.Add(60);
            // Step 4: Sorting the List<int> 
            arr.Sort();
            // Step 5: Printing the elements of the Collection<int> (which reflects the sorted List<int>)
            Console.WriteLine(String.Join(",", collection));
            /*Outputs 20,35,40,60,70,85 */
        }
    }
}
