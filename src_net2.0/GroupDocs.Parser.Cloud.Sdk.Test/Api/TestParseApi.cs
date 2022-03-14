using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using GroupDocs.Parser.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using GroupDocs.Metadata.Cloud.Sdk.Test.Infrastructure;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestParseApi : BaseApiTest
    {
        [Test]
        public void TestParse_SavedTemplate()
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
            Assert.AreEqual(4, result.Count);

            var dataFieldNames = new[] { "FIELD1", "RELATEDFIELD2", "REGEX", "TABLECELLS" };
            foreach (var field in result.FieldsData)
            {
                Assert.IsTrue(dataFieldNames.Contains(field.Name));
            }

            var table = result.FieldsData.First(x => string.Equals(x.Name, "TABLECELLS")).PageArea.PageTableArea;
            if (table != null)
            {
                Assert.AreEqual(4, table.ColumnCount);
                Assert.AreEqual(3, table.RowCount);
                Assert.AreEqual(
                    "Cell 12",
                    table.PageTableAreaCells.First(x => x.ColumnIndex == 2 && x.RowIndex == 1).PageArea.PageTextArea.Text);
            }
        }

        [Test]
        public void TestParse_RawTemplate()
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
            Assert.AreEqual(4, result.Count);

            var dataFieldNames = new[] { "FIELD1", "RELATEDFIELD2", "REGEX", "TABLECELLS" };
            foreach (var field in result.FieldsData)
            {
                Assert.IsTrue(dataFieldNames.Contains(field.Name));
            }

            var table = result.FieldsData.First(x => string.Equals(x.Name, "TABLECELLS")).PageArea.PageTableArea;
            if (table != null)
            {
                Assert.AreEqual(4, table.ColumnCount);
                Assert.AreEqual(3, table.RowCount);
                Assert.AreEqual(
                    "Cell 12",
                    table.PageTableAreaCells.First(x => x.ColumnIndex == 2 && x.RowIndex == 1).PageArea.PageTextArea.Text);
            }
        }

        [Test]
        public void TestParse_FileNotFoundResult()
        {
            var testFile = TestFiles.NotExist;
            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
                TemplatePath = "templates/document-template.json",
                Template = GetTemplate()
            };
            var request = new ParseRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Parse(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", JsonUtils.GetErrorMessage(ex.Message));
        }

        [Test]
        public void TestParse_WithoutOptions()
        {
            var testFile = TestFiles.JpegFile;
            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };
            var request = new ParseRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Parse(request); });
            Assert.AreEqual("Request parameters missing or have incorrect format", JsonUtils.GetErrorMessage(ex.Message));
        }

        [Test]
        public void TestParse_NotSupportedFile()
        {
            var testFile = TestFiles.JpegFile;
            var options = new ParseOptions
            {
                FileInfo = testFile.ToFileInfo(),
                TemplatePath = "templates/document-template.json",
                Template = GetTemplate()
            };
            var request = new ParseRequest(options);
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Parse(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", JsonUtils.GetErrorMessage(ex.Message));
        }

        [Test]
        public void TestParse_IncorrectPassword()
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
            var ex = Assert.Throws<ApiException>(() => { ParseApi.Parse(request); });
            Assert.AreEqual($"Password provided for file '{testFile.FullName}' is incorrect.", JsonUtils.GetErrorMessage(ex.Message));
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
                                Size = new Size { Height = 30, Width = 140 },
                                Position = new Point { X = 0, Y = 0 }
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
                            SearchArea = new Size { Height = 24, Width = 209 },
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
                    },
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
                                Size = new Size { Height = 400, Width = 600 },
                                Position = new Point { X = 0, Y = 0 }
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