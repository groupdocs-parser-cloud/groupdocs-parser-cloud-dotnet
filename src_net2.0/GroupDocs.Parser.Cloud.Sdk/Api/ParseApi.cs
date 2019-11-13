// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="ParseApi.cs">
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
    public class ParseApi
    {        
        private readonly ApiInvoker apiInvoker;
        private readonly Configuration configuration;     

        /// <summary>
        /// Initializes a new instance of the <see cref="ParseApi"/> class.
        /// </summary>
        /// <param name="appSid">Application identifier (App SID)</param>
        /// <param name="appKey">Application private key (App Key)</param>
        public ParseApi(string appSid, string appKey)
            : this(new Configuration(appSid, appKey))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParseApi"/> class.
        /// </summary>    
        /// <param name="configuration">Configuration settings</param>
        public ParseApi(Configuration configuration)
        {
            this.configuration = configuration;
            
            var requestHandlers = new List<IRequestHandler>();
            requestHandlers.Add(new AuthRequestHandler(this.configuration));
            requestHandlers.Add(new DebugLogRequestHandler(this.configuration));
            requestHandlers.Add(new ApiExceptionRequestHandler());
            this.apiInvoker = new ApiInvoker(requestHandlers, this.configuration.Timeout);
        }                            

        /// <summary>
        /// Extract images from document. 
        /// </summary>
        /// <param name="request">Request. <see cref="ImagesRequest" /></param>
        /// <returns><see cref="ImagesResult"/></returns>
        public ImagesResult Images(ImagesRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling Images");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/parser/images";
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
                return (ImagesResult)SerializationHelper.Deserialize(response, typeof(ImagesResult));
            }

            return null;
        }

        /// <summary>
        /// Extract document data by a predefined template. 
        /// </summary>
        /// <param name="request">Request. <see cref="ParseRequest" /></param>
        /// <returns><see cref="ParseResult"/></returns>
        public ParseResult Parse(ParseRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling Parse");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/parser/parse";
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
                return (ParseResult)SerializationHelper.Deserialize(response, typeof(ParseResult));
            }

            return null;
        }

        /// <summary>
        /// Extract text from document. 
        /// </summary>
        /// <param name="request">Request. <see cref="TextRequest" /></param>
        /// <returns><see cref="TextResult"/></returns>
        public TextResult Text(TextRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling Text");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/parser/text";
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
                return (TextResult)SerializationHelper.Deserialize(response, typeof(TextResult));
            }

            return null;
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="ImagesRequest.cs">
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
    /// Request model for <see cref="GroupDocs.Parser.Cloud.Sdk.Api.ParseApi.Images" /> operation.
    /// </summary>  
    public class ImagesRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="ImagesRequest"/> class.
          /// </summary>        
          public ImagesRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="ImagesRequest"/> class.
          /// </summary>
          /// <param name="options">Extract image options.</param>
          public ImagesRequest(ImagesOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Extract image options.
          /// </summary>  
          public ImagesOptions options { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="ParseRequest.cs">
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
    /// Request model for <see cref="GroupDocs.Parser.Cloud.Sdk.Api.ParseApi.Parse" /> operation.
    /// </summary>  
    public class ParseRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="ParseRequest"/> class.
          /// </summary>        
          public ParseRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="ParseRequest"/> class.
          /// </summary>
          /// <param name="options">Parse options.</param>
          public ParseRequest(ParseOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Parse options.
          /// </summary>  
          public ParseOptions options { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="TextRequest.cs">
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
    /// Request model for <see cref="GroupDocs.Parser.Cloud.Sdk.Api.ParseApi.Text" /> operation.
    /// </summary>  
    public class TextRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="TextRequest"/> class.
          /// </summary>        
          public TextRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="TextRequest"/> class.
          /// </summary>
          /// <param name="options">Extract text options.</param>
          public TextRequest(TextOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Extract text options.
          /// </summary>  
          public TextOptions options { get; set; }
    }
}
