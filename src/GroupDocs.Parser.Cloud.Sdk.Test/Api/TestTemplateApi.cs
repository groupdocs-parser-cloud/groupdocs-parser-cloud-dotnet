using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using NUnit.Framework;
using System.Collections.Generic;

namespace GroupDocs.Parser.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestTemplateApi : BaseApiTest
    {
        [Test]
        public void TestCreateTemplate()
        {
            var options = new CreateTemplateOptions()
            {
                Template = GetTemplate(),
                TemplatePath = "templates/template_2.json"
            };
            var request = new CreateTemplateRequest(options);
            var result = TemplateApi.CreateTemplate(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Url.Contains(@"storage/file/templates/template_2.json"));
        }

        [Test]
        public void TestUpdateTemplate()
        {
            var options = new CreateTemplateOptions()
            {
                Template = GetTemplate(),
                TemplatePath = "templates/template_1.json"
            };
            var request = new CreateTemplateRequest(options);
            var result = TemplateApi.CreateTemplate(request);

            var updateResult = TemplateApi.CreateTemplate(request);
            Assert.IsNotNull(updateResult);
            Assert.IsTrue(updateResult.Url.Contains(@"storage/file/templates/template_1.json"));
        }

        [Test]
        public void TestGetTemplate()
        {
            var options = new CreateTemplateOptions()
            {
                Template = GetTemplate(),
                TemplatePath = "templates/template_1.json"
            };
            var request = new CreateTemplateRequest(options);
            var result = TemplateApi.CreateTemplate(request);

            var getOptions = new TemplateOptions()
            {
                TemplatePath = "templates/template_1.json"
            };
            var getRequest = new GetTemplateRequest(getOptions);
            var getResult = TemplateApi.GetTemplate(getRequest);

            Assert.IsNotNull(getResult);
            Assert.IsInstanceOf<Template>(getResult);
            Assert.AreEqual(2, getResult.Fields.Count);
            Assert.AreEqual(1, getResult.Tables.Count);
        }

        [Test]
        public void TestDeleteTemplate()
        {
            var options = new CreateTemplateOptions()
            {
                Template = GetTemplate(),
                TemplatePath = "templates/template_1.json"
            };
            var request = new CreateTemplateRequest(options);
            var result = TemplateApi.CreateTemplate(request);

            var deleteOptions = new TemplateOptions()
            {
                TemplatePath = "templates/template_1.json"
            };

            var deleteRequest = new DeleteTemplateRequest(deleteOptions);
            TemplateApi.DeleteTemplate(deleteRequest);
        }

        [Test]
        public void TestTemplate_Delete_FileNotFoundResult()
        {
            var options = new TemplateOptions()
            {
                TemplatePath = "notExistTemplate.json"
            };
            var deleteRequest = new DeleteTemplateRequest(options);

            Assert.Throws<ApiException>(() => { TemplateApi.DeleteTemplate(deleteRequest); });
        }

        [Test]
        public void TestTemplate_Get_FileNotFoundResult()
        {
            var options = new TemplateOptions()
            {
                TemplatePath = "notExistTemplate.json"
            };

            var getRequest = new GetTemplateRequest(options);
            Assert.Throws<ApiException>(() => { TemplateApi.GetTemplate(getRequest); });
        }

        [Test]
        public void TestTemplate_Put_WithoutOptions()
        {
            var options = new CreateTemplateOptions();
            var request = new CreateTemplateRequest(options);

            Assert.Throws<ApiException>(() => { TemplateApi.CreateTemplate(request); });
        }

        [Test]
        public void TestTemplate_Get_WithoutOptions()
        {
            var options = new TemplateOptions();
            var request = new GetTemplateRequest(options);

            Assert.Throws<ApiException>(() => { TemplateApi.GetTemplate(request); });
        }

        [Test]
        public void TestTemplate_Delete_WithoutOptions()
        {
            var options = new TemplateOptions();
            var request = new DeleteTemplateRequest(options);

            Assert.Throws<ApiException>(() => { TemplateApi.DeleteTemplate(request); });
        }

        #region Setup

        private Template GetTemplate()
        {
            return new Template()
            {
                Fields = new List<Field>()
                {
                    new Field
                    {
                        FieldName = "Address",
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Fixed",
                            Rectangle = new Rectangle
                            {
                                Size = new Size
                                {
                                    Width = 100,
                                    Height = 10
                                },
                                Position = new Point
                                {
                                    X = 13,
                                    Y = 35,
                                }
                            }
                        }
                    },
                    new Field
                    {
                        FieldName = "Company",
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Linked",
                            LinkedFieldName = "Address",
                            IsBottomLinked = true,
                            SearchArea = new Size
                            {
                                Height = 15,
                                Width = 100
                            },
                            AutoScale = true
                        }
                    }
                },
                Tables = new List<Table>()
                {
                    new Table
                    {
                        TableName = "Totals",
                        DetectorParameters = new DetectorParameters
                        {
                            Rectangle = new Rectangle
                            {
                                Size = new Size
                                {
                                    Width = 65,
                                    Height = 220
                                },
                                Position = new Point
                                {
                                    X = 300,
                                    Y = 385,
                                }
                            }
                        }
                    }
                }
            };
        }

        #endregion
    }
}