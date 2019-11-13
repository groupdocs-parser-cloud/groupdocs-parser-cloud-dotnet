// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd">
//  Copyright (c) 2003-2019 Aspose Pty Ltd
// </copyright>
// <summary>
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using GroupDocs.Parser.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System.Linq;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestImageApi : BaseApiTest
    {
        [Test]
        public void TestGetImage_Docx()
        {
            var testFile = TestFiles.FourPages;
            var options = new ImagesOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new ImagesRequest(options);
            var result = ParseApi.Images(request);

            Assert.IsNotNull(result);
            int i = 0;
            foreach (var image in result.Images)
            {
                Assert.AreEqual($"parser/images/words/docx/four-pages_docx/image_{i}.jpeg", image.Path);
                Assert.NotNull(image.DownloadUrl);
                i++;
            }
        }

        [Test]
        public void TestGetImage_Container()
        {
            var testFile = TestFiles.ZipWithEmailImagePdf;
            var options = new ImagesOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new ImagesRequest(options);
            var result = ParseApi.Images(request);

            Assert.IsNotNull(result);
            var paths = new[]
            {
                "parser/images/containers/archive/zip-eml-jpg-pdf_zip/",
                "parser/images/containers/archive/zip-eml-jpg-pdf_zip/embedded-image-and-attachment_eml/",
                "parser/images/containers/archive/zip-eml-jpg-pdf_zip/template-document_pdf/"
            };

            foreach (var image in result.Images)
            {
                Assert.IsTrue(paths.Any(image.Path.Contains));
            }
        }

        [Test]
        public void TestGetImage_Email()
        {
            var testFile = TestFiles.ImageAndAttachment;
            var options = new ImagesOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new ImagesRequest(options);
            var result = ParseApi.Images(request);
            Assert.IsNotNull(result);
            var paths = new[]
            {
                "parser/images/email/eml/embedded-image-and-attachment_eml/",
            };

            foreach (var image in result.Images)
            {
                Assert.IsTrue(paths.Any(image.Path.Contains));
            }
        }

        [Test]
        public void TestGetImage_FileNotFoundResult()
        {
            var testFile = TestFiles.NotExist;
            var options = new ImagesOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new ImagesRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Images(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", ex.Message);
        }

        [Test]
        public void TestGetImage_IncorrectPassword()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new ImagesOptions
            {
                FileInfo = new FileInfo { FilePath = testFile.FullName, Password = "123" },
            };
            var request = new ImagesRequest(options);

            var ex = Assert.Throws<ApiException>(() => { ParseApi.Images(request); });
            Assert.AreEqual($"Password provided for file '{testFile.FullName}' is incorrect.", ex.Message);
        }

        [Test]
        public void TestGetImage_Pdf_FromPages()
        {
            var testFile = TestFiles.Pdf;
            var options = new ImagesOptions
            {
                FileInfo = testFile.ToFileInfo(),
                StartPageNumber = 1,
                CountPagesToExtract = 2
            };

            var request = new ImagesRequest(options);
            var result = ParseApi.Images(request);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Pages);
            Assert.AreEqual(2, result.Pages.Count);

            Assert.AreEqual("parser/images/pdf/template-document_pdf/page_1/image_0.jpeg", result.Pages[0].Images[0].Path);
            Assert.AreEqual("parser/images/pdf/template-document_pdf/page_2/image_0.jpeg", result.Pages[1].Images[0].Path);
        }

        [Test]
        public void ImageExtractTest_Pdf_FromPages_OutOfThePageRange()
        {
            var testFile = TestFiles.Pdf;
            var options = new ImagesOptions
            {
                FileInfo = testFile.ToFileInfo(),
                StartPageNumber = 3,
                CountPagesToExtract = 5
            };

            var request = new ImagesRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Images(request); });

            Assert.AreEqual("Request parameters missing or have incorrect format", ex.Message);
        }

        [Test]
        public void ImageExtractTest_Pdf_ContainerItem_FromPages()
        {
            var testFile = TestFiles.PdfContainer;
            var options = new ImagesOptions
            {
                FileInfo = testFile.ToFileInfo(),
                StartPageNumber = 1,
                CountPagesToExtract = 2,
                ContainerItemInfo = new ContainerItemInfo { RelativePath = "template-document.pdf" }
            };

            var request = new ImagesRequest(options);
            var result = ParseApi.Images(request);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Pages);
            Assert.AreEqual(2, result.Pages.Count);

            Assert.AreEqual("parser/images/template-document_pdf/page_1/image_0.jpeg", result.Pages[0].Images[0].Path);
            Assert.AreEqual("parser/images/template-document_pdf/page_2/image_0.jpeg", result.Pages[1].Images[0].Path);
        }

        [Test]
        public void ImageExtractTest_Pdf_Container_FromPages_Error()
        {
            var testFile = TestFiles.Zip;
            var options = new ImagesOptions
            {
                FileInfo = testFile.ToFileInfo(),
                StartPageNumber = 1,
                CountPagesToExtract = 2
            };

            var request = new ImagesRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Images(request); });

            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", ex.Message);
        }
    }
}