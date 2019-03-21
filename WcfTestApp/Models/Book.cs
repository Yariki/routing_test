using System.Runtime.Serialization;

namespace ConsoleApplication1.Models
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Author { get; set; }
        
    }
}