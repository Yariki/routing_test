using System.Runtime.Serialization;

namespace ConsoleApplication1.Models
{
    [DataContract]
    public class Press
    {
        [DataMember]
        public string Name { get; set; }
    }
     
}