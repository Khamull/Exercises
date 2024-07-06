namespace ClassTest
{
    /*
     * The line MyClass obj = new MyClass(); 
     * causes a compile-time error because the constructor MyClass() is marked as private. 
     * Private constructors can only be accessed within the same class and are not accessible 
     * from outside the class or its containing namespace (ClassTest in this case). 
     * Therefore, the compiler will prevent you from invoking this constructor directly in the Main method.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyClass obj = new MyClass();
            //To run properly 
            //MyClass obj = new MyClass("any value");
        }
    }
    public class MyClass
    {
        private MyClass() { }
        public MyClass(string val) { }
    }
}
