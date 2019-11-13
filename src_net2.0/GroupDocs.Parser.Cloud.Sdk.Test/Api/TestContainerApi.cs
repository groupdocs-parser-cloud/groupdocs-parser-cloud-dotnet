using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using GroupDocs.Parser.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System.Linq;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestContainerApi : BaseApiTest
    {
        [Test]
        public void TestGetContainerItemInfo()
        {
            var testFile = TestFiles.Zip;
            var options = new ContainerOptions()
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new ContainerRequest(options);
            var result = InfoApi.Container(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.ContainerItems);
            Assert.AreEqual(2, result.ContainerItems.Count);
            Assert.IsTrue(result.ContainerItems.Any(x => x.Name == "one-page.docx"));
        }

        [Test]
        public void TestGetContainerItemInfo_FileNotFoundResult()
        {
            var testFile = TestFiles.NotExist;
            var options = new ContainerOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };

            var request = new ContainerRequest(options);
            var ex = Assert.Throws<ApiException>(() => { InfoApi.Container(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", ex.Message);
        }

        [Test]
        public void GetContainerItemsInfo_UnsupportedFileType()
        {
            var testFile = TestFiles.FourPages;
            var options = new ContainerOptions
            {
                FileInfo = testFile.ToFileInfo()
            };

            var request = new ContainerRequest(options);
            var ex = Assert.Throws<ApiException>(() => { InfoApi.Container(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", ex.Message);
        }

        [Test]
        public void GetContainerItemsInfo_WithoutOptions()
        {
            var ex = Assert.Throws<ApiException>(() => { InfoApi.Container(new ContainerRequest(null)); });
            Assert.AreEqual("Missing required parameter 'options' when calling Container", ex.Message);
        }
    }
}