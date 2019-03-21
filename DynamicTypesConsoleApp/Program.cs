using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicTypesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = TypeGenerator.GenerateController();
            var dynamicApi = assembly.GetType("DynamicApi");
            Console.WriteLine(dynamicApi);
#if NET472
            //string path = Path.GetDirectoryName(typeof(Program).Assembly.Location);

            //var ass = Assembly.Load(Path.Combine(path, "DynamicAssembly.dll"));
            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }
#else

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }
#endif


        }
    }
}