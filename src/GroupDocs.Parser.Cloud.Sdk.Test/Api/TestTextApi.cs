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
        public void TestExtractText()
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
        public void TestExtractText_WithPassword()
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
                "Text inside a bookmark 1\n\nPage 1 heading!\n\nSample test text - Page 1!\n\n\fText inside a bookmark 2\n\n",
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
                "Text inside bookmark 0\n\nPage 0 heading\n\nPage Text - Page 0\n\n\fText inside bookmark 1\n\n",
                result.Pages[0].Text);

            Assert.AreEqual(3, result.Pages[3].PageIndex);
            Assert.AreEqual("\fText inside bookmark 3\n\nPage 3 heading\n\nPage Text - Page 3\n\n", result.Pages[3].Text);
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
        public void TestExtractText_FileNotFoundResult()
        {
            var testFile = TestFiles.NotExist;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new TextRequest(options);
            Assert.Throws<ApiException>(() => { ParseApi.Text(request); });
        }

        [Test]
        public void TestExtractText_IncorrectPassword()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new TextOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            options.FileInfo.Password = "123";
            var request = new TextRequest(options);
            Assert.Throws<ApiException>(() => { ParseApi.Text(request); });
        }

        [Test]
        public void ExtractTextHandlerTest_Md()
        {
            var testFile = TestFiles.Md;
            var options = new TextOptions { FileInfo = testFile.ToFileInfo() };
            var request = new TextRequest(options);
            var result = ParseApi.Text(request);
            Assert.IsNotNull(result.Text);
            Assert.AreEqual("# Test\r\rText for test:\r\r\tOne\r\tTwo\r\tSub1\rSub2\r\tThree\r\rBullets:\r\rA\rAA\rB\rC\f", result.Text);
        }
    }
}