using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming
{
    class sampleClass : IDisposable
    {
        private string name = string.Empty;

        public sampleClass(string name)
        {

            this.name = name;
            Console.WriteLine("Cosntructor for {0} object is created", this.name);
        }

        ~sampleClass()
        {
            Console.WriteLine("The object by name {0} is destroyed", name);
        }

        public void Dispose()
        {

            Console.WriteLine("The object by name {0} is destroyed using Dispose", name);
            GC.SuppressFinalize(this);
        }

        class Ex01MemoryManagement
        {

            static void createandDestroyObjects()
            {
                for (int i = 0; i < 10000; i++)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    using (sampleClass cls = new sampleClass("ClsName" + i))
                    {

                    }
                }
            }

            static void Main(string[] args)
            {
                createandDestroyObjects();
                Console.WriteLine("Time to terminate this App");
            }

        }
    }
}

