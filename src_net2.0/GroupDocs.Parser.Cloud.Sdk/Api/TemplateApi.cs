// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="TemplateApi.cs">
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

namespace GroupDocs.Parser.Cloud.Sdk.Api
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using GroupDocs.Parser.Cloud.Sdk.Client;
    using GroupDocs.Parser.Cloud.Sdk.Client.RequestHandlers;
    using GroupDocs.Parser.Cloud.Sdk.Model;
    using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
    
    /// <summary>
    /// GroupDocs.Parser Cloud API.
    /// </summary>
    public class TemplateApi
    {        
        private readonly ApiInvoker apiInvoker;
        private readonly Configuration configuration;     

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateApi"/> class.
        /// </summary>
        /// <param name="appSid">Application identifier (App SID)</param>
        /// <param name="appKey">Application private key (App Key)</param>
        public TemplateApi(string appSid, string appKey)
            : this(new Configuration(appSid, appKey))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateApi"/> class.
        /// </summary>    
        /// <param name="configuration">Configuration settings</param>
        public TemplateApi(Configuration configuration)
        {
            this.configuration = configuration;
            
            var requestHandlers = new List<IRequestHandler>();
            requestHandlers.Add(new AuthRequestHandler(this.configuration));
            requestHandlers.Add(new DebugLogRequestHandler(this.configuration));
            requestHandlers.Add(new ApiExceptionRequestHandler());
            this.apiInvoker = new ApiInvoker(requestHandlers, this.configuration.Timeout);
        }                            

        /// <summary>
        /// Create or update document template. 
        /// </summary>
        /// <param name="request">Request. <see cref="CreateTemplateRequest" /></param>
        /// <returns><see cref="TemplateResult"/></returns>
        public TemplateResult CreateTemplate(CreateTemplateRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling CreateTemplate");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/parser/template";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            var postBody = SerializationHelper.Serialize(request.options); // http body (model) parameter
            var response = this.apiInvoker.InvokeApi(
                resourcePath, 
                "PUT", 
                postBody, 
                null, 
                null);

            if (response != null)
            {
                return (TemplateResult)SerializationHelper.Deserialize(response, typeof(TemplateResult));
            }

            return null;
        }

        /// <summary>
        /// Delete document template. 
        /// </summary>
        /// <param name="request">Request. <see cref="DeleteTemplateRequest" /></param>
        public void DeleteTemplate(DeleteTemplateRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling DeleteTemplate");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/parser/template";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            var postBody = SerializationHelper.Serialize(request.options); // http body (model) parameter
            this.apiInvoker.InvokeApi(
                resourcePath, 
                "DELETE", 
                postBody, 
                null, 
                null);
        }

        /// <summary>
        /// Retrieve document template. 
        /// </summary>
        /// <param name="request">Request. <see cref="GetTemplateRequest" /></param>
        /// <returns><see cref="Template"/></returns>
        public Template GetTemplate(GetTemplateRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling GetTemplate");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/parser/template";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            var postBody = SerializationHelper.Serialize(request.options); // http body (model) parameter
            var response = this.apiInvoker.InvokeApi(
                resourcePath, 
                "POST", 
                postBody, 
                null, 
                null);

            if (response != null)
            {
                return (Template)SerializationHelper.Deserialize(response, typeof(Template));
            }

            return null;
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="CreateTemplateRequest.cs">
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

namespace GroupDocs.Parser.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Parser.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Parser.Cloud.Sdk.Api.TemplateApi.CreateTemplate" /> operation.
    /// </summary>  
    public class CreateTemplateRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="CreateTemplateRequest"/> class.
          /// </summary>        
          public CreateTemplateRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="CreateTemplateRequest"/> class.
          /// </summary>
          /// <param name="options">Create template options.</param>
          public CreateTemplateRequest(CreateTemplateOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Create template options.
          /// </summary>  
          public CreateTemplateOptions options { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="DeleteTemplateRequest.cs">
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

namespace GroupDocs.Parser.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Parser.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Parser.Cloud.Sdk.Api.TemplateApi.DeleteTemplate" /> operation.
    /// </summary>  
    public class DeleteTemplateRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="DeleteTemplateRequest"/> class.
          /// </summary>        
          public DeleteTemplateRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="DeleteTemplateRequest"/> class.
          /// </summary>
          /// <param name="options">Delete template options.</param>
          public DeleteTemplateRequest(TemplateOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Delete template options.
          /// </summary>  
          public TemplateOptions options { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="GetTemplateRequest.cs">
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

namespace GroupDocs.Parser.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Parser.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Parser.Cloud.Sdk.Api.TemplateApi.GetTemplate" /> operation.
    /// </summary>  
    public class GetTemplateRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="GetTemplateRequest"/> class.
          /// </summary>        
          public GetTemplateRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="GetTemplateRequest"/> class.
          /// </summary>
          /// <param name="options">Retrieve template options.</param>
          public GetTemplateRequest(TemplateOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Retrieve template options.
          /// </summary>  
          public TemplateOptions options { get; set; }
    }
}
