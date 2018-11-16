using System.Xml.Serialization;

namespace XMLSerializerApi.Models.XmlSerializer
{
    [XmlRoot(ElementName = "request")]
    public class RequestWithoutVisits
    {
        [XmlElement("ix")]
        public int Ix { get; set; }
        [XmlElement("content")]
        public ContentWithoutVisits Content { get; set; }
    }

    [XmlRoot(ElementName = "content")]
    public class ContentWithoutVisits
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("dateRequested")]
        public string DateRequested { get; set; }
    }
}