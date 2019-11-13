// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="TestFiles.cs">
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

using System.Collections.Generic;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api.Internal
{
    public static class TestFiles
    {
        public static readonly string DefaultPassword = "password";

        public static readonly TestFile PasswordProtected = new TestFile("password-protected.docx", "words\\docx\\")
        {
            Password = DefaultPassword
        };

        public static readonly TestFile PdfContainer = new TestFile("PDF with attachements.pdf", "pdf\\")
        {
            Password = DefaultPassword
        };

        public static readonly TestFile FourPages = new TestFile("four-pages.docx", "words\\docx\\");
        public static readonly TestFile OnePage = new TestFile("one-page.docx", "words\\docx\\");
        public static readonly TestFile TemplateDocumentDocx = new TestFile("template-document.docx", "words\\docx\\");
        public static readonly TestFile FormattedDocument = new TestFile("formatted-document.docx", "words\\docx\\");
        public static readonly TestFile EncodingDetection = new TestFile("encoding-detection.txt", "words\\txt\\");
        public static readonly TestFile Zip = new TestFile("docx.zip", "containers\\archive\\");
        public static readonly TestFile ZipWithEmailImagePdf = new TestFile("zip-eml-jpg-pdf.zip", "containers\\archive\\");
        public static readonly TestFile JpegFile = new TestFile("document.jpeg", "image\\jpeg\\");
        public static readonly TestFile ImageAndAttachment = new TestFile("embedded-image-and-attachment.eml", "email\\eml\\");
        public static readonly TestFile Pdf = new TestFile("template-document.pdf", "pdf\\");
        public static readonly TestFile NotExist = new TestFile("folder\\file-not-exist.pdf", "");


        public static IEnumerable<TestFile> TestFilesList
        {
            get
            {
                yield return PasswordProtected;
                yield return FourPages;
                yield return OnePage;
                yield return TemplateDocumentDocx;
                yield return FormattedDocument;
                yield return EncodingDetection;
                yield return Zip;
                yield return ZipWithEmailImagePdf;
                yield return JpegFile;
                yield return ImageAndAttachment;
                yield return Pdf;
                yield return PdfContainer;
            }
        }
    }
}
