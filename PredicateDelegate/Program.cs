namespace PredicateDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Emp> list = new List<Emp>();
            list.Add(new Emp() { EmpName = "A", EmpSal = 100});
            list.Add(new Emp() { EmpName = "B", EmpSal = 200 });
            list.Add(new Emp() { EmpName = "C", EmpSal = 300 });

            Predicate<Emp> predicate = x => x.EmpSal > 100;
            Emp emp = list.Find(predicate);
            Console.WriteLine(emp.EmpSal);
            Console.Read();
        }
    }
    /*
     * The Output would be 200 Because is the first element that respects the criteria
     * 200
     * This output demonstrates how the Predicate and Find method can be used to efficiently locate and retrieve objects from a list based on specific criteria.
     */
    public class Emp
    {
        public string EmpName { get; set; }
        public int EmpSal { get; set; }
    }
}
