using System.IO;
using NUnit.Framework;

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
            url.AddImage("https://example.com/image1.jpg", "Caption of the image1", "Title of the image1");
            url.AddImage("https://example.com/image2.jpg", "Caption of the image2", "Title of the image2");
            var sitemap = new Sitemap();
            sitemap.Add(url);

            var result = _sitemapGenerator.GenerateSitemaps(sitemap, new DirectoryInfo("GenerateFullSitemapsTests"), "full_file");

            Assert.AreEqual(1, result.Count);
        }
    }
}