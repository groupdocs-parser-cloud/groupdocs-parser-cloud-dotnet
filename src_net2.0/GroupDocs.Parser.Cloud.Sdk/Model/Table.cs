// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="Table.cs">
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
    /// Document template table
    /// </summary>  
    public class Table 
    {                       
        /// <summary>
        /// Gets or sets a unique template table name.
        /// </summary>  
        public string TableName { get; set; }

        /// <summary>
        /// The page index. An integer value that represents the index of the page where the template item is located; null if the template item is located on any page.
        /// </summary>  
        public int? PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the detector parameters. Provides parameters for the table detection algorithms. 
        /// </summary>  
        public DetectorParameters DetectorParameters { get; set; }

        /// <summary>
        /// Gets or sets the table layout. Provides the template table layout which is used by Table to define table position.
        /// </summary>  
        public TableLayout TableLayout { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class Table {\n");
          sb.Append("  TableName: ").Append(this.TableName).Append("\n");
          sb.Append("  PageIndex: ").Append(this.PageIndex).Append("\n");
          sb.Append("  DetectorParameters: ").Append(this.DetectorParameters).Append("\n");
          sb.Append("  TableLayout: ").Append(this.TableLayout).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
