// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="PageArea.cs">
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
    /// Class for document page area.
    /// </summary>  
    public class PageArea 
    {                       
        /// <summary>
        /// Gets or sets the rectangular area.
        /// </summary>  
        public Rectangle Rectangle { get; set; }

        /// <summary>
        /// Gets or sets the document page information such as page index and page size.
        /// </summary>  
        public Page Page { get; set; }

        /// <summary>
        /// Gets or sets the text area. Represents a page text area which is used to represent a text value in the parsing by template functionality.
        /// </summary>  
        public PageTextArea PageTextArea { get; set; }

        /// <summary>
        /// Gets or sets the table area. Represents a table page area which is used to represent a table in the parsing by template functionality.
        /// </summary>  
        public PageTableArea PageTableArea { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class PageArea {\n");
          sb.Append("  Rectangle: ").Append(this.Rectangle).Append("\n");
          sb.Append("  Page: ").Append(this.Page).Append("\n");
          sb.Append("  PageTextArea: ").Append(this.PageTextArea).Append("\n");
          sb.Append("  PageTableArea: ").Append(this.PageTableArea).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
