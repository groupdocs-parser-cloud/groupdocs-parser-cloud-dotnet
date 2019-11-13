using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using GroupDocs.Parser.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestTextApi : BaseApiTest
    {
        [Test]
        public void TestText()
        {
            var testFile = TestFiles.OnePage;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new TextRequest(options);
            var result = ParseApi.Text(request);
            Assert.IsNotNull(result.Text);
            Assert.AreEqual("First Page\r\r\f", result.Text);
        }

        [Test]
        public void TestText_WithPassword()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
                StartPageNumber = 0,
                CountPagesToExtract = 1,
                FormattedTextOptions = new FormattedTextOptions
                {
                    Mode = "PlainText"
                }
            };

            var request = new TextRequest(options);
            var result = ParseApi.Text(request);
            Assert.IsNull(result.Text);
            Assert.AreEqual(
                "Text inside a bookmark 1\r\n\r\nPage 1 heading!\r\n\r\nSample test text - Page 1!\r\n\r\n\fText inside a bookmark 2\r\n\r\n",
                result.Pages[0].Text);
        }

        [Test]
        public void TestExtractPages()
        {
            var testFile = TestFiles.FourPages;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
                StartPageNumber = 0,
                CountPagesToExtract = 4,
                FormattedTextOptions = new FormattedTextOptions
                {
                    Mode = "PlainText"
                }
            };
            var request = new TextRequest(options);
            var result = ParseApi.Text(request);
            Assert.IsNotNull(result.Pages);

            Assert.AreEqual(0, result.Pages[0].PageIndex);
            Assert.AreEqual(
                "Text inside bookmark 0\r\n\r\nPage 0 heading\r\n\r\nPage Text - Page 0\r\n\r\n\fText inside bookmark 1\r\n\r\n",
                result.Pages[0].Text);

            Assert.AreEqual(3, result.Pages[3].PageIndex);
            Assert.AreEqual("\fText inside bookmark 3\r\n\r\nPage 3 heading\r\n\r\nPage Text - Page 3\r\n\r\n", result.Pages[3].Text);
        }

        [Test]
        public void TestExtractFormatted()
        {
            var testFile = TestFiles.FormattedDocument;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
                FormattedTextOptions = new FormattedTextOptions
                {
                    Mode = "Html"
                }
            };
            var request = new TextRequest(options);
            var result = ParseApi.Text(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Text.Contains("<b>Bold text</b>"));
            Assert.IsTrue(result.Text.Contains("<i>Italic text</i>"));
            Assert.IsTrue(result.Text.Contains("<h1>Heading 1</h1>"));
            Assert.IsTrue(result.Text.Contains("<tr><td><p>table</p></td>"));
            Assert.IsTrue(result.Text.Contains("<ol><li><i>First element</i>"));
            Assert.IsTrue(result.Text.Contains("<a href=\"http://targetwebsite.domain\">Hyperlink </a>"));
        }

        [Test]
        public void TestExtractFormattedPage()
        {
            var testFile = TestFiles.FormattedDocument;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
                FormattedTextOptions = new FormattedTextOptions
                {
                    Mode = "Markdown"
                },
                StartPageNumber = 1,
                CountPagesToExtract = 1
            };
            var request = new TextRequest(options);
            var result = ParseApi.Text(request);

            Assert.IsNotEmpty(result.Pages);
            Assert.IsTrue(result.Pages[0].Text.Contains("**Second page bold text**"));
            Assert.IsTrue(result.Pages[0].Text.Contains("# Second page heading"));
        }

        [Test]
        public void TestText_FileNotFoundResult()
        {
            var testFile = TestFiles.NotExist;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new TextRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Text(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", ex.Message);
        }

        [Test]
        public void TestText_NotSupportedFile()
        {
            var testFile = TestFiles.JpegFile;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new TextRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Text(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", ex.Message);
        }

        [Test]
        public void TestText_IncorrectPassword()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            options.FileInfo.Password = "123";
            var request = new TextRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Text(request); });
            Assert.AreEqual($"Password provided for file '{testFile.FullName}' is incorrect.", ex.Message);
        }
    }
}