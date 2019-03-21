using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Web;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class LibraryService : ILibrary
    {

        private static List<Press> Presses;

        private static List<Book> Books;
        

        static LibraryService()
        {
            Presses = new List<Press>()
            {
                new Press(){Name = "O'Relly"},
                new Press(){Name = "Miscrosoft Press"},
                new Press(){Name = "ACER Press"},
                new Press(){Name = "McGraw-Hill Education"}
            };
            
            Books = new List<Book>()
            {
                new Book(){Title = ".NET Book Zero: C#/.NET for C/C++ Developers", Author = "Charles Petzold"},
                new Book(){Title = "The Art of Unix Programming", Author = "Eric Raymond "},
                new Book(){Title = "The Art of Computer Programming", Author = "Donald Knuth"},
                new Book(){Title = "Patterns of Software", Author = "Richard P. Gabriel"},
                new Book(){Title = "Hacker Culture", Author = "Douglas Thomas"},
                new Book(){Title = "The Pragmatic Programmer: From Journeyman to Master", Author = "David Thomas"}
            };
            
        }
        
        
        public IEnumerable<Press> GetAllPRess()
        {
            return Presses;
        }

        public Press GetPress(string index)
        {
            int index1 = int.Parse(index);
            
            if (index1 < 0 || index1 >= Presses.Count)
            {
                throw new IndexOutOfRangeException(); 
            }

            return Presses[index1];
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }

        public Book GetBook(string index)
        {
            int index1 = int.Parse(index);
            
            if (index1 < 0 || index1 >= Presses.Count)
            {
                throw new IndexOutOfRangeException(); 
            }

            return Books[index1];
        }
    }
}