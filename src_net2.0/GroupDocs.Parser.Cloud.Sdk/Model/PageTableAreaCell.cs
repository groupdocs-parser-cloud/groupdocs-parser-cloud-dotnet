// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="PageTableAreaCell.cs">
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
    /// Represents a table cell.
    /// </summary>  
    public class PageTableAreaCell 
    {                       
        /// <summary>
        /// Gets or sets the index of the column.
        /// </summary>  
        public int? ColumnIndex { get; set; }

        /// <summary>
        /// Gets or sets the total number of columns that contain the table cell.
        /// </summary>  
        public int? ColumnSpan { get; set; }

        /// <summary>
        /// Gets or sets the table cell value.
        /// </summary>  
        public PageArea PageArea { get; set; }

        /// <summary>
        /// Gets or sets the index of the row.
        /// </summary>  
        public int? RowIndex { get; set; }

        /// <summary>
        /// Gets or sets the total number of rows that contain the table cell.
        /// </summary>  
        public int? RowSpan { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class PageTableAreaCell {\n");
          sb.Append("  ColumnIndex: ").Append(this.ColumnIndex).Append("\n");
          sb.Append("  ColumnSpan: ").Append(this.ColumnSpan).Append("\n");
          sb.Append("  PageArea: ").Append(this.PageArea).Append("\n");
          sb.Append("  RowIndex: ").Append(this.RowIndex).Append("\n");
          sb.Append("  RowSpan: ").Append(this.RowSpan).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
