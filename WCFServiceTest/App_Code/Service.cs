using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Services;

namespace WCFServiceTest
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(Namespace = "http://tempuri.com", AddressFilterMode = AddressFilterMode.Any)]
    public class Service : IService
    {
        [WebGet(UriTemplate="/FileList?datum={datum}", BodyStyle = WebMessageBodyStyle.Bare)]
        //[WebInvoke(Method ="POST", UriTemplate = "/test/{value}")]
        //[WebMethod()]
        public System.IO.Stream GetFileList(string datum)
        {
            int i;
            var dt = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(int.Parse(datum));
            

            OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
            string data =  string.Format("<filelist><file><path></path><time>{0}</time><hash></hash></file></filelist>",dt);
           /* if (image_not_found_in_DB)
            {
                context.StatusCode = System.Net.HttpStatusCode.Redirect;
                context.Headers.Add(System.Net.HttpResponseHeader.Location, url_of_a_default_image);
                return null;
            }*/

            // everything is OK, so send image

            context.Headers.Add(System.Net.HttpResponseHeader.CacheControl, "public");
            context.ContentType = "application/xml";
            context.LastModified = DateTime.Now;
            context.StatusCode = System.Net.HttpStatusCode.OK;
            return new System.IO.MemoryStream(Encoding.UTF8.GetBytes(data));
        }



        [WebGet(UriTemplate = "/GetFile?path={path}", BodyStyle = WebMessageBodyStyle.Bare)]       

        public Stream GetFileList2(string path)
        {
          
            var data = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +"<filelist><file><path></path><time></time><hash></hash></file></filelist>";
            //var Response = HttpContext.Current.Response;
            //Response.Clear();
            //Response.Write(data);
            //Response.ContentType = "text/xml";
            //Response.End();
            return null;
        }

        public void DownloadFile(string path)
        {
            //var client = new HttpClient();
            //var response = await client.GetAsync(@"http://localhost:9000/api/file/GetFile?filename=myPackage.zip");

            //using (var stream = await response.Content.ReadAsStreamAsync())
            //{
            //    var fileInfo = new FileInfo("myPackage.zip");
            //    using (var fileStream = fileInfo.OpenWrite())
            //    {
            //        await stream.CopyToAsync(fileStream);
            //    }
            //}
        }
    }

    [DataContract]
    public class PurchaseOrder
    {
        [DataMember]
        public Address billTo;
        [DataMember]
        public Address shipTo;
    }

    [DataContract]
    public class Address
    {
        [DataMember]
        public string street;
    }
}
