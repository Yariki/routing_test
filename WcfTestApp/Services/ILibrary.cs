using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Services
{
    [ServiceContract]
    public interface ILibrary
    {
        [OperationContract]
        [WebInvoke(Method = "GET",BodyStyle = WebMessageBodyStyle.Bare,RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Press> GetAllPRess();

        [OperationContract]
        [WebInvoke(Method = "GET",BodyStyle = WebMessageBodyStyle.Bare,RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,UriTemplate = "GetPress/{index}")]
        Press GetPress(string index);

        [OperationContract]
        [WebInvoke(Method = "GET",BodyStyle = WebMessageBodyStyle.Bare,RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Book> GetAllBooks();

        [OperationContract]
        [WebInvoke(Method = "GET",BodyStyle = WebMessageBodyStyle.Bare,RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,UriTemplate = "GetBook/{index}")]
        Book GetBook(string index);
    }
}