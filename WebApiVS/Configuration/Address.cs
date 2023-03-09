using System.Runtime.Serialization;

namespace WebApiVS.Configuration
{
    /// <summary>
    /// Адрес дома
    /// </summary>
    [DataContract]
    public class Address
    {
        [DataMember]
        public int House { get; set; }
        [DataMember]
        public int Building { get; set; }
        [DataMember]
        public string Street { get; set; }
    }
}
