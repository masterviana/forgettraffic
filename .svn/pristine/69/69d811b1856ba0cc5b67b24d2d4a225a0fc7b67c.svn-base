using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace ForgetTraffic.ServiceREST
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in the associated .svc file.
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ForgetTraffic
    {
        // TODO: Implement the collection resource that will contain the SampleItem instances

        [WebGet(UriTemplate = ""), OperationContract]
        public List<SampleItem> GetCollection()
        {
            // TODO: Replace the current implementation to return a collection of SampleItem instances
            return new List<SampleItem>() { new SampleItem() { Id = 1, StringValue = "O Nando é Gay" },new SampleItem(){Id = 2, StringValue = "O vitor é grande"} };
        }

        [WebInvoke(UriTemplate = "", Method = "POST"), OperationContract]
        public SampleItem Create(SampleItem instance)
        {
            // TODO: Add the new instance of SampleItem to the collection
            throw new NotImplementedException();
        }

        [WebGet(UriTemplate = "{id}"), OperationContract]
        public SampleItem Get(string id)
        {
            // TODO: Return the instance of SampleItem with the given id
            throw new NotImplementedException();
        }

        [WebInvoke(UriTemplate = "{id}", Method = "PUT"), OperationContract]
        public SampleItem Update(string id, SampleItem instance)
        {
            // TODO: Update the given instance of SampleItem in the collection
            throw new NotImplementedException();
        }

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE"), OperationContract]
        public void Delete(string id)
        {
            // TODO: Remove the instance of SampleItem with the given id from the collection
            throw new NotImplementedException();
        }

    }
}
