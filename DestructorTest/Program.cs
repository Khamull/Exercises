namespace DestructorTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //using(MyClass obj = new MyClass()) //Original Example
            //{
            //    obj.MyMethod();
            //}

            using (MyClassTwo obj = new MyClassTwo()) //Correct
            {
                obj.MyMethod();
            }
        }
    }

    public class MyClass
    {
        public MyClass() { }
        public void MyMethod()
        {
            Console.WriteLine("MyMethodCalled");
        }
        ~MyClass()
        {
            Console.WriteLine("Destructor Called");
        }
    }
    public class MyClassTwo : IDisposable
    {
        public MyClassTwo() { }
        public void MyMethod()
        {
            Console.WriteLine("MyMethodCalledTwo");
        }

        public void Dispose()
        {
            Console.WriteLine("Destructor Called");
        }
    }
}
/*
 * We get a Compiler Error because in C#, the using is created to work with types that impelment the IDisposable interface, the MyClassTwo Implements the fix
 * IDisposable used when we need deterministic cleanup, while the common ~destructor we do not have any agency on when it will run, also, should be used for non managed resources, like a DB Connection or file access
 */