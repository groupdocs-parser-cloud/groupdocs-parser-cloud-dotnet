// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="TextStyle.cs">
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
    /// The text style such as font size, font name an so on.             
    /// </summary>  
    public class TextStyle 
    {                       
        /// <summary>
        /// Gets or sets the name of the font.
        /// </summary>  
        public string FontName { get; set; }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>  
        public double? FontSize { get; set; }

        /// <summary>
        /// Gets or sets the value that indicates whether the font is bold.
        /// </summary>  
        public bool? IsBold { get; set; }

        /// <summary>
        /// Gets or sets the value that indicates whether the font is italic.
        /// </summary>  
        public bool? IsItalic { get; set; }

        /// <summary>
        /// Gets or sets the style name.
        /// </summary>  
        public string Name { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class TextStyle {\n");
          sb.Append("  FontName: ").Append(this.FontName).Append("\n");
          sb.Append("  FontSize: ").Append(this.FontSize).Append("\n");
          sb.Append("  IsBold: ").Append(this.IsBold).Append("\n");
          sb.Append("  IsItalic: ").Append(this.IsItalic).Append("\n");
          sb.Append("  Name: ").Append(this.Name).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
