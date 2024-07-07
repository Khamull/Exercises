using System.Threading.Tasks.Dataflow;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool calcetoken = true;
            //Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Executing Task");
            //    if (calcetoken)
            //    {
            //        Console.WriteLine("Request Received");
            //    }
            //});
            //System.Threading.Thread.Sleep(1000);
            //Console.WriteLine("CAlecclin the task");
            //calcetoken = false;
            //Console.Read();
            //A ob = new B();
            //ob.MethodA();
            //MyClass11 obj = new MyClass11();
            //MyClass11.setObject(obj);
            //Console.WriteLine(obj.MyValue);

            //B2 obj = new B2();
            //obj.j = 1;
            //obj.i = 8;
            //obj.display();
            //Console.ReadLine();
            string s = "bcada";
            int count = GetAllUniqueCharactersSubstring(s);

            Console.WriteLine("Total number of substrings with no repeating characters: " + count);

        }
        static int GetAllUniqueCharactersSubstring(string s)
        {
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> seen = new HashSet<char>();
                for (int j = i; j < s.Length; j++)
                {
                    if (seen.Contains(s[j]))
                    {
                        break;
                    }
                    seen.Add(s[j]);
                    count++;
                }
            }

            return count;
        }
        //private static void Mehtod() { Task.Run(new Action(Method2)); Console.WriteLine("New Thread");}
        //private static void Method2() { Thread.Sleep(2000); Console.WriteLine("MEthod 2"); }

    }
    public class A
    {
        public void MethodA()
        { 
            Console.WriteLine("From A"); 
        }
    }
    public class B : A
    {
        public new void MethodA() { Console.WriteLine("FROM B"); }
    }

    public class MyClass11 {
        public int MyValue = 10;
        public void PrintMyValue()
        {
            Console.WriteLine($"{MyValue}");
        }
        public void SetMyValue(int i) 
        {
            this.MyValue = i;
        }
        public static void setObject(MyClass11 obj)
        {
            obj = new MyClass11();
            obj.SetMyValue(123);
        }
    }

    public class A2 
    {
        public int i; 
        public void display()
        {
            Console.WriteLine(i);
        }
    }
    public class B2 : A2
    {
        public int j;
        public void display()
        {
            Console.WriteLine(j);
        }
    }


}
