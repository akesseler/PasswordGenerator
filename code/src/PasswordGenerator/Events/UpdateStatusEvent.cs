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

namespace Plexdata.PasswordGenerator.Events
{
    public delegate void UpdateStatusEventHandler(Object sender, UpdateStatusEventArgs args);

    public class UpdateStatusEventArgs : EventArgs
    {
        public UpdateStatusEventArgs()
            : this(null, null)
        {
        }

        public UpdateStatusEventArgs(String value)
            : this(null, value)
        {
        }

        public UpdateStatusEventArgs(String label, String value)
            : base()
        {
            this.Label = (label ?? String.Empty).Trim();
            this.Value = (value ?? String.Empty).Trim();
        }

        public String Label { get; private set; }

        public String Value { get; private set; }
    }
}
