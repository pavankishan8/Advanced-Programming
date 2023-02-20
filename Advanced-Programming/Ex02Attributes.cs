using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Advanced_Programming
{

    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class MyCustomAttribute : Attribute
    {
        private string _message = string.Empty;
        private string _access = string.Empty;

        public MyCustomAttribute(string access, string message)
        {
            _message = message;
            _access = access;
        }

        public string Message
        {
            get { return _message; }
        }

        public string Access => _access;

    }

    [Flags]
    enum Colors
    {
        Red = 1, Blue = 2, Green = 3, Yellow = 4, White = 5, Black
    }

    [MyCustom("User Defined Class", "This represents the Customer")]
    class Customer
    {
        [MyCustom("Property", "Represents the Id of the Customer")]
        public int CustomerID { get; set; }
    }

    class Ex02Attributes
    {
        [Obsolete("This function is no longer recommended, U can try the new version called testingFunc")]
        static void testFunc()
        {
            Console.WriteLine("Test Func");
        }

        static void testingFunc() => Console.WriteLine("Test Func");

        static void readCustomAttributes()
        {
            Customer cst = new Customer();
            var attribute = cst.GetType().GetCustomAttribute<MyCustomAttribute>();

            if (attribute != null)
            {
                Console.WriteLine(attribute.Message);
                Console.WriteLine(attribute.Access);
            }
            else
                Console.WriteLine("Attribute not set for this class");

            var properties = cst.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var propAttr = prop.GetCustomAttribute<MyCustomAttribute>();

                if (propAttr != null)
                {
                    Console.WriteLine("The Name of the Property: " + prop.Name);
                    Console.WriteLine("Attribute for the property: " + propAttr.GetType().Name);
                    Console.WriteLine($"Values of the Attribute:\nAccess : {propAttr.Access}\nMessage: {propAttr.Message}");
                    Console.WriteLine(propAttr.Message);
                }
            }
        }
        static void Main(string[] args)
        {
            //testFunc();
            //testingFunc();
            readCustomAttributes();
            //Colors colors = Colors.Red | Colors.Green;
            //Console.WriteLine(colors.ToString());
        }
    }
}
