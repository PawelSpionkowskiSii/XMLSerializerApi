using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMLSerializerApi.Helpers;
using XMLSerializerApi.Models;
using XMLSerializerApi.Models.XmlSerializer;

namespace XMLSerializerApi.Generator.File
{
    public class FileGenerator : IFileGenerator
    {
        public void RunInternalJobTOUpdoadFiles(List<RequestModel> requestModelList)
        {
            Task task = Task.Run(() => InternalJobTOUpdoadFiles(requestModelList));
        }

        private static void InternalJobTOUpdoadFiles(List<RequestModel> requestModelList)
        {
            string rawXmlContent = "";
            foreach (RequestModel requestModel in requestModelList)
            {
                rawXmlContent = xmlContentGenerator(requestModel);

                string correctXmlContent = rawXmlContent.RemoveAllNamespaces();

                string FileName = requestModel.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                string path = System.Web.Hosting.HostingEnvironment.MapPath(string.Format(@"~/App_Data/xml/{0}.xml", FileName));
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path).Close();
                    SaveContent(correctXmlContent, path);
                }
                else if (System.IO.File.Exists(path))
                {
                    System.IO.File.WriteAllText(path, String.Empty);
                    SaveContent(correctXmlContent, path);
                }
            }
        }

        private static string xmlContentGenerator(RequestModel requestModel)
        {
            string rawXmlContent;

            if (requestModel.Visits == null)
            {
                RequestWithoutVisits requestWithoutVisits = Mapper.Map<RequestModel, RequestWithoutVisits>(requestModel);
                XmlSerializer xmlSerializer = new XmlSerializer(requestWithoutVisits.GetType());
                using (StringWriter writer = new StringWriter())
                {
                    xmlSerializer.Serialize(writer, requestWithoutVisits);
                    rawXmlContent = writer.ToString();
                }
            }
            else
            {
                RequestVisits requestVisits = Mapper.Map<RequestModel, RequestVisits>(requestModel);
                XmlSerializer xmlSerializer = new XmlSerializer(requestVisits.GetType());
                using (StringWriter writer = new StringWriter())
                {
                    xmlSerializer.Serialize(writer, requestVisits);
                    rawXmlContent = writer.ToString();
                }
            }

            return rawXmlContent;
        }

        private static void SaveContent(string correctXmlContent, string path)
        {
            using (StreamWriter tw = new StreamWriter(path, true))
            {
                tw.WriteLine(correctXmlContent);
            }
        }
    }
}