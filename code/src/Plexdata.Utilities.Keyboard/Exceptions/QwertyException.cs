/*
 * MIT License
 * 
 * Copyright (c) 2022 plexdata.de
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

using Plexdata.Utilities.Keyboard.Defines;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Plexdata.Utilities.Keyboard.Exceptions
{
    [Serializable]
    public class QwertyException : Exception
    {
        #region Construction

        public QwertyException()
            : base()
        {
            this.Value = String.Empty;
            this.Match = String.Empty;
            this.KeyType = KeyType.Empty;
            this.IsNumPad = false;
        }

        public QwertyException(String message)
            : base(message)
        {
            this.Value = String.Empty;
            this.Match = String.Empty;
            this.KeyType = KeyType.Empty;
            this.IsNumPad = false;
        }

        public QwertyException(String value, String match, KeyType type, Boolean numeric)
            : base(QwertyException.CreateMessage(value, match, type, numeric))
        {
            this.Value = value ?? String.Empty;
            this.Match = match ?? String.Empty;
            this.KeyType = KeyType.Empty;
            this.IsNumPad = numeric;
        }

        public QwertyException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected QwertyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.Value = info.GetString(nameof(this.Value));
            this.Match = info.GetString(nameof(this.Match));
            this.KeyType = (KeyType)info.GetValue(nameof(this.KeyType), typeof(KeyType));
            this.IsNumPad = info.GetBoolean(nameof(this.IsNumPad));
        }

        #endregion

        #region Public Properties

        public String Value { get; }

        public String Match { get; }

        public KeyType KeyType { get; }

        public Boolean IsNumPad { get; }

        #endregion

        #region Public Methods

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(this.Value), this.Value);
            info.AddValue(nameof(this.Match), this.Match);
            info.AddValue(nameof(this.KeyType), this.KeyType, typeof(KeyType));
            info.AddValue(nameof(this.IsNumPad), this.IsNumPad);

            base.GetObjectData(info, context);
        }

        #endregion

        #region Private Methods

        private static String CreateMessage(String value, String match, KeyType type, Boolean numeric)
        {
            value = value ?? String.Empty;
            match = match ?? String.Empty;

            if (numeric)
            {
                return $"Value \"{value}\" has a numeric match in \"{match}\" at position {match.IndexOf(value)}.";
            }

            return $"Value \"{value}\" has a keyboard match in \"{match}\" at position {match.IndexOf(value)}.";
        }

        #endregion
    }
}
