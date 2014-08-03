using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EgyenlitoMvc.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWinEventService" in both code and config file together.
    [ServiceContract]
    public interface IWinEventService
    {
        [WebGet(UriTemplate="GetEvents")]
        [OperationContract]
        string GetEvents();
        [WebGet(UriTemplate="GetUpholders")]
        [OperationContract]
        string GetUpholders();
    }
}
