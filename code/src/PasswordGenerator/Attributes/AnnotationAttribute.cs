/*
 * MIT License
 * 
 * Copyright (c) 2020 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;

namespace Plexdata.PasswordGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class AnnotationAttribute : Attribute
    {
        #region Construction

        public AnnotationAttribute(String display, String remarks, Object value)
            : this(display, remarks, value, true)
        {
        }

        public AnnotationAttribute(String display, String remarks, Object value, Boolean visible)
            : base()
        {
            this.Display = display ?? String.Empty;
            this.Remarks = remarks ?? String.Empty;
            this.Value = value;
            this.Visible = visible;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets and sets the text to be displayed.
        /// </summary>
        public String Display { get; set; }

        /// <summary>
        /// Gets and sets additional remarks that could be used for example 
        /// for tooltips.
        /// </summary>
        public String Remarks { get; set; }

        /// <summary>
        /// Gets and sets the value assigned to this attribute. Such a value 
        /// could be useful for example for enumeration types.
        /// </summary>
        public Object Value { get; set; }

        /// <summary>
        /// Gets and sets the visibility state of this attribute.
        /// </summary>
        public Boolean Visible { get; set; }

        #endregion
    }
}
