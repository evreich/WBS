using System;
using System.Net;
using Microsoft.SharePoint.Client;
using ServiceReference1;
namespace ReferenceWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientContext cc = new ClientContext("http://192.168.88.69:3333/");
            cc.Credentials = new NetworkCredential("auchan_admin", "P@ssWord*1!", "Qpd");
            Web web = cc.Web;

            List list = web.Lists.GetByTitle("DaiRequestsNew");

            CamlQuery caml = new CamlQuery();

            ListItemCollection items = list.GetItems(caml);

            cc.Load<List>(list);
            cc.Load<ListItemCollection>(items);
            cc.ExecuteQuery();

            foreach (ListItem item in items)

            {

                Console.WriteLine(item.FieldValues["Title"]);

            }

            Console.ReadLine();
            //GetList();
        }
        //async static void GetList()
        //{
        //    var entity = new GetListItemsRequest()
        //    {
        //        Body = { listName = " ", query = new System.Xml.Linq.XElement(" "), queryOptions = new System.Xml.Linq.XElement(" "), rowLimit = " ",
        //            viewFields = new System.Xml.Linq.XElement(" "), viewName = " ", webID = " " }
        //    };

        //    var entity = new GetListItemsRequest();
        //    var listName = entity.Body.listName;
        //    var query = entity.Body.query;
        //    var queryOptions = entity.Body.queryOptions;
        //    var rowLimit = entity.Body.rowLimit;
        //    var viewFields = entity.Body.viewFields;
        //    var viewName = entity.Body.viewName;
        //    var webID = entity.Body.webID;
        //    var client = new ListsSoapClient(ListsSoapClient.EndpointConfiguration.ListsSoap);
        //    var list = await client.GetListItemsAsync(entity.Body.listName, entity.Body.viewName, entity.Body.query, entity.Body.viewFields, entity.Body.rowLimit, entity.Body.queryOptions, entity.Body.webID);
        //}

    }
    
}
