using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace ODataService.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public Address Location { get; set; }

        public Press Press { get; set; }
    }

    public class Press
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Category Category { get; set; }
    }

    public enum Category
    {
        Book,
        Magazine,
        EBook
    }

    public class Address
    {
        public string City { get; set; }

        public string Street { get; set; }
    }
}