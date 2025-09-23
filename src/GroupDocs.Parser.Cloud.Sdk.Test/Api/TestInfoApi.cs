using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using GroupDocs.Parser.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestInfoApi : BaseApiTest
    {
        [Test]
        public void TestGetInfo_Txt()
        {
            var testFile = TestFiles.EncodingDetection;
            var options = new InfoOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };

            var request = new GetInfoRequest(options);
            var result = InfoApi.GetInfo(request);

            Assert.IsNotNull(result);
            Assert.AreEqual("PLAIN TEXT FILE", result.FileType.FileFormat.ToUpper());
            Assert.AreEqual(1, result.PageCount);
        }

        [Test]
        public void TestGetInfo_Docx()
        {
            var testFile = TestFiles.FourPages;
            var options = new InfoOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };

            var request = new GetInfoRequest(options);
            var result = InfoApi.GetInfo(request);

            Assert.IsNotNull(result);
            Assert.AreEqual("MICROSOFT WORD OPEN XML DOCUMENT", result.FileType.FileFormat.ToUpper());
            Assert.AreEqual(4, result.PageCount);
        }

        [Test]
        public void TestGetInfo_ContainerInfo()
        {
            var testFile = TestFiles.Zip;
            var options = new InfoOptions
            {
                FileInfo = testFile.ToFileInfo(),
                ContainerItemInfo = new ContainerItemInfo
                {
                    RelativePath = "one-page.docx"
                }
            };
            var request = new GetInfoRequest(options);
            var result = InfoApi.GetInfo(request);

            Assert.IsNotNull(result);
            Assert.AreEqual("MICROSOFT WORD OPEN XML DOCUMENT", result.FileType.FileFormat.ToUpper());
            Assert.AreEqual(1, result.PageCount);
        }

        [Test]
        public void TestGetInfo_FileNotFoundResult()
        {
            var testFile = TestFiles.NotExist;
            var options = new InfoOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };

            var request = new GetInfoRequest(options);
            Assert.Throws<ApiException>(() => { InfoApi.GetInfo(request); });
        }

        [Test]
        public void TestGetInfo_IncorrectPassword()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new InfoOptions
            {
                FileInfo = new Model.FileInfo { FilePath = testFile.FullName, Password = "123" },
            };

            var request = new GetInfoRequest(options);
            Assert.Throws<ApiException>(() => { InfoApi.GetInfo(request); });
        }
    }
}