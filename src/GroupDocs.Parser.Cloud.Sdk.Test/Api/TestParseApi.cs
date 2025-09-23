using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using GroupDocs.Parser.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestParseApi : BaseApiTest
    {
        [Test]
        public void TestParseDocument_SavedTemplate()
        {
            var templatePath = "templates/document-template.json";
            var template = new CreateTemplateOptions()
            {
                Template = GetTemplate(),
                TemplatePath = templatePath
            };
            var templateRequest = new CreateTemplateRequest(template);

            var resultTemplate = TemplateApi.CreateTemplate(templateRequest);
            Assert.IsNotNull(resultTemplate);

            var testFile = TestFiles.TemplateDocumentDocx;

            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
                TemplatePath = templatePath
            };
            var request = new ParseRequest(options);
            var result = ParseApi.Parse(request);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.FieldsData);
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void TestParseDocument_RawTemplate()
        {
            var testFile = TestFiles.TemplateDocumentDocx;
            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Template = GetTemplate()
            };
            var request = new ParseRequest(options);
            var result = ParseApi.Parse(request);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.FieldsData);
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void TestParseDocument_FileNotFoundResult()
        {
            var testFile = TestFiles.NotExist;
            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
                TemplatePath = "templates/document-template.json",
                Template = GetTemplate()
            };
            var request = new ParseRequest(options);
            Assert.Throws<ApiException>(() => { ParseApi.Parse(request); });
        }

        [Test]
        public void TestParseDocument_WithoutOptions()
        {
            var testFile = TestFiles.JpegFile;
            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new ParseRequest(options);
            Assert.Throws<ApiException>(() => { ParseApi.Parse(request); });
        }

        [Test]
        public void TestParseDocument_NotSupportedFile()
        {
            var testFile = TestFiles.JpegFile;
            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
                TemplatePath = "templates/document-template.json",
                Template = GetTemplate()
            };
            var request = new ParseRequest(options);
            Assert.Throws<ApiException>(() => { ParseApi.Parse(request); });
        }

        [Test]
        public void TestParseDocument_IncorrectPassword()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
                TemplatePath = "templates/document-template.json",
                Template = GetTemplate()
            };
            options.FileInfo.Password = "123";
            var request = new ParseRequest(options);
            Assert.Throws<ApiException>(() => { ParseApi.Parse(request); });
        }

        #region Setup

        private Template GetTemplate()
        {
            var options = new Template
            {
                Fields = new List<Field>
                {
                    new Field
                    {
                        FieldName = "Field1",
                        PageIndex = 4,
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Fixed",
                            Rectangle = new Rectangle
                            {
                                Size = new Size
                                {
                                    Width = 140,
                                    Height = 30
                                },
                                Position = new Point
                                {
                                    X = 0,
                                    Y = 0,
                                }
                            }
                        }
                    },
                    new Field
                    {
                        FieldName = "RelatedField2",
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Linked",
                            LinkedFieldName = "Field1",
                            IsBottomLinked = true,
                            IsRightLinked = true,
                            SearchArea = new Size
                            {
                                Height = 24,
                                Width = 209
                            },
                            AutoScale = false
                        }
                    },
                    new Field
                    {
                        FieldName = "Regex",
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Regex",
                            Regex = "REGEX TEXT 123"
                        }
                    }
                },
                Tables = new List<Table>
                {
                    new Table
                    {
                        PageIndex = 5,
                        TableName = "TableCells",
                        DetectorParameters = new DetectorParameters
                        {
                            Rectangle = new Rectangle
                            {
                                Size = new Size
                                {
                                    Width = 600,
                                    Height = 400
                                },
                                Position = new Point
                                {
                                    X = 0,
                                    Y = 0,
                                }
                            }
                        }
                    }
                }
            };

            return options;
        }

        #endregion
    }
}