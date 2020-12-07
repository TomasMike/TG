using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]

    public interface IService
    {

        [OperationContract]
        System.IO.Stream GetFileList(string datum);

        [OperationContract]
        Stream GetFileList2(string path);
    }
}