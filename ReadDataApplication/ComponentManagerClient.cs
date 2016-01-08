using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ReadDataApplication.Proxies
{
    public class ComponentManagerClient : ClientBase<IComponentManager>, IComponentManager
    {
        public IEnumerable<PersonalData> ReadData()
        {
            return Channel.ReadData();
        }

        public Task<IEnumerable<PersonalData>> ReadDataAsync()
        {
            return Channel.ReadDataAsync();
        }
    }

    [ServiceContract]
    public interface IComponentManager
    {
        [OperationContract]
        IEnumerable<PersonalData> ReadData();

        [OperationContract]
        Task<IEnumerable<PersonalData>> ReadDataAsync();
    }

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/ReaderComponentService")]
    public class PersonalData
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
