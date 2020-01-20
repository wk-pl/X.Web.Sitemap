using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace X.Web.Sitemap
{
    [Serializable]
    [XmlRoot("url")]
    [XmlType("url")]
    public class Url
    {
        [XmlElement("loc")]
        public string Location { get; set; }

        [XmlIgnore]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Please do not use this property to change last modification date. 
        /// Use TimeStamp instead.
        /// </summary>
        [XmlElement("lastmod")]
        public string LastMod
        {
            get => TimeStamp.ToString("yyyy-MM-dd");
            set => TimeStamp = DateTime.Parse(value);
        }

        [XmlElement("changefreq")]
        public ChangeFrequency ChangeFrequency { get; set; }

        [XmlElement("priority")]
        public double Priority { get; set; }

        [XmlElement("image", Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
        public List<UrlImage> Images { get; set; }

        public Url()
        {
            Images = new List<UrlImage>();
        }

        public static Url CreateUrl(string location) => CreateUrl(location, DateTime.Now);

        public static Url CreateUrl(string url, DateTime timeStamp) =>
            new Url
            {
                Location = url,
                ChangeFrequency = ChangeFrequency.Daily,
                Priority = 0.5d,
                TimeStamp = timeStamp,
            };

        public void AddImage(string location, string caption, string title)
        {
            Images.Add(UrlImage.CreateImage(location, caption, title));
        }
    }
}
