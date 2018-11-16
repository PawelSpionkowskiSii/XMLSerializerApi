using System.Xml.Serialization;

namespace XMLSerializerApi.Models.XmlSerializer
{
    [XmlRoot(ElementName = "request")]
    public class RequestVisits
    {
        [XmlElement("ix")]
        public int Ix { get; set; }
        [XmlElement("content")]
        public ContentVisits Content { get; set; }
    }

    [XmlRoot(ElementName = "content")]
    public class ContentVisits
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("visits")]
        public int Vistis { get; set; }
        [XmlElement("dateRequested")]
        public string DateRequested { get; set; }
    }
}