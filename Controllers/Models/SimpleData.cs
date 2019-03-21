using System.Runtime.Serialization;

namespace Controllers.Models
{
    [DataContract]
    public class SimpleData
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Year { get; set; }
    }
}