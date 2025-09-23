// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="Barcode.cs">
//  Copyright (c) Aspose Pty Ltd
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

namespace GroupDocs.Parser.Cloud.Sdk.Model 
{
    using System;  
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    /// <summary>
    /// Represents an barcode.
    /// </summary>  
    public class Barcode 
    {                       
        /// <summary>
        /// Gets the name of the barcode type.
        /// </summary>  
        public string CodeTypeName { get; set; }

        /// <summary>
        /// Gets the document page information such as page index and page size.
        /// </summary>  
        public BarcodePage Page { get; set; }

        /// <summary>
        /// Gets the rectangular area.
        /// </summary>  
        public Rectangle Rectangle { get; set; }

        /// <summary>
        /// Gets the barcode value.
        /// </summary>  
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the barcode download URL.
        /// </summary>  
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class Barcode {\n");
          sb.Append("  CodeTypeName: ").Append(this.CodeTypeName).Append("\n");
          sb.Append("  Page: ").Append(this.Page).Append("\n");
          sb.Append("  Rectangle: ").Append(this.Rectangle).Append("\n");
          sb.Append("  Value: ").Append(this.Value).Append("\n");
          sb.Append("  DownloadUrl: ").Append(this.DownloadUrl).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
