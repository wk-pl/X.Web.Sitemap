using System.Xml.Serialization;

namespace X.Web.Sitemap
{
    [Serializable]
    [XmlRoot(ElementName = "image", Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
    [XmlType(Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
    public class UrlImage
    {
        [XmlElement("loc", Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
        public string Location { get; set; }

        [XmlElement("caption", Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
        public string Caption { get; set; }

        [XmlElement("title", Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
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