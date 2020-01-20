using System.Xml.Serialization;
using X.Web.Sitemap.Constants;

namespace X.Web.Sitemap
{
    [Serializable]
    [XmlRoot(ElementName = "image", Namespace = Namespaces.ImageNamespace)]
    [XmlType(Namespace = Namespaces.ImageNamespace)]
    public class UrlImage
    {
        [XmlElement("loc", Namespace = Namespaces.ImageNamespace)]
        public string Location { get; set; }

        [XmlElement("caption", Namespace = Namespaces.ImageNamespace)]
        public string Caption { get; set; }

        [XmlElement("title", Namespace = Namespaces.ImageNamespace)]
        public string Title { get; set; }

        public UrlImage()
        {
        }

        public static UrlImage CreateImage(string url, string caption, string title) =>
            new UrlImage
            {
                Location = url,
                Caption = caption,
                Title = title
            };
    }
}