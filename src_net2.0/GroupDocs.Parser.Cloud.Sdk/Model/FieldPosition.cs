// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="FieldPosition.cs">
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
    /// Field position class.
    /// </summary>  
    public class FieldPosition 
    {                       
        /// <summary>
        /// Provides a template field position.
        /// </summary>  
        public string FieldPositionType { get; set; }

        /// <summary>
        /// Rectangular area on the page that bounds the field value.
        /// </summary>  
        public Rectangle Rectangle { get; set; }

        /// <summary>
        /// Gets or sets the regular expression.
        /// </summary>  
        public string Regex { get; set; }

        /// <summary>
        /// Gets or sets the value that indicates whether a text case isn't ignored.
        /// </summary>  
        public bool? MatchCase { get; set; }

        /// <summary>
        /// Gets or sets the name of the linked field.
        /// </summary>  
        public string LinkedFieldName { get; set; }

        /// <summary>
        /// Gets or sets the value that indicates whether a field is searched by the left from the linked field.
        /// </summary>  
        public bool? IsLeftLinked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is right linked.
        /// </summary>  
        public bool? IsRightLinked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is top linked.
        /// </summary>  
        public bool? IsTopLinked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is bottom linked.
        /// </summary>  
        public bool? IsBottomLinked { get; set; }

        /// <summary>
        /// Gets or sets the size of the area where a field is searched.
        /// </summary>  
        public Size SearchArea { get; set; }

        /// <summary>
        /// Gets or sets Gets the value that indicates whether SearchArea is scaled by the linked field size.
        /// </summary>  
        public bool? AutoScale { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class FieldPosition {\n");
          sb.Append("  FieldPositionType: ").Append(this.FieldPositionType).Append("\n");
          sb.Append("  Rectangle: ").Append(this.Rectangle).Append("\n");
          sb.Append("  Regex: ").Append(this.Regex).Append("\n");
          sb.Append("  MatchCase: ").Append(this.MatchCase).Append("\n");
          sb.Append("  LinkedFieldName: ").Append(this.LinkedFieldName).Append("\n");
          sb.Append("  IsLeftLinked: ").Append(this.IsLeftLinked).Append("\n");
          sb.Append("  IsRightLinked: ").Append(this.IsRightLinked).Append("\n");
          sb.Append("  IsTopLinked: ").Append(this.IsTopLinked).Append("\n");
          sb.Append("  IsBottomLinked: ").Append(this.IsBottomLinked).Append("\n");
          sb.Append("  SearchArea: ").Append(this.SearchArea).Append("\n");
          sb.Append("  AutoScale: ").Append(this.AutoScale).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
