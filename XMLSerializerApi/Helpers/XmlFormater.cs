using System.Linq;
using System.Xml.Linq;

namespace XMLSerializerApi.Helpers
{
    public static class XmlFormater
    {
        public static string RemoveAllNamespaces(this string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n{xmlDocumentWithoutNs.ToString()}";
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }
    }
}