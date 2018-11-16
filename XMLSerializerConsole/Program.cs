using RestSharp;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Script.Serialization;
using XMLSerializerCommon.Models;
using XMLSerializerCommon.Shared;

namespace XMLSerializerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a argument.");
                return;
            }

            int argNumber;
            bool isParseSuccess = int.TryParse(args[0], out argNumber);
            if (!isParseSuccess)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                return;
            }

            if (argNumber <= 0)
            {
                System.Console.WriteLine("Enter a number greater than 0.");
                return;
            }

            List<RequestApiModel> requestApiModelList = RequestApiModelDataGenerator.GetRandomRequestApiModel(argNumber);
            var jsonRequestApiModelList = new JavaScriptSerializer().Serialize(requestApiModelList);

            string XMLSerializerApiURLConfig = ConfigurationManager.AppSettings["XMLSerializerApiURL"];

            var client = new RestClient(XMLSerializerApiURLConfig);

            var request = new RestRequest(Method.POST);

            request.AddJsonBody(requestApiModelList);
            request.RequestFormat = DataFormat.Json;

            var result = client.Execute(request);
        }
    }
}
