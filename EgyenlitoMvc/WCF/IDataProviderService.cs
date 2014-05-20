using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EgyenlitoMvc.WCF
{
    [ServiceContract]
    public interface IDataProviderService
    {
        [OperationContract]
        string GetNewspapers();
        [OperationContract]
        string GetAllArticles();
        [OperationContract]
        string GetArticles(int newspaperId);
    }
}
