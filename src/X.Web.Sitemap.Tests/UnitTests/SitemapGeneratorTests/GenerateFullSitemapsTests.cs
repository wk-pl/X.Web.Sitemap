using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace X.Web.Sitemap.Tests.UnitTests.SitemapGeneratorTests
{
    [TestFixture]
    public class GenerateFullSitemapsTests
    {
        private SitemapGenerator _sitemapGenerator;
        private ISerializedXmlSaver<Sitemap> _sitemapSerializer;

        [SetUp]
        public void SetUp()
        {
            _sitemapSerializer = new SerializedXmlSaver<Sitemap>(new FileSystemWrapper());
            _sitemapGenerator = new SitemapGenerator(_sitemapSerializer);
        }

        [Test]
        public void Generates_Sitemap_With_Image()
        {
            var url = Url.CreateUrl("https://example.com");
            url.SetImage("https://example.com/image.jpg", "Caption of the image", "Title of the image");
            var sitemap = new Sitemap();
            sitemap.Add(url);

            var result = _sitemapGenerator.GenerateSitemaps(sitemap, new DirectoryInfo("x"), "full_file");

            Assert.AreEqual(1, result.Count);
        }
    }
}
