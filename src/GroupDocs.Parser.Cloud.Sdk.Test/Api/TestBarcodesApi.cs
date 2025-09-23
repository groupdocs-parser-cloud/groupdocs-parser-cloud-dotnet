using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestBarcodesApi : BaseApiTest
    {
        [Test]
        public void TestGetBarcode_Docx()
        {
            var testFile = TestFiles.Barcodes;
            var options = new BarcodesOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new BarcodesRequest(options);
            var result = ParseApi.Barcodes(request);

            Assert.IsNotNull(result);
            foreach (var barcode in result.Barcodes)
            {
                Assert.NotNull(barcode.Value);
            }
        }
    }
}
