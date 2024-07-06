using System.Xml.Serialization;

namespace GenericTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("############# Hello, World! ####################");
            // Creating persons Instances
            Person person1 = new Person("Alice", 30);
            Person person2 = new Person("Bob", 25);
            // Creating Containers with persons
            MyContainer<Person> container1 = new MyContainer<Person>(person1);
            MyContainer<Person> container2 = new MyContainer<Person>(person2);

            // Comparing
            int comparisonResult = container1.CompareTo(container2);

            // Showing off results
            if (comparisonResult > 0)
            {
                Console.WriteLine($"{container1.Value} is older than {container2.Value}");
            }
            else if (comparisonResult < 0)
            {
                Console.WriteLine($"{container1.Value} is younger than {container2.Value}");
            }
            else
            {
                Console.WriteLine($"{container1.Value} is the same age as {container2.Value}");
            }
        }
    }
    
    
    //Which statements are correct regarding the following code snippet?
    //public class MyContainer<T> where T : class, IComparable
    //{
        // Correct statements:
        //
        // 1. Class MyContainer requires that its type argument must implement the IComparable interface.
        //    - Correct. The constraint 'where T : IComparable' requires that the type 'T' implements the IComparable interface,
        //      allowing comparison operations on instances of 'T'.
        //
        // 2. Compiler will report an error for this block of code.
        //    - Incorrect. Without specific context or errors indicated, assuming the provided code snippet is complete and valid,
        //      it should compile correctly as long as 'T' satisfies the constraints.
        //
        // 3. There are multiple constraints on type argument to MyContainer class.
        //    - Correct. The 'where T : class, IComparable' specifies two constraints: 'class' requires 'T' to be a reference type,
        //      and 'IComparable' requires 'T' to implement the IComparable interface.
        //
        // 4. Class MyContainer requires that its type argument be a reference type and it must implement the IComparable interface.
        //    - Correct. The combined constraints 'where T : class, IComparable' ensure that 'T' must be a reference type and
        //      must implement the IComparable interface, enabling comparison operations within the generic class.
    //}

    /*############## Usage Sample ################*/
    public class MyContainer<T> where T : class, IComparable
    {
        private T value;

        // Constructor with T value
        public MyContainer(T value)
        {
            this.value = value;
        }

        // Public access to set and get the T Value
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        // Compare Both Containers
        public int CompareTo(MyContainer<T> other)
        {
            if (other == null)
            {
                return 1; //Any grater then null
            }
            return this.value.CompareTo(other.value);
        }
    }

    // Class that implements IComparable
    public class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Method to age compare
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Person otherPerson = obj as Person;
            if (otherPerson != null)
                return this.Age.CompareTo(otherPerson.Age);
            else
                throw new ArgumentException("Object is not a Person");
        }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}";
        }
    }
}
