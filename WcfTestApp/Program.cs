using System;
using System.CodeDom;
using System.ServiceModel.Web;
using ConsoleApplication1.Services;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Uri url = new Uri("http://localhost:8080/library");
            var host = new WebServiceHost(typeof(LibraryService), url);
            host.Open();
            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine($"Service is hosting on: {endpoint.Address}");
            }
            
            Console.WriteLine("Host is running. Press any key to exit...");
            Console.ReadKey();
            
            host.Close();
        }
    }
}