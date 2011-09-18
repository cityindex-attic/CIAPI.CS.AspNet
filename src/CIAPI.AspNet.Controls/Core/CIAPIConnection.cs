using System.Runtime.Serialization;

namespace CIAPI.AspNet.Controls.Core
{
    [DataContract]
    public class CIAPIConnection
    {
        public CIAPIConnection()
        {
            isConnected = false;
        }
        [DataMember]
        public bool isConnected { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public string ServiceUri { get; set; }
        [DataMember]
        public string StreamUri { get; set; }
    }
}